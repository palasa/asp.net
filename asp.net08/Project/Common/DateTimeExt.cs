using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class DateTimeExt
    {
        static object sync = new object();

        static DateTimeExt _instance;

        public static DateTimeExt Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new DateTimeExt();
                        }
                    }
                }
                return _instance;
            }
        }


        /// <summary>
        /// 计算两个日期的时间间隔
        /// </summary>
        /// <param name="DateTime1">第一个日期和时间</param>
        /// <param name="DateTime2">第二个日期和时间</param>
        /// <returns></returns>
        public string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            StringBuilder dateDiff = new StringBuilder();

            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            if (ts.Days > 0)
            { dateDiff.AppendFormat("{0}天",ts.Days); }
            if (ts.Hours > 0)
            { dateDiff.AppendFormat(" {0}小时", ts.Hours); }
            if (ts.Minutes > 0)
            { dateDiff.AppendFormat(" {0}分钟", ts.Minutes); }

            dateDiff.Append("前");
            return dateDiff.ToString();
        }
    }
}
