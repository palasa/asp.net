using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class FileModel
    {
        /// <summary>
        /// 客户端文件名
        /// </summary>
        public string FileClientName { get; set; }
        /// <summary>
        /// 服务器文件名
        /// </summary>
        public string FileServerName { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public int FileSize { get; set; }
        /// <summary>
        /// 文件状态
        /// </summary>
        public bool FileState { get; set; }
        /// <summary>
        /// 文件消息
        /// </summary>
        public string FileMessage { get; set; }
        /// <summary>
        /// 文件创建时间
        /// </summary>
        public DateTime FileCreateTime { get; set; }
    }
}