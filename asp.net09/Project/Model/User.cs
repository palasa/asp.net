using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        public string Id { get; set; }

        public string LoginName { get; set; }

        public string LoginPwd { get; set; }

        public DateTime? CreateTime { get; set; }

        public char IsEffice { get; set; }
    }
}
