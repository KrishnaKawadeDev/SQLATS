using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Threading;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.MultiQuery
{
   class QueryHelper
   {
      public string queryMessages = "";
        private static object threadLock = new object();
        public static int CountQuotes = 0;
        public void CatchQueryMessages(object sender, SqlInfoMessageEventArgs e)
      {
         try
         {
            foreach (SqlError err in e.Errors)
            {
               queryMessages += err.Message;
            }
            queryMessages += "\r\n";
         }
         catch // (Exception exception)
         {
         }   
      }
      
      public static MultiQueryResult
         ExecuteQuery(
            ServerInformation  server,
            int                commandTimeout,
            JobPoolOptions     options
         )
      {
         QueryHelper qhelper = new QueryHelper();
         
         MultiQueryResult mqResult = new MultiQueryResult();
         
         MultiQueryOptions mqo = (MultiQueryOptions)server.Tag;
         
         SqlConnection conn = null;
            lock (threadLock)
            {
                try
                {
                    conn = Connection.OpenConnection(server.Name,
                                                      mqo.database,
                                                      server.SqlCredentials);

                    // run options queries - set ROWCOUNT, TEXTSIZE
                    SetOptions(conn);

                    conn.InfoMessage += new SqlInfoMessageEventHandler(qhelper.CatchQueryMessages);

                    // start execution time
                    int start = System.Environment.TickCount;

                    // run user query
                    try
                    {
                        RunUserQuery(conn, ref mqResult, ref qhelper);

                        if (mqResult.nResultSets == 0 && mqResult.message.Length == 0)
                        {
                            mqResult.message = "Command(s) completed successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // shouldnt ever get here
                        CoreGlobals.traceLog.ErrorFormat("Exception from RunUserQuery - {0}", ex.Message);
                    }
                    finally
                    {
                        // stop execution time
                        int stop = System.Environment.TickCount;
                        mqResult.executionTimeInTicks = stop - start;
                    }
                }
                catch (SqlException sqlEx)
                {
                    mqResult.nSucceeded = 0;
                    mqResult.nFailed = 1;
                    mqResult.message = Helpers.GetCombinedExceptionText(sqlEx);
                }
                finally
                {
                    Connection.CloseConnection(conn);
                }
            }
         
         return mqResult;
      }
      
      private static void
         SetOptions(
            SqlConnection conn
         )
      {
         string sql = "";
         if ( ProductConstants.optionsRowCount > 0 )
         {
            sql += String.Format( "SET ROWCOUNT {0}; ", ProductConstants.optionsRowCount );
         }
         
         if ( ProductConstants.optionsTextSize > 0 )
         {
            sql += String.Format( "SET TEXTSIZE {0}; ", ProductConstants.optionsTextSize * 1024 );
         }

         sql += "SET NOCOUNT OFF; ";
         
         if ( sql != "" )
         {
            using ( SqlCommand cmd = new SqlCommand( sql, conn ) )
            {
               cmd.CommandTimeout = ProductConstants.optionsCommandTimeout;
               cmd.ExecuteNonQuery();
            } 
         }
      }
      
      private static void
         RunUserQuery(
            SqlConnection        conn,
            ref MultiQueryResult queryResult,
            ref QueryHelper      qhelper
         )
      {
         if ( ProductConstants.QueryText != "" )
         {
            queryResult.nTotal       = ProductConstants.QueryBatches.Count;
            queryResult.batchResults = new List<BatchResult>(ProductConstants.QueryBatches.Count);
            
            int tableCount = 0;
            
            for ( int i=0; i< ProductConstants.QueryBatches.Count; i++ )
            {
                if ( queryResult.message.Length != 0 ) 
                {
                   queryResult.message += "\r\n";
                }
                
                CoreGlobals.traceLog.DebugFormat( "RunUserQuery - Batch {0}: {1}", i, ProductConstants.QueryBatches[i].ToString() );

                queryResult.batchResults.Add( new BatchResult() );
                
                try
                { 
                   queryResult.batchResults[i].dataSet = new DataSet();
                   SqlDataAdapter dataAdapter = new SqlDataAdapter(  ProductConstants.QueryBatches[i].ToString(), conn );
                   dataAdapter.SelectCommand.CommandTimeout = ProductConstants.optionsCommandTimeout;
                   
                   string sqlExceptionMsg = "";
                   
                   try
                   {
                      dataAdapter.Fill(queryResult.batchResults[i].dataSet);
                      
                      queryResult.batchResults[i].succeeded = true;
                      queryResult.nSucceeded++;
                   }
                   catch ( SqlException sqlEx )
                   {
                       // we do this here because it is possible that a batch could throw an exception
                       // but stil return result sets
                       // e.g.
                       // select @@sqlversion
                       // select * from master
                       // in this case the second select fails but the first run succeeds and returns results
                       
                      queryResult.batchResults[i].succeeded = false;
                      queryResult.nFailed++;
                   
                      sqlExceptionMsg = String.Format( "Msg {0}, Level {1}, State {2}, Line {3}\r\n{4}\r\n",
                                                       sqlEx.Number,
                                                       sqlEx.Class,
                                                       sqlEx.State,
                                                       sqlEx.LineNumber,
                                                       sqlEx.Message );
                   }
                   
                   
                   queryResult.nResultSets += queryResult.batchResults[i].dataSet.Tables.Count;
                   for ( int t=0; t<queryResult.batchResults[i].dataSet.Tables.Count; t++ )
                   {
                      queryResult.nRows   += queryResult.batchResults[i].dataSet.Tables[t].Rows.Count;
                      
                      tableCount++;  // total number of result set across batches so far

                      string msg = String.Format( "Result Set {0}: {1} rows affected\r\n",
                                                  tableCount,
                                                  queryResult.batchResults[i].dataSet.Tables[t].Rows.Count );
                                                            
                      queryResult.message            += msg;
                   }
                   
                   if ( sqlExceptionMsg != "" )
                   {
                      queryResult.message += sqlExceptionMsg;
                   }
                }
                catch ( Exception ex )
                {
                   queryResult.batchResults[i].succeeded = false;
                   queryResult.nFailed++;
                   queryResult.message += String.Format( "{0}\r\n", Helpers.GetCombinedExceptionText(ex) );
                }
                finally
                {
                   // add text from InfoMessage event Handler
                   qhelper.queryMessages = qhelper.queryMessages.Replace( "\r\n", "\r" );
                   qhelper.queryMessages = qhelper.queryMessages.Replace( "\n", "\r" );
                   qhelper.queryMessages = qhelper.queryMessages.Replace( "\r", "\r\n" );
                   
                   queryResult.message += qhelper.queryMessages;
                   
                   qhelper.queryMessages = "";
                }
             }
             
             if ( queryResult.nSucceeded > 0 && queryResult.nFailed > 0 )
             {
                queryResult.message  = String.Format( "Partial Success: {0} of {1} batches succeeded.\r\n\r\n",
                                                      queryResult.nSucceeded,
                                                      queryResult.nTotal )
                                        + queryResult.message;                
             }                
         }
         else
         {
            queryResult.batchResults = new List<BatchResult>(1);
            queryResult.batchResults[0].succeeded = false;
            queryResult.nFailed++;
            queryResult.message += "No query defined";
         }
      }
      
      #region Do Results Match Routines
      
      //---------------------------------------------------------------------------------
      // DoDataSetMetaDataMatch - Compare all the meta data of all the DataTables in 
      //                          2 datasets to make sure they match
      //---------------------------------------------------------------------------------
      public static bool
         DoDataSetMetaDataMatch( 
            ref DataSet dataSet1,
            ref DataSet dataSet2
         )
      {
         bool match = true;
         
         if ( dataSet1 == null && dataSet2 == null ) return true;
         if ( dataSet1 == null || dataSet2 == null ) return false;
         
         if ( dataSet1.Tables.Count != dataSet2.Tables.Count )
         {
            match = false;
         }   
         else
         {
            for ( int i=0; i< dataSet1.Tables.Count; i++ )
            {
               if ( ! DoDataTablesMetaDataMatch( ref dataSet1,
                                                 ref dataSet2,
                                                 i ) )
               {
                  match = false;
                  break;
               }                                                 
            }
         }
         
         return match;
      }
   
      //---------------------------------------------------------------------------------
      // DoDataTablesMetaDataMatch - Compare all the meta data of columns
      //                             in 2 DataTables to make sure they match
      //---------------------------------------------------------------------------------
      public static bool
         DoDataTablesMetaDataMatch( 
            ref DataSet dataSet1,
            ref DataSet dataSet2,
            int table
         )
      {
         bool match = true;
         
         if ( dataSet1.Tables[table].Columns.Count != dataSet2.Tables[table].Columns.Count )
         {
            match = false;
         }   
         else
         {
            for ( int i=0; i< dataSet1.Tables[table].Columns.Count; i++ )
            {
               if ( dataSet1.Tables[table].Columns[i].Caption  != dataSet2.Tables[table].Columns[i].Caption ||
                    dataSet1.Tables[table].Columns[i].DataType != dataSet2.Tables[table].Columns[i].DataType )
               {
                  match = false;
                  break;
               }                                                 
            }
         }
         return match;
      }
      
      #endregion
      
      //-------------------------------------------------------------------------------------
      // SQLur - Break SQL statement into batches
      //-------------------------------------------------------------------------------------
      static public List<StringBuilder> SqlParser(string sql, string batchSeparator)
      {     
         CountQuotes = 0;
         bool   newBatchNextLine = true;
         bool stringsClosed = true;
         bool isN = false;
         char[] crlf = new char[] { '\r', '\n' };
         string currentLine = "";
         List<StringBuilder> batches = new List<StringBuilder>();
       
         while ( sql != "" )
         {
            // loop through lines of SQL one line at a time
            int pos = sql.IndexOfAny(crlf);

            if ( pos != -1 )
            {
               // append all CR or LF to current line
               while (pos + 1 <= sql.Length)
               {
                  if (sql[pos] == '\r' || sql[pos] == '\n' ) 
                     pos++;
                  else 
                     break;
               }
               currentLine = sql.Substring(0,pos);
               sql = sql.Substring(pos);
                CountQuotes += currentLine.Split('\'').Length - 1;
                }
            else
            {
               currentLine = sql;
               sql = "";
            }
            
            if(currentLine.Contains("N'") && !isN)
            {
                isN = true;
                if((currentLine.Split('\'').Length - 1) % 2 == 0)
                    isN = false;
            }
            else if (isN)
            {
                if((currentLine.Split('\'').Length - 1) % 2 != 0)
                    isN = false;
                else
                {
                    int CQuotes = 0;
                    if (currentLine.Contains("/*"))
                    {
                        CQuotes = currentLine.Split(new string[] { "/*" }, StringSplitOptions.None)[0].Split('\'').Length - 1;
                    }
                    else if (currentLine.Contains("--"))
                    {
                        CQuotes = currentLine.Split(new string[] { "--" }, StringSplitOptions.None)[0].Split('\'').Length - 1;
                    }
                    if(CQuotes % 2 != 0)
                        isN = false;
                }
            }

            if (currentLine.StartsWith("--"))
            {
                if (currentLine.Contains("'"))
                {
                    int CQuotes = currentLine.Split('\'').Length - 1;
                    CountQuotes = CountQuotes - CQuotes;
                }
  
            }
            //At this point we have the current line.  Process that line. 
            bool foundGO = false;

            // eat leading white space and comments
            string consumedLine = ConsumeLeadingWhiteSpaceAndComments( currentLine );

            //if we find any unterminated strings on the current line, mark it as unclosed.
            int quoteIndex = consumedLine.IndexOf('\'');

            if (quoteIndex != -1)
            {
               if (consumedLine.IndexOf('\'', quoteIndex + 1) == -1)
               {
                  stringsClosed = !stringsClosed;

                  if (stringsClosed)
                  {
                     //We found the closing quote.   Any Go on this line will be ignored.
                     batches[batches.Count - 1].Append(currentLine);
                     continue;
                  }
               }
            }

               //look for batches on the current line
               if (consumedLine.ToUpper().StartsWith(batchSeparator))
               {
                    if(CountQuotes % 2 == 0)
                    {
                        foundGO = true;
                    }
                    if(!isN)
                    {
                        isN = false;
                        foundGO = true;
                    } else
                    {
                        foundGO = false;
                    }
                  

                  // is there anything after the GO but comments
                  consumedLine = consumedLine.Substring(2);
                  consumedLine = ConsumeLeadingWhiteSpaceAndComments(consumedLine);

                    if (consumedLine.Length > 2 && !consumedLine.StartsWith("--") && !consumedLine.StartsWith("\r\n"))
                    {
                        if (consumedLine.Contains("'"))
                        {
                          int  CQuotes = currentLine.Split('\'').Length - 1;
                            CountQuotes = CountQuotes- CQuotes;
                        }

                     foundGO = false;
                  }
               }

            if ( foundGO )
            {
              
               newBatchNextLine = true;
              stringsClosed = true;
            }
            else
            {
               if ( newBatchNextLine )
               {
                  batches.Add( new StringBuilder(1024) );
                  newBatchNextLine = false;
               }
               batches[batches.Count-1].Append( currentLine );
            }
         }
         return batches;
      }
      
      static private string
         ConsumeLeadingWhiteSpaceAndComments(
            string inString
         )
      {
         string consumedLine = inString;

         // we dont care about the final string so we can just do a blind
         // replace of tabs with spaces - makes it easier to deal with white space
         consumedLine = consumedLine.Replace( '\t', ' ' );

         bool stillEating = true;
         
         while ( stillEating )
         {
            stillEating = false;
  
            consumedLine = consumedLine.Trim();
            if ( consumedLine.Length >= 2 && consumedLine.StartsWith( "/*" ) )
            {
               // in comment - eat it
               int pos = consumedLine.IndexOf("*/");
               if ( pos == - 1)
               {
                  consumedLine = "";
               }
               else
               {
                  consumedLine = consumedLine.Substring(pos+2);
                  stillEating = true;  //; keep eating as long as we find comments
               }
            }
         }
         
         return consumedLine;
      }
   }
}
