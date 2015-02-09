using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace web
{
    public partial class upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["sb"] != null)
            {
                if (Request.Files.Count > 0)
                {

                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFile hf = Request.Files[i];

                        if (hf.FileName != string.Empty)
                        {
                            //hf.SaveAs(@"D:/" +Path.GetFileName( hf.FileName));
                            hf.SaveAs(Server.MapPath("~/Upload/") + Path.GetFileName(hf.FileName));

                            Path.GetExtension(hf.FileName);
                        }
                        else
                        { }
                    }
                }
                else
                { }
            }
        }
    }
}