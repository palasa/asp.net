using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Linq.Expressions;
using System.Reflection;
using System.Data.SqlClient;
using DBUtility;


namespace SQLDAL
{
    public class Repository<TEntity> : IDAL.IRepository<TEntity> where TEntity: ModelBase,new()
    {
        /// <summary>
        /// 数据表名称
        /// </summary>
        protected string TableName;

        /// <summary>
        /// 存放数据表字段信息的字段
        /// </summary>
        protected IDictionary<string, ColumAttr> ColumInfo;

        private IDictionary<string, string[]> _idc;
        /// <summary>
        /// 存放真实数据的字典
        /// </summary>
        public IDictionary<string, string[]> DicValueCol { get { return _idc; } set { _idc = value; } }

        public Repository()
        {
            this.DicValueCol = new Dictionary<string, string[]>();
        }

        public virtual TEntity GetModelInfoByKeys(string[] keys)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select * from ");
            sb.Append(this.TableName);
            sb.Append(" where ");
            //找出主键字段，顺序对应keys的顺序
            IEnumerable<KeyValuePair<string,ColumAttr>> tempkey = this.ColumInfo.Where(c => c.Value.IsPrim);

            for (int i = 0; i < keys.Count(); i++)
            {
                sb.Append("[");
                sb.Append(tempkey.ElementAt(i).Value.Name);
                sb.Append("]='");
                sb.Append(keys.ElementAt(i));
                sb.Append("' and");
            }

            sb = sb.Remove(sb.Length - "and".Length, "and".Length);

            TEntity t = new TEntity();

            PropertyInfo[] proarr = t.GetType().GetProperties().Where(p => this.ColumInfo.Where(c => c.Key == p.Name).Count()>0).ToArray();

            using (SqlDataReader sr = SQLDbHelper.ExecuteReader(sb.ToString()))
            {
                if (sr.Read())
                {
                    foreach (var item in proarr)
                    {
                        item.SetValue(t, sr[this.ColumInfo[item.Name].Name],null);
                    }

                    return t;
                }
            }

            return null;

        }

        public virtual int GetModelInfoListCount(Expression<Func<TEntity, bool>> exp)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select count(*) from ");
            sb.Append(this.TableName);
            sb.Append(" where ");
            sb.Append(GetWhereStr(exp));
            return (int)SQLDbHelper.GetSingle(sb.ToString());
        }

        public IList<TEntity> GetModelInfoList(Expression<Func<TEntity, bool>> exp)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from ");
            sb.Append(this.TableName);
            sb.Append(" where ");
            sb.Append(GetWhereStr(exp));
            sb.Append(" order by ");
            sb.Append(this.ColumInfo.Single(c => c.Value.IsSort).Value.Name);
            sb.Append(" desc");

            List<TEntity> list = new List<TEntity>();

            using (SqlDataReader sr = SQLDbHelper.ExecuteReader(sb.ToString()))
            {
                while (sr.Read())
                {
                    TEntity t = new TEntity();

                    PropertyInfo[] proarr = t.GetType().GetProperties().Where(p => this.ColumInfo.Where(c => c.Key == p.Name).Count() > 0).ToArray();

                    foreach (var item in proarr)
                    {
                        item.SetValue(t, sr[this.ColumInfo[item.Name].Name], null);
                    }

                    list.Add(t);
                }
            }

            return list;
        }

        public virtual IList<TEntity> GetModelInfoList(Expression<Func<TEntity, bool>> exp,int pageszie, int currentindex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select top ");
            sb.Append(pageszie);
            sb.Append(" * from (select *, row_number() over(order by [");
            sb.Append(this.ColumInfo.First(c => c.Value.IsSort).Value.Name);
            sb.Append("] desc) as ROW from ");
            sb.Append(this.TableName);
            sb.Append(")tempdb where tempdb.ROW>");
            sb.Append((currentindex - 1) * pageszie);
            sb.Append(" and ");
            sb.Append(GetWhereStr(exp));
            sb.Append(" order by ");
            sb.Append(this.ColumInfo.Single(c => c.Value.IsSort).Value.Name);
            sb.Append(" desc");

            List<TEntity> list = new List<TEntity>();

            using (SqlDataReader sr = SQLDbHelper.ExecuteReader(sb.ToString()))
            {
                while (sr.Read())
                {
                    TEntity t = new TEntity();

                    PropertyInfo[] proarr = t.GetType().GetProperties().Where(p => this.ColumInfo.Where(c => c.Key == p.Name).Count() > 0).ToArray();

                    foreach (var item in proarr)
                    {
                        item.SetValue(t, sr[this.ColumInfo[item.Name].Name], null);
                    }

                    list.Add(t);
                }
            }

            return list;
        }

        public virtual int Add(TEntity entity)
        {
            //剔除自增列
            IEnumerable<KeyValuePair<string,ColumAttr>> templist = this.ColumInfo.Where(c => !c.Value.IsIdentity);

            //如果传进来的是User 是八个属性
            IEnumerable<PropertyInfo> prolist = entity.GetType().GetProperties().ToList();

            StringBuilder sb = new StringBuilder();
            sb.Append("insert into ");
            sb.Append(this.TableName);
            sb.Append(" (");
            foreach (var item in templist)
            {
                sb.Append("[");
                sb.Append(item.Value.Name);
                sb.Append("],");
            }

            sb = sb.Remove(sb.Length - 1, 1);
            sb.Append(") values(");
            //循环的目标是字段列表 Id ,LoginName,LoginPwd ,RealName HeadImage CreateTime IsEffc
            //实体类属性列表 Prolist  LoginName,RealName ,HeadImgae IsEffc ,Id
            foreach (var item in templist)
            {
                sb.Append("'");
                //获取entity里面属性的值
                sb.Append(prolist.First(p => p.Name == item.Key).GetValue(entity, null));
                sb.Append("',");
            }
            sb = sb.Remove(sb.Length-1,1);
            sb.Append(")");

            return SQLDbHelper.ExecuteSql(sb.ToString());
        }

        public virtual int Update(TEntity entity)
        {
            //剔除主键列
            IEnumerable<KeyValuePair<string, ColumAttr>> templist = this.ColumInfo.Where(c => !c.Value.IsPrim);
            //得到主键列
            IEnumerable<KeyValuePair<string, ColumAttr>> keylist = this.ColumInfo.Where(c => c.Value.IsPrim);

            IEnumerable<PropertyInfo> proarray = entity.GetType().GetProperties();

            StringBuilder sb = new StringBuilder();

            sb.Append("update ");
            sb.Append(this.TableName);
            sb.Append(" set ");

            foreach (var item in templist)
            {
                sb.Append("[");
                sb.Append(item.Value.Name);
                sb.Append("]='");
                sb.Append(proarray.First(p=>p.Name==item.Key).GetValue(entity,null));
                sb.Append("',");
            }

            sb = sb.Remove(sb.Length - 1, 1);
            sb.Append(" where ");

            foreach (var item in keylist)
            {
                sb.Append("[");
                sb.Append(item.Value.Name);
                sb.Append("]='");
                sb.Append(proarray.First(p => p.Name == item.Key).GetValue(entity, null));
                sb.Append("',");
            }

            sb = sb.Remove(sb.Length - 1, 1);

            return SQLDbHelper.ExecuteSql(sb.ToString());
        }

        public virtual int Delete(string[] keys)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("delete ");
            sb.Append(this.TableName);
            sb.Append(" where ");
            //找出主键字段，顺序对应keys的顺序
            IEnumerable<KeyValuePair<string, ColumAttr>> tempkey = this.ColumInfo.Where(c => c.Value.IsPrim);

            for (int i = 0; i < keys.Count(); i++)
            {
                sb.Append("[");
                sb.Append(tempkey.ElementAt(i).Value.Name);
                sb.Append("]='");
                sb.Append(keys.ElementAt(i));
                sb.Append("' and");
            }

            sb = sb.Remove(sb.Length - "and".Length, "and".Length);

            return SQLDbHelper.ExecuteSql(sb.ToString());
        }

        public virtual int Delete(Expression<Func<TEntity, bool>> exp)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("delete ");
            sb.Append(this.TableName);
            sb.Append(" where ");
            sb.Append(GetWhereStr(exp));

            return SQLDbHelper.ExecuteSql(sb.ToString());
        }

        protected virtual string GetStr(string[] value)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in value)
            {
                sb.Append("'");
                sb.Append(item);
                sb.Append("',");
            }

            return sb.Remove(sb.Length - 1, 1).ToString();
        }

        protected virtual string GetWhereStr(Expression<Func<TEntity, bool>> exp)
        {
            TEntity tn = new TEntity();
            tn.Where(exp);

            StringBuilder tempsb = new StringBuilder();
            tempsb.Append(tn.WhereStr);
            //把实体类字段替换成数据库字段
            foreach (var item in this.ColumInfo)
                tempsb = tempsb.Replace(item.Key, "[" + item.Value.Name + "]");
            //把标志字符替换成真实数据
            foreach (var item in this.DicValueCol)
                tempsb = tempsb.Replace(item.Key, string.Join("','", this.GetStr(item.Value)));
            
            return tempsb.ToString();
        }

    }
}
