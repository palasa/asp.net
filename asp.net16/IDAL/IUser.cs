using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface IUser: IRepository<Users>
    {
        #region 过时

        //int Add(Users model);

        //int Update(Users model);

        //int Delete(string Id);

        //Users GetUserModelInfo(Users model);

        //Users GetUserModelInfoByName(string loginname);

        //IEnumerable<Users> GetUserModelInfoByName(string loginname,int pagesize);

        //Users GetUserModelInfoById(string key);

        //IEnumerable<Users> GetUserModelInfoById(IEnumerable<string> keys);

        //IEnumerable<Users> GetUserModelInfoByDate(DateTime d1, DateTime d2);

        #endregion

        

    }
}
