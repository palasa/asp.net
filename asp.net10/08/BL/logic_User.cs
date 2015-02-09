using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class logic_User
    {
        private readonly DAL.DBUser dbdata = new DAL.DBUser();

        public Model.Users Login(string username,string userpwd)
        {
            //验证参数  安全性验证

            Model.Users model = dbdata.GetUserModelInfo(new Model.Users() { UserName = username, UserPwd = userpwd });

            if (model == null)
                throw new Exception("登录失败");

            return model;
        }
    }
}
