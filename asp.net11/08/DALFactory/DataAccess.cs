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
        public static IDAL.IUser CreateUserInstance()
        {
            //这里是通过配置文件获取命名空间+类名
            string ClassNamespace = AssemblyPath + ".DBUser";
            //调用反射方法获取实例，并且强制类型转换成相应类型
            return (IDAL.IUser)CreateObject(AssemblyPath, ClassNamespace);

        }


    }
}
