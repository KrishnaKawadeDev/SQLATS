using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.SqlSearch
{
    public partial class Form_SQLViewer : Form
    {
        private string    m_searchString;
        private bool      m_matchCase;
        private bool      m_allowWildcards;
        private Regex     m_pattern = null;
        private int       m_currentIndex = 0;
        private int       m_objectCount  = 0;
        private Form_Main m_parent;

        public
           Form_SQLViewer(
              string    database,
              string    name,
              string    sql,
              bool      isJob,
              string    jobInfo,
              string    searchString,
              bool      matchCase,
              bool      allowWildcards,
              int       currentIndex,
              int       objectCount,
              Form_Main parent
           )
        {
            InitializeComponent();
            
            m_parent = parent;

             if ( isJob )
             {
                labelObject.Text = name + "\r\n" + jobInfo;
             }
             else
             {
                labelObject.Text = name + " in " + database;
             }
            textSQL.Text             = sql;
            m_currentIndex     = currentIndex;            
            m_objectCount      = objectCount;
            buttonPrev.Enabled = ( currentIndex != 0 );
            buttonNext.Enabled = ( currentIndex != (m_objectCount-1) );
            
            m_matchCase              = matchCase;
            m_allowWildcards         = allowWildcards;

            if ( allowWildcards )
            {           
               string regexString = SQLHelpers.ConvertSqlWildcardToRegEx( searchString );
              
               try
               {
                  m_pattern = new Regex( regexString, (matchCase) ? RegexOptions.None : RegexOptions.IgnoreCase);
               }
               catch
               {
                  m_pattern = null;
               }
            }
            else
            {
               if ( m_matchCase )
                  m_searchString = searchString;
               else
                  m_searchString = searchString.ToLower();
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // highlight first occurence
            FindNextMatch( true );

            textSQL.Focus();            
       }

        private void buttonFindNextMatch_Click(object sender, EventArgs e)
        {
            FindNextMatchEventHandler();
        }

        private void FindNextMatchEventHandler()
        {
            if ( ! FindNextMatch(false) )
            {
               // start over from beginning
               FindNextMatch(true);
            }
        }

        private bool FindNextMatch( bool startFromBeginning )
        {
            bool found = false;

            int currpos = textSQL.SelectionStart;
            if ( startFromBeginning )
            {
               currpos = 0;
            }
            else
            {
               if ( currpos < 0 ) currpos = 0;
               //else if ( currpos > (textSQL.Text.Length - m_searchString.Length) ) return false;
               else if ( currpos > textSQL.Text.Length - 1 ) return false;
               else currpos = currpos+1;
            }

            int pos;
            int len;

            if ( m_allowWildcards )
            {
               if ( m_pattern != null )
               {
                  Match matchObj = m_pattern.Match(textSQL.Text,currpos);
                  pos = matchObj.Index - currpos;
                  len = matchObj.Length;
               }
               else
               {
                 pos = -1;
                 len = 0;
               }
            }
            else
            {
               len = m_searchString.Length;
               
               if (m_matchCase)
                   pos = textSQL.Text.Substring(currpos).IndexOf(m_searchString);
               else
                   pos = textSQL.Text.Substring(currpos).ToLower().IndexOf(m_searchString);
            }
            
            if (pos >= 0)
            {
                //   textSQL.SelectedText = textSQL.Text.Substring(pos, m_searchString.Length );

                textSQL.Select(pos + currpos, len);

                found = true;
            }
            else 
            {
               found = false;
            }
            return found;
        }

        private void Form_SQLViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.F3 )
            {
                FindNextMatchEventHandler();
            }

            if ( e.KeyCode == Keys.F ) //&& e.Modifiers == Keys.ControlKey )
            {
                FindNextMatchEventHandler();
            }
        }

        private void checkWordWrap_CheckedChanged(object sender, EventArgs e)
        {
            textSQL.WordWrap = checkWordWrap.Checked;
        }

       private void contextMenuCopy_Click( object sender, EventArgs e )
       {
          string sql = textSQL.SelectedText;   

          sql = sql.Replace(  "\n", "\r\n" );     

          Clipboard.SetDataObject( sql );
       }

       private void contextMenuFindNextMatch_Click( object sender, EventArgs e )
       {
          FindNextMatchEventHandler();
       }

       private void contextMenuSelectAll_Click( object sender, EventArgs e )
       {
          textSQL.SelectAll();
       }

       private void buttonPrevious_Click( object sender, EventArgs e )
       {
          GetObjectSql( m_currentIndex-1 );
       }

       private void buttonNext_Click( object sender, EventArgs e )
       {
          GetObjectSql( m_currentIndex+1 );
       }
       
       private void GetObjectSql( int newIndex )
       {
          try
          {
             string newName      = "";
             string newDatabase  = "";
             bool   isJob        = false;
             string jobInfo      = "";
             string newSql       = m_parent.GetObjectSql( newIndex,
                                                          out newName,
                                                          out newDatabase,
                                                          out isJob,
                                                          out jobInfo );
             
             m_currentIndex      = newIndex;            
             buttonPrev.Enabled = ( m_currentIndex != 0 );
             buttonNext.Enabled = ( m_currentIndex != (m_objectCount-1) );
             
             if ( isJob )
             {
                labelObject.Text    = newName + "\r\n" + jobInfo;
             }
             else
             {
                labelObject.Text    = newName + " in " + newDatabase;
             }
             textSQL.Text        = newSql;
             
             FindNextMatch( true );
             textSQL.Focus();            
          }
          catch (Exception ex)
          {
             Messaging.ShowException ( "GetObject", ex );
          }
       }
    }
}