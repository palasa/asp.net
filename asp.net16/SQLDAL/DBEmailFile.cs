using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;

namespace SQLDAL
{
    public class DBEmailFile :Repository<EmailFiles>, IDAL.IEmailFile
    {
        public DBEmailFile()
        {
            this.TableName = "";

            this.ColumInfo = new Dictionary<string, ColumAttr>();

            this.ColumInfo.Add("Id", new ColumAttr { Name = "Id", IsPrim = true, Type = "int", ColLength = 4, IsRequire = true, IsIdentity = true });
            this.ColumInfo.Add("ClientName", new ColumAttr { Name = "clientname", Type = "nvarchar", ColLength = 50, IsRequire = true });
            this.ColumInfo.Add("ServerName", new ColumAttr { Name = "servername", Type = "varchar", ColLength = 50, IsRequire = true });
            this.ColumInfo.Add("CreateTime", new ColumAttr { Name = "CreateTime", Type = "datetime", ColLength = 8, IsRequire = true, IsSort = true });
            this.ColumInfo.Add("EmailId", new ColumAttr { Name = "eid", Type = "char", ColLength = 32, IsRequire = true, IsForin = true });
            this.ColumInfo.Add("IsEffc", new ColumAttr { Name = "iseffc", Type = "char", ColLength = 1, IsRequire = true });
        }

        #region 作废

        //public int Add(List<Model.EmailFiles> list)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    foreach (var item in list)
        //    {
        //        sb.Append("insert into emailfiles([clientname],[servername],[createtime],[eid],[iseffc]) values('");
        //        sb.Append(item.ClientName);
        //        sb.Append("','");
        //        sb.Append(item.ServerName);
        //        sb.Append("','");
        //        sb.Append(item.CreateTime);
        //        sb.Append("','");
        //        sb.Append(item.EmailId);
        //        sb.Append("','");
        //        sb.Append(item.IsEffc);
        //        sb.Append("'");
        //    }

        //    return DBUtility.SQLDbHelper.ExecuteSql(sb.ToString());
        //}

        //public int Update(List<Model.EmailFiles> list)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    foreach (var item in list)
        //    {
        //        sb.Append("update emailfiles set [clientname]='");
        //        sb.Append(item.ClientName);
        //        sb.Append("',[servername]='");
        //        sb.Append(item.ServerName);
        //        sb.Append("',[createtime]='");
        //        sb.Append(item.CreateTime);
        //        sb.Append("',[iseffc]='");
        //        sb.Append(item.IsEffc);
        //        sb.Append("' where [eid]='");
        //        sb.Append(item.EmailId);
        //        sb.Append("'");
        //    }

        //    return DBUtility.SQLDbHelper.ExecuteSql(sb.ToString());
        //}

        //public int Delete(string fileid)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<EmailFiles> GetAccepterModelInfoByaEmail(string emailId)
        //{
        //    string SqlStr = string.Format("select * from emailfiles where eid='{0}'",emailId);

        //    List<EmailFiles> list = new List<EmailFiles>();

        //    using (SqlDataReader sr = DBUtility.SQLDbHelper.ExecuteReader(SqlStr))
        //    {
        //        while (sr.Read())
        //        {
        //            list.Add(new EmailFiles { 
                        
        //                Id=sr.GetInt32(0).ToString(),
        //                ClientName=sr.GetString(1),
        //                ServerName=sr.GetString(2),
        //                CreateTime=sr.GetDateTime(3),
        //                EmailId=sr.GetString(4),
        //                IsEffc=sr.GetString(5)

        //            });
        //        }
        //    }

        //    return list;
        //}

        //public IEnumerable<EmailFiles> GetAccepterModelInfoByaEmail(IEnumerable<string> emialIds)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("select * from emailfiles where [eid] in (");

        //    foreach (var s in emialIds)
        //    {
        //        sb.Append("'");
        //        sb.Append(s);
        //        sb.Append("',");
        //    }

        //    sb = sb.Remove(sb.Length - 1, 1);
        //    sb.Append(")");

        //    List<EmailFiles> list = new List<EmailFiles>();

        //    using (SqlDataReader sr = DBUtility.SQLDbHelper.ExecuteReader(sb.ToString()))
        //    {
        //        while (sr.Read())
        //        {
        //            list.Add(new EmailFiles
        //            {

        //                Id = sr.GetInt32(0).ToString(),
        //                ClientName = sr.GetString(1),
        //                ServerName = sr.GetString(2),
        //                CreateTime = sr.GetDateTime(3),
        //                EmailId = sr.GetString(4),
        //                IsEffc = sr.GetString(5)

        //            });
        //        }
        //    }

        //    return list;
        //}

        #endregion
    }
}
