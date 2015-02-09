using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDAL
{
    public class DBUser : IDAL.IUser
    {
        #region IUser 成员

        public Model.Users GetUserModelInfo(Model.Users model)
        {
            string SqlStr = string.Format("select * from [users] where [username]='{0}' and [userpwd]='{1}' "
                ,model.UserName
                ,model.UserPwd);

            using (MySqlDataReader sr = DBUtility.MySQLDbHelper.ExecuteReader(SqlStr))
            {
                if (sr.Read())
                {
                    return new Model.Users()
                    {

                        UserId = sr.GetString(0),
                        UserName = sr.GetString(1),
                        UserPwd = sr.GetString(2)
                    };
                }
            }

            return null;
        }

        public IList<Model.Users> GetUserModelListByName(string name)
        {
            throw new NotImplementedException();
        }

        public IList<Model.Users> GetUserModelListByID(string ID)
        {
            throw new NotImplementedException();
        }

        public int Add(Model.Users model)
        {
            throw new NotImplementedException();
        }

        public int Update(Model.Users model)
        {
            throw new NotImplementedException();
        }

        public int Delete(string ID)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
