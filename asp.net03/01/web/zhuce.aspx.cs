using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace web
{
    public partial class zhuce : System.Web.UI.Page
    {
        protected string message = string.Empty  ;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["sub"] != null)
            {
                string uname = Request.Form["uname"];
                string upwd = Request.Form["upwd"];

                #region 作废
                /*
                using (SqlConnection conn = new SqlConnection("data source=.;initial catalog=test;user id=sa;password=123"))
                {
                    conn.Open();
                    using(SqlCommand ssd = new SqlCommand(string.Format("insert into users values('{0}','{1}')",uname,upwd)))
                    {
                        ssd.ExecuteNonQuery();
                    }

                }
                 * */
                #endregion

                int result = DBUtility.SQLDbHelper.ExecuteSql(string.Format("insert into users values('{0}','{1}')", uname, upwd));

                if (result > 0)
                {
                    Response.Redirect("showlist.aspx");
                }
                else
                {
                    message = "注册失败！";
                }

            }

        }
    }
}