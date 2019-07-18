using System;
using System.Collections.Generic;
using System.Text;

namespace WebComponentWebAPI.Utilitys
{
    /// <summary>
    /// 扩展使用类
    /// </summary>
    public static class ExpandHelper
    {
        /// <summary>
        /// 转换成INT
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt(this string value)
        {
            return value.Int();
        }

        /// <summary>
        /// 转换成INT
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Int(this object value)
        {
            return TypeHelper.IntConvert(value);
        }
    }
}
