using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace web
{
    public partial class update : System.Web.UI.Page
    {
        protected DataSet datamodel = new DataSet();

        protected string message = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Get("uid") != null)
            {
                string uid = Request.QueryString.Get("uid");

                datamodel = DBUtility.SQLDbHelper.Query(string.Format("select * from users where uid={0}",uid));
            }

            if (Request.Form["sub"] != null)
            {
                string uname = Request.Form["uname"];
                string upwd = Request.Form["upwd"];
                string uid = Request.Form["uid"];

                int reuslt = DBUtility.SQLDbHelper.ExecuteSql(string.Format("update users set uname='{0}' , upwd='{1}' where uid={2}",uname,upwd,uid));

                if (reuslt > 0)
                {
                    Response.Redirect("showlist.aspx");
                }
                else
                {
                    message = "更新失败";
                }
            }
        }
    }
}