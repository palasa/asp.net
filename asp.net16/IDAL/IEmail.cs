using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface IEmail : IRepository<Emails>
    {

        #region 作废

        //int Add(Emails model);

        //int Update(Emails model);

        //int Delete(string key);

        //int GetEmailModelInfoCountBySender(string Sender);

        //Emails GetEmailModelInfoById(string id);

        //IEnumerable<Emails> GetEmailModelInfoById(IEnumerable<string> keys);

        //IEnumerable<Emails> GetEmailModelInfoByTitle(string title,int currentindex,int pagesize);

        //IEnumerable<Emails> GetEmailModelInfoByDate(DateTime d1, DateTime d2, int currentindex, int pagesize);

        //IEnumerable<Emails> GetEmailModelInfoBySender(string Sender, int currentindex, int pagesize);

        #endregion


    }
}
