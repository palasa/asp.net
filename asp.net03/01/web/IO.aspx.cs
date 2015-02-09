using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace web
{
    public partial class IO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = @"C:\Documents and Settings\Administrator\桌面\firefox.jpg";

            string savepath = @"F:\barimage.bmp";

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            { 
                byte[] arr = new byte[fs.Length];

                using (BinaryReader br = new BinaryReader(fs))
                {
                    br.Read(arr, 0, arr.Length);

                    string filetype = arr[0].ToString() + arr[1].ToString();

                    Response.Write(filetype);
                }

                //using (FileStream fs1 = new FileStream(savepath, FileMode.Create, FileAccess.Write))
                //{
                //    using (BinaryWriter bw = new BinaryWriter(fs1))
                //    {
                //        bw.Write(arr);
                //    }
                //}
            }


        }
    }
}