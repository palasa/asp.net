using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Model;

namespace SQLDAL
{
    public class DBAccepter : Repository<Accepters>, IDAL.IAccepter
    {

        public DBAccepter()
        {
            this.TableName = "Accepters";

            this.ColumInfo = new Dictionary<string,ColumAttr>();

            this.ColumInfo.Add("Id", new ColumAttr { Name = "accid", IsPrim = true, Type = "char", ColLength = 32, IsForin = true, IsRequire = true,});
            this.ColumInfo.Add("EmailId", new ColumAttr { Name = "eid", IsPrim = true, Type = "char", ColLength = 32, IsForin = true, IsRequire = true});
            this.ColumInfo.Add("CreateTime", new ColumAttr { Name = "createtime", Type = "datetime", ColLength = 8, IsRequire = true, IsSort = true});
            this.ColumInfo.Add("IsRead", new ColumAttr { Name = "isread", Type = "char", ColLength = 1, IsRequire = true});
            this.ColumInfo.Add("IsEffc", new ColumAttr { Name = "state", Type = "char", ColLength = 1, IsRequire = true});

        }


        #region 作废

        //public int Add(List<Accepters> list)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    foreach (var item in list)
        //    {
        //        sb.Append("insert into emailfiles([accid],[eid],[createtime],[isread],[state]) values('");
        //        sb.Append(item.Id);
        //        sb.Append("','");
        //        sb.Append(item.EmailId);
        //        sb.Append("','");
        //        sb.Append(item.CreateTime);
        //        sb.Append("','");
        //        sb.Append(item.IsRead);
        //        sb.Append("','");
        //        sb.Append(item.IsEffc);
        //        sb.Append("'");
        //    }

        //    return DBUtility.SQLDbHelper.ExecuteSql(sb.ToString());
        //}

        //public int Update(Accepters model)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.Append("update emailfiles set [createtime]='");
        //    sb.Append(model.CreateTime);
        //    sb.Append("',[isread]='");
        //    sb.Append(model.IsRead);
        //    sb.Append("',[state]='");
        //    sb.Append(model.IsEffc);
        //    sb.Append("' where [accid]='");
        //    sb.Append(model.Id);
        //    sb.Append("' and [eid]='");
        //    sb.Append(model.EmailId);
        //    sb.Append("'");
          

        //    return DBUtility.SQLDbHelper.ExecuteSql(sb.ToString());
        //}

        //public int Delete(string emailid, string accepter)
        //{
        //    throw new NotImplementedException();
        //}

        //public Accepters GetAccepterModelInfoByaId(string emailid, string accepter)
        //{
        //    string SqlStr = string.Format("select * from  accepters where [accid]='{0}' and [eid]='{1}' and [state]='1'"
        //        ,accepter
        //        ,emailid);

        //    using (SqlDataReader sr = DBUtility.SQLDbHelper.ExecuteReader(SqlStr))
        //    {
        //        if (sr.Read())
        //        {
        //            return new Accepters
        //            {

        //                Id = sr.GetString(0),
        //                EmailId = sr.GetString(1),
        //                CreateTime = sr.GetDateTime(2),
        //                IsRead = sr.GetString(3),
        //                IsEffc = sr.GetString(4)
        //            };
        //        }
        //    }

        //    return null;
        //}

        //public IEnumerable<Accepters> GetAccepterModelInfoByaAcc(string accetper, int currentindex, int pagesize)
        //{
        //    string SqlStr = string.Format("select top {0} * from (select *, ROW_NUMBER() over(order by createTime) as ROW from accepters)accs where accs.ROW>{1} and [accid]='{2}' and [state]='1'"
        //        , pagesize
        //        , (currentindex - 1) * pagesize
        //        , accetper);

        //    List<Accepters> list = new List<Accepters>();

        //    using (SqlDataReader sr = DBUtility.SQLDbHelper.ExecuteReader(SqlStr))
        //    {

        //        while (sr.Read())
        //        {
        //            list.Add(new Accepters
        //            {
        //                Id = sr.GetString(0),
        //                EmailId = sr.GetString(1),
        //                CreateTime = sr.GetDateTime(2),
        //                IsRead = sr.GetString(3),
        //                IsEffc = sr.GetString(4)
        //            });
        //        }

        //        return list;
        //    }
        //}

        //public IEnumerable<Accepters> GetAccepterModelInfoByaAcc(string accetper, string isread, int currentindex, int pagesize)
        //{
        //    string SqlStr = string.Format("select top {0} * from (select *, ROW_NUMBER() over(order by createTime) as ROW from accepters)accs where accs.ROW>{1} and [accid]='{2}' and [state]='1' and [isread]='{2}'"
        //        , pagesize
        //        , (currentindex - 1) * pagesize
        //        , accetper
        //        , isread);

        //    List<Accepters> list = new List<Accepters>();

        //    using (SqlDataReader sr = DBUtility.SQLDbHelper.ExecuteReader(SqlStr))
        //    {

        //        while (sr.Read())
        //        {
        //            list.Add(new Accepters
        //            {
        //                Id = sr.GetString(0),
        //                EmailId = sr.GetString(1),
        //                CreateTime = sr.GetDateTime(2),
        //                IsRead = sr.GetString(3),
        //                IsEffc = sr.GetString(4)
        //            });
        //        }

        //        return list;
        //    }
        //}

        //public IEnumerable<Accepters> GetAccepterModelInfoByaAcc(IEnumerable<string> accetpers, string isread, int currentindex, int pagesize)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("select top ");
        //    sb.Append(pagesize);
        //    sb.Append(" * from (select *, ROW_NUMBER() over(order by createTime) as ROW from accepters)accs where accs.ROW>");
        //    sb.Append((currentindex - 1) * pagesize);
        //    sb.Append(" and [accid] in (");

        //    foreach (var s in accetpers)
        //    {
        //        sb.Append("'");
        //        sb.Append(s);
        //        sb.Append("',");
        //    }

        //    sb = sb.Remove(sb.Length - 1, 1);
        //    sb.Append(") and [state]='1' and [isread]='");
        //    sb.Append(isread);
        //    sb.Append("'");

        //    List<Accepters> list = new List<Accepters>();

        //    using (SqlDataReader sr = DBUtility.SQLDbHelper.ExecuteReader(sb.ToString()))
        //    {

        //        while (sr.Read())
        //        {
        //            list.Add(new Accepters
        //            {
        //                Id = sr.GetString(0),
        //                EmailId = sr.GetString(1),
        //                CreateTime = sr.GetDateTime(2),
        //                IsRead = sr.GetString(3),
        //                IsEffc = sr.GetString(4)
        //            });
        //        }

        //        return list;
        //    }

        #endregion


    }
}
