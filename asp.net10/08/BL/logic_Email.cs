using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class logic_Email
    {
        public void WriteEmail(
            string title,
            string content,
            string[] accepters,
            string sender,
            string[] clientnames,
            string[] servernames)
        { 
            //提交方式  只接受post
            if (!Common.RequestHelper.IsPost())
                return;

            //验证各种参数

            //

            string Eid = Guid.NewGuid().ToString().Replace("-", string.Empty);

            //填充邮件实体

            
            //填充收件人实体

        }
    }
}
