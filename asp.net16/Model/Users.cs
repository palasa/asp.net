using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Users : ModelBase
    {

        public string LoginName { get; set; }

        public string LoginPwd { get; set; }

        public string RealName { get; set; }

        public string HeadImage { get; set; }

        public IEnumerable<Emails> EmailList { get; set; }



        
    }
}
