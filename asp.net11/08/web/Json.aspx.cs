using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Text;

namespace web
{
    public partial class Json : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //List<Model.FileModel> list = new List<Model.FileModel>();
            //list.Add(new Model.FileModel
            //{
            //    FileClientName = "1.jpg",
            //    FileCreateTime = DateTime.Now,
            //    FileServerName = "dfsfsf.jpg"
            //    ,
            //    FileMessage = "成功",
            //    FileSize = 20,
            //    FileState = true
            //});
            //list.Add(new Model.FileModel
            //{
            //    FileClientName = "1.jpg",
            //    FileCreateTime = DateTime.Now,
            //    FileServerName = "dfsfsf.jpg"
            //    ,
            //    FileMessage = "成功",
            //    FileSize = 20,
            //    FileState = true
            //});
            string s = "[{\"FileClientName\":\"1.jpg\",\"FileServerName\":\"dfsfsf.jpg\",\"FileSize\":20,\"FileState\":true,\"FileMessage\":\"成功\",\"FileCreateTime\":\"2015-01-05T08:57:06.796875+08:00\"},{\"FileClientName\":\"1.jpg\",\"FileServerName\":\"dfsfsf.jpg\",\"FileSize\":20,\"FileState\":true,\"FileMessage\":\"成功\",\"FileCreateTime\":\"2015-01-05T08:57:06.796875+08:00\"}]";

            List<Model.FileModel> list = (List<Model.FileModel>)JsonConvert.DeserializeObject(s, typeof(List<Model.FileModel>));

            //string str = string.Empty;

            //StringBuilder sb = new StringBuilder();


            //for (var i = 0; i < 6; i++)
            //{
            //    sb.Append(i.ToString());
            //}



        }
    }
}