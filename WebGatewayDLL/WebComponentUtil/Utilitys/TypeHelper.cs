using System;
using System.Collections.Generic;
using System.Text;

namespace WebComponentUtil.Utilitys
{
    /// <summary>
    /// 数据类型传换等操作
    /// </summary>
    public static class TypeHelper
    {
        /// <summary>
        /// 将一个值转换为Int32类型(可以转Nullabled)
        /// </summary>
        /// <param name="turnObject"></param>
        /// <returns></returns>
        public static int IntConvert(object turnObject)
        {
            string value = turnObject?.ToString();
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            object obj = TypeConvert(turnObject, typeof(int));
            if (obj == null)
            {
                return 0;
            }
            return (int)obj;
        }
        /// <summary>
        /// 类型转换(可以转换Nullabled值)
        /// </summary>
        /// <param name="turnObject"></param>
        /// <param name="newType"></param>
        /// <returns></returns>
        public static object TypeConvert(object turnObject, Type newType)
        {
            if (turnObject != null)
            {
                if (newType.IsGenericType)
                {
                    newType = newType.GetGenericArguments()[0];
                }
                try
                {
                    return typeof(IConvertible).IsAssignableFrom(newType) ? Convert.ChangeType(turnObject, newType) : turnObject;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }
    }
}
