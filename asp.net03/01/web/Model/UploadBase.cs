using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Model
{
    public class UploadBase
    {
        public string FileClientName { get; set; }

        public string FileServerName { get; set; }

        public string Url { get; set; }

        public int Size { get; set; }

        public string Message { get; set; }

        public bool IsSuccess { get; set; }
    }
}