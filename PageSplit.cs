using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplication2
{
     /// <summary> 
    /// 表格对齐枚举 
    /// </summary> 
    public enum TbAlignEnum 
    { 
        Left = 1, 

        Center = 2, 

        Right = 3 
    } 

     /// <summary> 
    /// 分页模式 
    /// </summary> 
    public enum PagerModoule 
    { 
        /// <summary> 
        /// 普通分页模式 
        /// </summary> 
        Normal = 1, 

        /// <summary> 
        /// 统计分页模式 
        /// </summary> 
        Statistics = 2 
    }

    /// <summary> 
    /// 分页实用类 
    /// </summary> 
    public class PageSplit
    {
        #region common 

        private const string defaultAlign = "center";//默认对齐方式 
        private const string leftAlign = "left"; 
        private const string rightAlign = "right"; 

        /// <summary> 
        /// 获取页数 
        /// </summary> 
        /// <param name="objs">总记录数</param> 
        /// <param name="recordCountPerPage">每页记录数</param> 
        /// <returns></returns> 
        public static int GetPageCout(object[] objs, int recordCountPerPage) 
        { 
            return (int)Math.Ceiling(((double)objs.Length / (double)recordCountPerPage)); 
        } 

        /// <summary> 
        /// 获取页数 
        /// </summary> 
        /// <param name="totalCount">总记录数</param> 
        /// <param name="recordCountPerPage">每页记录数</param> 
        /// <returns></returns> 
        public static int GetPageCout(int totalCount, int recordCountPerPage) 
        { 
            int result = 0; 
            if (totalCount % recordCountPerPage == 0) 
            { 
            result = totalCount / recordCountPerPage; 
            } 
            else 
            { 
            result = totalCount / recordCountPerPage + 1; 
            } 
            return result; 
        } 

        #endregion 

        #region render pager 

        /// <summary> 
        /// 写分页页码(没有表格) 
        /// </summary> 
        /// <param name="pagerMode"></param> 
        /// <param name="baseString"></param> 
        /// <param name="totalCount">总记录数</param> 
        /// <param name="nowPage">当前页数</param> 
        /// <param name="recordCountPerPage">每页记录数</param> 
        public static string RenderPager(PagerModoule pagerMode,int totalCount, int nowPage, int recordCountPerPage, string baseString) 
        { 
            int pageCount = GetPageCout(totalCount, recordCountPerPage); 
            string pagerString = string.Empty; 
            if (pageCount > 0) 
            { 
                switch (pagerMode) 
                { 
                    case PagerModoule.Normal: 
                        pagerString = CreateLinkUrl(baseString, pageCount, nowPage, recordCountPerPage); 
                        break; 
                    case PagerModoule.Statistics: 
                        pagerString = CreateStatisticLinkUrl(baseString, totalCount, pageCount, nowPage, recordCountPerPage); 
                        break; 
                    default: 
                        pagerString = CreateLinkUrl(baseString, pageCount, nowPage, recordCountPerPage); 
                        break; 
                } 
                return pagerString; 
            }
            return null;
        } 

        /// <summary> 
        /// 写分页页码(有表格) 
        /// </summary> 
        /// <param name="pagerMode"></param> 
        /// <param name="alignEnum"></param> 
        /// <param name="response"></param> 
        /// <param name="baseString"></param> 
        /// <param name="totalCount">总记录数</param> 
        /// <param name="nowPage">当前页数</param> 
        /// <param name="recordCountPerPage">每页记录数</param> 
        public static string RenderTablePager(PagerModoule pagerMode, TbAlignEnum alignEnum, HttpResponse response, int totalCount, int nowPage, int recordCountPerPage, string baseString) 
        { 
            int pageCount = GetPageCout(totalCount, recordCountPerPage); 
            if (pageCount > 0) 
            { 
                string align = string.Empty; 
                switch (alignEnum) 
                { 
                    case TbAlignEnum.Left: 
                        align = leftAlign; 
                        break; 
                    case TbAlignEnum.Center: 
                        align = defaultAlign; 
                        break; 
                    case TbAlignEnum.Right: 
                        align = rightAlign; 
                        break; 
                    default: 
                        align = defaultAlign; 
                        break; 
                } 
                StringBuilder sbTable = new StringBuilder(); 
                sbTable.AppendFormat("<table><tr align='{0}'><td>", align); 
                string pagerString = string.Empty; 
                switch (pagerMode) 
                { 
                    case PagerModoule.Normal: 
                        pagerString = CreateLinkUrl(baseString, pageCount, nowPage, recordCountPerPage); 
                        break; 
                    case PagerModoule.Statistics: 
                        pagerString = CreateStatisticLinkUrl(baseString, totalCount, pageCount, nowPage, recordCountPerPage); 
                        break; 
                    default: 
                        pagerString = CreateLinkUrl(baseString, pageCount, nowPage, recordCountPerPage); 
                        break; 
                } 
                sbTable.Append(pagerString); 
                sbTable.Append("</td></tr></table>");
                return sbTable.ToString();
            }
            return null;
        } 

        #endregion 

        #region create link 

        /// <summary> 
        /// 生成分页字符串(显示页数和每页记录数相关) 
        /// </summary> 
        /// <param name="baseString"></param> 
        /// <param name="pageCount">页数</param> 
        /// <param name="nowPage">当前页数</param> 
        /// <param name="recordCountPerPage">每页记录数(推荐记录数：10)</param> 
        /// <returns></returns> 
        private static string CreateLinkUrl(string baseString, int pageCount, int nowPage, int recordCountPerPage) 
        { 
            StringBuilder sb = new StringBuilder(); 
            int from, to; 
            if (nowPage - recordCountPerPage > 0) 
            { 
                from = nowPage - recordCountPerPage; 
            } 
            else 
                from = 1; 
            if (pageCount == 0) 
                pageCount = 1; 
            if (pageCount - nowPage - recordCountPerPage > 0) 
            { 
                to = nowPage + recordCountPerPage; 
            } 
            else 
                to = pageCount; 

            if (baseString.IndexOf("?") == -1) 
                baseString += "?"; 
            else 
                baseString += "&"; 
                sb.Append(string.Format("<a href=\"{0}pageIndex=1\" >首页</a>", baseString)); 
            if (pageCount > 1 && nowPage > 1) 
            { 
                sb.AppendFormat("<a href=\"{0}pageIndex={1}\" >上一页</a>", baseString, (nowPage - 1).ToString()); 
            } 
            else 
            { 
                sb.Append("<a href='javascript:void(0);' style='color:gray;' >上一页</a>"); 
            } 
            for (int i = from; i <= to; i++) 
            { 
                if (i == nowPage) 
                { 
                sb.AppendFormat(" <a href='javascript:void(0);' style='color:red;' >{0}</a>", nowPage.ToString()); 
                } 
                else 
                { 
                    sb.AppendFormat(" <a href=\"{0}pageIndex={1}\" >{1}</a>", baseString, i); 
                } 
            } 
            if (pageCount > 1 && nowPage < pageCount) 
            { 
                sb.AppendFormat("<a href=\"{0}pageIndex={1}\" >下一页</a>", baseString, (nowPage + 1).ToString()); 
            } 
            else 
            { 
                sb.Append("<a href=\"javascript:void(0);\" style='color:gray;' >下一页</a>"); 
            } 
            sb.Append(string.Format(" <a href={0}pageIndex={1} >尾页</a>", baseString, pageCount)); 
            return sb.ToString(); 
        } 

        /// <summary> 
        /// 生成含统计信息的分页字符串(显示页数和每页记录数相关) 
        /// </summary> 
        /// <param name="baseString"></param> 
        /// <param name="totalCount">总记录数</param> 
        /// <param name="pageCount">页数</param> 
        /// <param name="nowPage">当前页数</param> 
        /// <param name="recordCountPerPage">每页记录数(推荐记录数：10)</param> 
        /// <returns></returns> 
        private static string CreateStatisticLinkUrl(string baseString, int totalCount, int pageCount, int nowPage, int recordCountPerPage) 
        { 
            StringBuilder sb = new StringBuilder(); 
            string numricPager = CreateLinkUrl(baseString, pageCount, nowPage, recordCountPerPage);//普通数字分页 
            sb.AppendFormat("总共<span style='color:red;'>{0}</span>条记录,共<span style='color:red;'>{1}</span>页,当前第<span style='color:red;'>{2}</span>页  ", 
            totalCount, pageCount, nowPage); 
            sb.Append(numricPager); 
            return sb.ToString(); 
        } 

        #endregion 

   }
}