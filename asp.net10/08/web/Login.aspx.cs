using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class Login : System.Web.UI.Page
    {
        protected string message = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BL.logic_User blmodel = new BL.logic_User();

                Session["userinfo"] = blmodel.Login("", "");
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }
    }
}