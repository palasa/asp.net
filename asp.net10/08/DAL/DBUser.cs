using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
    public class DBUser
    {
        /// <summary>
        /// 满足用户名和用户密码查询
        /// </summary>
        /// <param name="model">填充用户名和用户密码</param>
        /// <returns>用户实体</returns>
        public Model.Users GetUserModelInfo(Model.Users model)
        {
            string SqlStr = string.Format("select * from [users] where [username]='{0}' and [userpwd]='{1}' ");

            using (SqlDataReader sr = DBUtility.SQLDbHelper.ExecuteReader(SqlStr))
            {
                if (sr.Read())
                {
                    return new Model.Users() { 
                        
                        UserId=sr.GetString(0),
                        UserName=sr.GetString(1),
                        UserPwd=sr.GetString(2)
                    };
                }
            }

            return null;
        }

        /// <summary>
        /// 更新用户实体
        /// </summary>
        /// <param name="model">用户实体，填充所有属性</param>
        /// <returns>受影响的行数</returns>
        public int Update(Model.Users model)
        {
            string SqlStr = string.Format("update users set [username]='{0}' , [password]='{1}' where [userid]='{2}'"
                , model.UserName
                , model.UserPwd
                , model.UserId);

            return DBUtility.SQLDbHelper.ExecuteSql(SqlStr);
        }

        public Model.Users GetUserInfoById(string UserId)
        {
            return null;
        }
    }
}
