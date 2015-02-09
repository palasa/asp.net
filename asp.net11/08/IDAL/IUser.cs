using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IUser
    {
        Model.Users GetUserModelInfo(Model.Users model);

        IList<Model.Users> GetUserModelListByName(string name);

        IList<Model.Users> GetUserModelListByID(string ID);

        int Add(Model.Users model);

        int Update(Model.Users model);

        int Delete(string ID);
    }
}
