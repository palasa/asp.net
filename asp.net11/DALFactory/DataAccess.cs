using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace DALFactory
{
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DataLayer"];

        #region 创建对象

        private static object CreateObject(string AssemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch//(System.Exception ex)
            {
                //string str=ex.Message;// 记录错误日志
                return null;
            }

        }

        #endregion

        /// <summary>
        /// 创建DataUser数据层接口
        /// </summary>
        /// <returns></returns>
        public static IDAL.IUser CreateUser()
        {

            string ClassNamespace = AssemblyPath + ".DBUser";
            return (IDAL.IUser)CreateObject(AssemblyPath, ClassNamespace);

        }


    }
}
