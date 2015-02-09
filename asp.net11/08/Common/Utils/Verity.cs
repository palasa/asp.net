using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Verity
    {
        /// <summary>
        /// 验证Email格式是否合法
        /// </summary>
        public static bool CheckEmail(string email)
        {
            string patternemail = "[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

            System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(patternemail);
            return re.IsMatch(email);
        }
    }
}
