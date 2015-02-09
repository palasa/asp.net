using System;
using System.Collections.Generic;
using Model;                            
using System.Linq;
using System.Linq.Expressions;

namespace IDAL
{
    public interface IRepository<TEntity> where TEntity : ModelBase,new()
    {
        IDictionary<string, string[]> DicValueCol { get; set; }

        TEntity GetModelInfoByKeys(string[] keys);

        int GetModelInfoListCount(Expression<Func<TEntity, bool>> exp);

        IList<TEntity> GetModelInfoList(Expression<Func<TEntity, bool>> exp);

        IList<TEntity> GetModelInfoList(Expression<Func<TEntity, bool>> exp,int pagesize,int currentindex);

        int Add(TEntity entity);

        int Update(TEntity entity);

        int Delete(string[] keys);

        int Delete(Expression<Func<TEntity, bool>> exp);
    }
}
