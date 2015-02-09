using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface IEmailFile : IRepository<EmailFiles>
    {
        #region 作废
        //int Add(List<EmailFiles> list);

        //int Update(List<EmailFiles> list);

        //int Delete(string fileid);

        //IEnumerable<EmailFiles> GetAccepterModelInfoByaEmail(string emailId);

        //IEnumerable<EmailFiles> GetAccepterModelInfoByaEmail(IEnumerable<string> emailIds);

        #endregion
    }
}
