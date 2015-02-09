using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Common
{
    public class ResponseHelper
    {
        public static HttpResponse response
        {
            get
            {
                return HttpContext.Current.Response;
            }
        }
    }
}
