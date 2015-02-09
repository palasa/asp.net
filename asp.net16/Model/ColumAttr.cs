using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ColumAttr
    {
        /// <summary>
        /// 字段名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 是否是主键
        /// </summary>
        public bool IsPrim { get; set; }
        /// <summary>
        /// 数据类型长度
        /// </summary>
        public int ColLength { get; set; }
        /// <summary>
        /// 是否允许空
        /// </summary>
        public bool IsRequire { get; set; }
        /// <summary>
        /// 是否是外键
        /// </summary>
        public bool IsForin { get; set; }
        /// <summary>
        /// 是否排序字段
        /// </summary>
        public bool IsSort { get; set; }
        /// <summary>
        /// 是否自增
        /// </summary>
        public bool IsIdentity { get; set; }
    }
}
