using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Common
{
    public class DownloadHelper
    {
        private string _clientnanme;

        public string Clientnanme
        {
          get{
              if(_clientnanme==string.Empty && _clientnanme==null)
              {
                return Servername;
              }
            else
            {
            return _clientnanme;
            }
          }
            set{_clientnanme=value;}
        }

        private string _servername;

        public string Servername
        {
          get { return _servername; }
          set { _servername = value; }
        }

        public void DownLoadTransmitFile()
        {
            FileInfo fileInfo = new FileInfo(Servername);
            if (fileInfo.Exists)
            {
                HttpContext.Current.Response.ContentType = "application/x-zip-compressed";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename="+Clientnanme);
                HttpContext.Current.Response.TransmitFile(fileInfo.FullName);
            }

        }

        public void DownLoadWriteFile()
        {
            FileInfo fileInfo = new FileInfo(Servername);
            if(fileInfo.Exists)
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ClearHeaders();
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + Clientnanme);
                HttpContext.Current.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                HttpContext.Current.Response.AddHeader("Content-Transfer-Encoding", "binary");
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                HttpContext.Current.Response.WriteFile(fileInfo.FullName);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();

            }
            
        }

        public void DownLoadWriteFileByBlock()
        {

            System.IO.FileInfo fileInfo = new System.IO.FileInfo(Servername);
            if (fileInfo.Exists)
            {
                const long ChunkSize = 102400;//100K 每次读取文件，只读取100Ｋ，这样可以缓解服务器的压力
                byte[] buffer = new byte[ChunkSize];
                HttpContext.Current.Response.Clear();
                System.IO.FileStream iStream = System.IO.File.OpenRead(fileInfo.FullName);
                long dataLengthToRead = iStream.Length;//获取下载的文件总大小
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(Clientnanme));
                while (dataLengthToRead > 0 && HttpContext.Current.Response.IsClientConnected)
                {
                    int lengthRead = iStream.Read(buffer, 0, Convert.ToInt32(ChunkSize));//读取的大小
                    HttpContext.Current.Response.OutputStream.Write(buffer, 0, lengthRead);
                    HttpContext.Current.Response.Flush();
                    dataLengthToRead = dataLengthToRead - lengthRead;
                }
                HttpContext.Current.Response.Close();
            }

            
        }

    }
}