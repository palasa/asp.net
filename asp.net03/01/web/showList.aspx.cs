using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace web
{
    public partial class showList : System.Web.UI.Page
    {
        //protected DataSet showds = new DataSet();

        protected List<Model.users> list = new List<Model.users>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Get("uid") != null)
            {
                string uid = Request.QueryString.Get("uid");

                DBUtility.SQLDbHelper.ExecuteSql(string.Format("delete from users where uid={0}",uid));
            }

            //showds = DBUtility.SQLDbHelper.Query("select * from users");

            using (SqlDataReader sr = DBUtility.SQLDbHelper.ExecuteReader("select * from users"))
            {
                while (sr.Read())
                {
                    list.Add(new Model.users() { 
                        
                        Uid=sr.GetInt32(0),
                        Uname=sr.GetString(1),
                        Upwd=sr.GetString(2)
                    });

                    
                }

            }


        }
    }
}