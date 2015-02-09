using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;

namespace SQLDAL
{
    public class DBEmail : Repository<Emails>,　IDAL.IEmail
    {
        public DBEmail()
        {
            this.TableName = "Emails";

            this.ColumInfo = new Dictionary<string, ColumAttr>();

            this.ColumInfo.Add("Id", new ColumAttr { Name = "Id", IsPrim = true, Type = "char", ColLength = 32, IsRequire = true});
            this.ColumInfo.Add("Title", new ColumAttr { Name = "title", Type = "nvarchar", ColLength = 50, IsRequire = true });
            this.ColumInfo.Add("Content", new ColumAttr { Name = "content", Type = "nvarchar", ColLength = 400, IsRequire = true});
            this.ColumInfo.Add("CreateTime", new ColumAttr { Name = "CreateTime", Type = "datetime", ColLength = 8, IsRequire = true, IsSort = true });
            this.ColumInfo.Add("Sender", new ColumAttr { Name = "sender", Type = "char", ColLength = 32, IsRequire = true});
            this.ColumInfo.Add("IsEffc", new ColumAttr { Name = "state", Type = "char", ColLength = 1, IsRequire = true });
           
        }

        #region 作废

        //public int Add(Emails model)
        //{
        //    string SqlStr = string.Format("insert into emails([id],[title],[content],[createtime],[sender],[state]) values('{0}','{1}','{2}','{3}','{4}','{5}')"
        //        , model.Id
        //        , model.Title
        //        , model.Content
        //        , model.CreateTime
        //        , model.Sender
        //        , model.IsEffc);

        //    return DBUtility.SQLDbHelper.ExecuteSql(SqlStr);
        //}

        //public int Update(Emails model)
        //{
        //    string SqlStr = string.Format("update emails set [title]='{1}',[content]='{2}',[createtime]='{3}',[sender]='{4}',[state]='{5}' where [id]='{0}'"
        //        , model.Id
        //        , model.Title
        //        , model.Content
        //        , model.CreateTime
        //        , model.Sender
        //        , model.IsEffc);

        //    return DBUtility.SQLDbHelper.ExecuteSql(SqlStr);
        //}

        //public int Delete(string key)
        //{
        //    string SqlStr = string.Format("delete emails where [id]='{0}'", key);

        //    return DBUtility.SQLDbHelper.ExecuteSql(SqlStr);
        //}

        //public int GetEmailModelInfoCountBySender(string Sender)
        //{
        //    string SqlStr = string.Format("select * from Emails where [sender]= '{0}'",Sender);

        //    return (int)DBUtility.SQLDbHelper.GetSingle(SqlStr);
        //}

        //public Emails GetEmailModelInfoById(string id)
        //{
        //    string SqlStr = string.Format("select * from Emails where [id]= '{0}'", id);

        //    using (SqlDataReader sr = DBUtility.SQLDbHelper.ExecuteReader(SqlStr))
        //    {
        //        if (sr.Read())
        //        {
        //            return new Emails
        //            {

        //                Id = sr.GetString(0),
        //                Title = sr.GetString(1),
        //                Content = sr.GetString(2),
        //                CreateTime = sr.GetDateTime(3),
        //                Sender = sr.GetString(4),                        
        //                IsEffc = sr.GetString(5)
        //            };
        //        }
        //    }

        //    return null;
        //}

        //public IEnumerable<Emails> GetEmailModelInfoById(IEnumerable<string> keys)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("select * from emails where [Id] in (");

        //    foreach (var s in keys)
        //    {
        //        sb.Append("'");
        //        sb.Append(s);
        //        sb.Append("',");
        //    }

        //    sb = sb.Remove(sb.Length - 1, 1);
        //    sb.Append(") and [state]='1'");

        //    List<Emails> list = new List<Emails>();

        //    using (SqlDataReader sr = DBUtility.SQLDbHelper.ExecuteReader(sb.ToString()))
        //    {

        //        while (sr.Read())
        //        {
        //            list.Add(new Emails
        //            {

        //                Id = sr.GetString(0),
        //                Title = sr.GetString(1),
        //                Content = sr.GetString(2),
        //                CreateTime = sr.GetDateTime(3),
        //                Sender = sr.GetString(4),
        //                IsEffc = sr.GetString(5)
        //            });
        //        }

        //        return list;
        //    }
        //}

        //public IEnumerable<Emails> GetEmailModelInfoByTitle(string title, int currentindex, int pagesize)
        //{
        //    string SqlStr = string.Format("select top {0} * from (select *, ROW_NUMBER() over(order by id) as ROW from emails)email where email.ROW>{1} and [title] like '%{2}%' and [state]='1'"
        //        ,pagesize
        //        ,(currentindex-1)*pagesize
        //        ,title);

        //    List<Emails> list = new List<Emails>();

        //    using (SqlDataReader sr = DBUtility.SQLDbHelper.ExecuteReader(SqlStr))
        //    {

        //        while (sr.Read())
        //        {
        //            list.Add(new Emails
        //            {

        //                Id = sr.GetString(0),
        //                Title = sr.GetString(1),
        //                Content = sr.GetString(2),
        //                CreateTime = sr.GetDateTime(3),
        //                Sender = sr.GetString(4),
        //                IsEffc = sr.GetString(5)
        //            });
        //        }

        //        return list;
        //    }
        //}

        //public IEnumerable<Emails> GetEmailModelInfoByDate(DateTime d1, DateTime d2, int currentindex, int pagesize)
        //{
        //    string SqlStr = string.Format("select top {0} * from (select *, ROW_NUMBER() over(order by id) as ROW from emails)email where email.ROW>{1} and( [CreateTIme] > {2} and [CreateTime]<{3}) and [state]='1'"
        //        , pagesize
        //        , (currentindex - 1) * pagesize
        //        , d1
        //        , d2);

        //    List<Emails> list = new List<Emails>();

        //    using (SqlDataReader sr = DBUtility.SQLDbHelper.ExecuteReader(SqlStr))
        //    {

        //        while (sr.Read())
        //        {
        //            list.Add(new Emails
        //            {

        //                Id = sr.GetString(0),
        //                Title = sr.GetString(1),
        //                Content = sr.GetString(2),
        //                CreateTime = sr.GetDateTime(3),
        //                Sender = sr.GetString(4),
        //                IsEffc = sr.GetString(5)
        //            });
        //        }

        //        return list;
        //    }
        //}

        //public IEnumerable<Emails> GetEmailModelInfoBySender(string Sender, int currentindex, int pagesize)
        //{
        //    string SqlStr = string.Format("select top {0} * from (select *, ROW_NUMBER() over(order by id) as ROW from emails)email where email.ROW>{1} and [Sender] = '{2}' and [state]='1'"
        //        , pagesize
        //        , (currentindex - 1) * pagesize
        //        , Sender);

        //    List<Emails> list = new List<Emails>();

        //    using (SqlDataReader sr = DBUtility.SQLDbHelper.ExecuteReader(SqlStr))
        //    {

        //        while (sr.Read())
        //        {
        //            list.Add(new Emails
        //            {

        //                Id = sr.GetString(0),
        //                Title = sr.GetString(1),
        //                Content = sr.GetString(2),
        //                CreateTime = sr.GetDateTime(3),
        //                Sender = sr.GetString(4),
        //                IsEffc = sr.GetString(5)
        //            });
        //        }

        //        return list;
        //    }

        #endregion
    }
}
