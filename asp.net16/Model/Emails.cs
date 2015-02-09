using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Emails : ModelBase
    {

        public string Title { get; set; }

        public string Content { get; set; }

        public string Sender { get; set; }

        public IEnumerable<EmailFiles> FileList { get; set; }

        public Users UserObj { get; set; }


    }
}
