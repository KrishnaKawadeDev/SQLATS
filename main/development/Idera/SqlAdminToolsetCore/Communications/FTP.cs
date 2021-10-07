using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace Idera.SqlAdminToolset.Core
{
   public class FTP
   {
      public FTP()
      {
      }
      
      public void
         DownloadFile(
            string   serverFile,
            string   clientFile
         )
      {
/*      
         Stream       responseStream = null;
         FileStream   fileStream = null;
			StreamReader reader = null;
			try
			{
				FtpWebRequest downloadRequest =
					(FtpWebRequest)WebRequest.Create(downloadUrl);
				FtpWebResponse downloadResponse =
					(FtpWebResponse)downloadRequest.GetResponse();
				responseStream = downloadResponse.GetResponseStream();

				string fileName = Path.GetFileName(downloadRequest.RequestUri.AbsolutePath);
				
				// Open outputfile
				fileStream = File.Create(clientFile);
				byte[] buffer = new byte[1024];
				int bytesRead;
				while (true)
				{
					bytesRead = responseStream.Read(buffer, 0, buffer.Length);
					if (bytesRead == 0)
						break;
					fileStream.Write(buffer, 0, bytesRead);
				}
			}
			catch (UriFormatException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (WebException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (IOException ex)
			{
				Console.WriteLine(ex.Message);
			}
         finally
         {
			   if (reader != null)
				   reader.Close();
			   else if (responseStream != null)
                    responseStream.Close();
                if (fileStream != null)
                    fileStream.Close();
         }
*/
      }
   }
}
