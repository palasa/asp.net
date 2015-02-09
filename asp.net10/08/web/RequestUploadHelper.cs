using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Model;

namespace web
{
    public class RequestUploadHelper
    {
        public RequestUploadHelper()
        {
            list = new List<FileModel>();
        }

        /// <summary>
        /// 上传对象集合
        /// </summary>
        public HttpFileCollection HttpFiles { get; set; }
        /// <summary>
        /// 保存的路径
        /// </summary>
        public string SavePath { get; set; }
        /// <summary>
        /// 上传文件的大小
        /// </summary>
        public int FileSize { get; set; }
        /// <summary>
        /// 可接受的文件类型
        /// </summary>
        public string[] FileType { get; set; }
        /// <summary>
        /// 不可接受的危险类型
        /// </summary>
        public string[] DamType { get; set; }

        private List<FileModel> list;



        public List<FileModel> UploadMethod(){

            for (int i = 0; i < this.HttpFiles.Count; i++)
            {
                if (this.HttpFiles[i].FileName == string.Empty)
                {
                    list.Add(new FileModel() {FileClientName="未知",FileServerName="未知",FileState=false,FileMessage="空文件"});
                    continue;
                }


                //验证后缀

                //获取文件名
                string filename = Path.GetFileName(this.HttpFiles[i].FileName);
                //获取后缀名
                string extension = Path.GetExtension(filename);
                //服务器保存名
                string servername = Guid.NewGuid().ToString() + extension;

                if (!this.FileType.Contains(extension.ToLower()))
                {
                    list.Add(new FileModel() { FileClientName = filename, FileServerName = servername,FileSize=this.HttpFiles[i].ContentLength,FileCreateTime=DateTime.Now, FileState = false, FileMessage = "后缀不符" });
                    continue;
                }


                if (this.HttpFiles[i].ContentLength > this.FileSize)
                {
                    list.Add(new FileModel() { FileClientName = filename, FileServerName = servername, FileSize = this.HttpFiles[i].ContentLength, FileCreateTime = DateTime.Now, FileState = false, FileMessage = "文件过大" });
                    continue;
                }


                //危险类型
                //Response.Write(Request.Files[i].ContentType);

                byte[] filearr;

                string filetype = string.Empty;

                using (Stream file = this.HttpFiles[i].InputStream)
                {
                    filearr = new byte[file.Length];
                    file.Read(filearr, 0, filearr.Length);

                    filetype = filearr[0].ToString() + filearr[1].ToString();

                    if (DamType.Contains(filetype))
                    {
                        list.Add(new FileModel() { FileClientName = filename, FileServerName = servername, FileSize = this.HttpFiles[i].ContentLength, FileCreateTime = DateTime.Now, FileState = false, FileMessage = "危险类型" });
                        continue;
                    }
                        


                    this.HttpFiles[i].SaveAs(this.SavePath+servername);
                    list.Add(new FileModel() { FileClientName = filename, FileServerName = servername, FileSize = this.HttpFiles[i].ContentLength, FileCreateTime = DateTime.Now, FileState = true, FileMessage = "成功" });
                }

            }

            return list;

        }
    }
}