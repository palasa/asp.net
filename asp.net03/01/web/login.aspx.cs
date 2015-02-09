using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace web
{
    public partial class login : System.Web.UI.Page
    {
        protected string message = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["sub"] !=null)
            { 


               string uname=Request.Form["uname"];
               string upwd = Request.Form["upwd"];

               #region 过时
               /*
               string connStr = "data source=.;initial catalog=test;user id=sa;password=123";

               DataSet ds = new DataSet();
               using (SqlConnection conn = new SqlConnection(connStr))
                {
                   using(SqlDataAdapter sda=new SqlDataAdapter(string.Format("select * from users where uname='{0}'and upwd='{1}' ",uname,upwd),conn))
                   {

                       sda.Fill(ds);
                  }


                }
                */
               #endregion

               DataSet ds = DBUtility.SQLDbHelper.Query(string.Format("select * from users where uname='{0}'and upwd='{1}' ", uname, upwd));

               if (ds.Tables[0].Rows.Count > 0)
               {
                   Response.Redirect("a.aspx");
               }
               else
               {
                   message = "登录失败！！！";
               }

            }
            

        }
    }
}