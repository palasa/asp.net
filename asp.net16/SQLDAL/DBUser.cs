using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Model;

namespace SQLDAL
{
    public class DBUser : Repository<Users>, IDAL.IUser
    {
        public DBUser():base()
        {
            this.TableName = "Users";

            this.ColumInfo = new Dictionary<string, ColumAttr>();

            this.ColumInfo.Add("Id", new ColumAttr { Name = "Id", IsPrim = true, Type = "char", ColLength = 32, IsRequire = true });
            this.ColumInfo.Add("LoginName", new ColumAttr { Name = "lgname", Type = "varchar", ColLength = 30, IsRequire = true });
            this.ColumInfo.Add("LoginPwd", new ColumAttr { Name = "lgpwd", Type = "varchar", ColLength = 32, IsRequire = true});
            this.ColumInfo.Add("RealName", new ColumAttr { Name = "realname", Type = "nvarchar", ColLength = 12, IsRequire = true});
            this.ColumInfo.Add("HeadImage", new ColumAttr { Name = "headimage",Type = "varchar", ColLength = 50, IsRequire = true});
            this.ColumInfo.Add("CreateTime", new ColumAttr { Name = "createTime", Type = "datetime", ColLength = 8, IsRequire = true, IsSort = true });
            this.ColumInfo.Add("IsEffc", new ColumAttr { Name = "iseffc", Type = "char", ColLength = 1, IsRequire = true });
        }

        #region 作废
        /*
        public int Add(Users model)
        {
            string SqlStr = string.Format("insert into users([id],[lgname],[lgpwd],[realname],[headimage],[createtime],[iseffc]) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')"
                ,model.Id
                ,model.LoginName
                ,model.LoginPwd
                ,model.RealName
                ,model.HeadImage
                ,model.CreateTime
                ,model.IsEffc);

            return DBUtility.SQLDbHelper.ExecuteSql(SqlStr);
        }

        public int Update(Users model)
        {
            string SqlStr = string.Format("update users set [lgname]='{1}',[lgpwd]='{2}',[realname]='{3}',[headimage]='{4}',[createtime]='{5}',[iseffc]='{6}' where [id]='{0}'"
                , model.Id
                , model.LoginName
                , model.LoginPwd
                , model.RealName
                , model.HeadImage
                , model.CreateTime
                , model.IsEffc);

            return DBUtility.SQLDbHelper.ExecuteSql(SqlStr);
        }

        public int Delete(string Id)
        {
            string SqlStr = string.Format("delete users where [id]='{0}' and [iseffc]='1'", Id);

            return DBUtility.SQLDbHelper.ExecuteSql(SqlStr);
        }

        public Users GetUserModelInfo(Users model)
        {
            string SqlStr = string.Format("select * from users where [lgname]='{0}' and [lgpwd]='{1}' and [iseffc]='1'"
                ,model.LoginName
                ,model.LoginPwd);

            using (SqlDataReader sr = DBUtility.SQLDbHelper.ExecuteReader(SqlStr))
            {
                if (sr.Read())
                {
                    return new Users { 
                        
                        Id=sr.GetString(0),
                        LoginName=sr.GetString(1),
                        LoginPwd=sr.GetString(2),
                        RealName=sr.GetString(3),
                        HeadImage=sr.GetString(4),
                        CreateTime=sr.GetDateTime(5),
                        IsEffc=sr.GetString(6)
                    };
                }
            }

            return null;
        }

        public Model.Users GetUserModelInfoByName(string loginname)
        {
            string SqlStr = string.Format("select * from users where [lgname]='{0}' and [iseffc]='1'", loginname);

            using (SqlDataReader sr = DBUtility.SQLDbHelper.ExecuteReader(SqlStr))
            {
                if (sr.Read())
                {
                    return new Users
                    {

                        Id = sr.GetString(0),
                        LoginName = sr.GetString(1),
                        LoginPwd = sr.GetString(2),
                        RealName = sr.GetString(3),
                        HeadImage = sr.GetString(4),
                        CreateTime = sr.GetDateTime(5),
                        IsEffc = sr.GetString(6)
                    };
                }
            }

            return null;
        }

        public IEnumerable<Users> GetUserModelInfoByName(string loginname,int pagesize)
        {
            string SqlStr = string.Format("select top {0} * from users where [lgname] like '%{1}%' and [iseffc]='1'"
                ,pagesize
                ,loginname);

            List<Users> list = new List<Users>();

            using (SqlDataReader sr = DBUtility.SQLDbHelper.ExecuteReader(SqlStr))
            {
                
                while (sr.Read())
                {
                    list.Add( new Users
                    {

                        Id = sr.GetString(0),
                        LoginName = sr.GetString(1),
                        LoginPwd = sr.GetString(2),
                        RealName = sr.GetString(3),
                        HeadImage = sr.GetString(4),
                        CreateTime = sr.GetDateTime(5),
                        IsEffc = sr.GetString(6)
                    });
                }

                return list;
            }
        }

        public Model.Users GetUserModelInfoById(string key)
        {
            string SqlStr = string.Format("select * from users where [Id]='{0}' and [iseffc]='1'", key);

            using (SqlDataReader sr = DBUtility.SQLDbHelper.ExecuteReader(SqlStr))
            {
                if (sr.Read())
                {
                    return new Users
                    {

                        Id = sr.GetString(0),
                        LoginName = sr.GetString(1),
                        LoginPwd = sr.GetString(2),
                        RealName = sr.GetString(3),
                        HeadImage = sr.GetString(4),
                        CreateTime = sr.GetDateTime(5),
                        IsEffc = sr.GetString(6)
                    };
                }
            }

            return null;
        }

        public IEnumerable<Model.Users> GetUserModelInfoById(IEnumerable<string> keys)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from users where [Id] in (");

            foreach (var s in keys)
            {
                sb.Append("'");
                sb.Append(s);
                sb.Append("',");
            }

            sb = sb.Remove(sb.Length - 1, 1);
            sb.Append(")");

            List<Users> list = new List<Users>();

            using (SqlDataReader sr = DBUtility.SQLDbHelper.ExecuteReader(sb.ToString()))
            {

                while (sr.Read())
                {
                    list.Add(new Users
                    {

                        Id = sr.GetString(0),
                        LoginName = sr.GetString(1),
                        LoginPwd = sr.GetString(2),
                        RealName = sr.GetString(3),
                        HeadImage = sr.GetString(4),
                        CreateTime = sr.GetDateTime(5),
                        IsEffc = sr.GetString(6)
                    });
                }

                return list;
            }
        }

        public IEnumerable<Model.Users> GetUserModelInfoByDate(DateTime d1, DateTime d2)
        {
            throw new NotImplementedException();
        }
         * */
        #endregion
    }
}
