using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Newtonsoft.Json;

namespace web
{
    public partial class upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            #region 过期

            //for (int i = 0; i < Request.Files.Count; i++)
            //{
            //    if (Request.Files[i].FileName == string.Empty)
            //        continue;

            //    //.EXE  .BAT

            //    //验证后缀

            //    //获取文件名
            //    string filename = Path.GetFileName( Request.Files[i].FileName);
            //    //获取后缀名
            //    string extension = Path.GetExtension(filename);
            //    //服务器保存名
            //    string servername = Guid.NewGuid().ToString() + extension;

            //    if (extension != ".jpg" && extension != ".bmp")
            //    {
            //        continue;
            //    }


            //    if (Request.Files[i].ContentLength > 204800)
            //    {
            //        continue;
            //    }


            //    //危险类型
            //    //Response.Write(Request.Files[i].ContentType);

            //    byte[] filearr;

            //    string filetype = string.Empty;

            //    using (Stream file = Request.Files[i].InputStream)
            //    {
            //        filearr = new byte[file.Length];
            //        file.Read(filearr, 0, filearr.Length);

            //        filetype = filearr[0].ToString() + filearr[1].ToString();

            //        if (filetype == "7790")
            //            continue;


            //        Request.Files[i].SaveAs(Server.MapPath("~/" + servername));
            //    }



            //}
            #endregion

            RequestUploadHelper uploadobj = new RequestUploadHelper() { 
                HttpFiles=Request.Files,
                SavePath = Server.MapPath("~/"),
                FileSize=2048000,
                FileType=new string[]{".jpg",".bmp"},
                DamType=new string[]{"7790"}
            };

            List<Model.FileModel> list = uploadobj.UploadMethod();

            string tempstr = JsonConvert.SerializeObject(list);

            //list = list.FindAll(f => f.FileState == true);
            
       
        }
    }
}