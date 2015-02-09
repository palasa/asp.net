using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class BLUser
    {
        private readonly IDAL.IUser idal = DALFactory.DataAccess.CreateUser();

        public void CreateProductInfo()
        {
            idal.Add();
        }


    }
}
