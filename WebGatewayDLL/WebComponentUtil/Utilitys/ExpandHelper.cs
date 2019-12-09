using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebComponentUtil.Utilitys
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

        /// <summary>
        /// 分割的字符串转成数值列表
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static List<int> ChangeToIntList(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new List<int>();
            }
            return value.ChangeToList().Select(TypeHelper.IntConvert).ToList();
        }

        /// <summary>
        /// 把用","分割的字符串转成列表
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static List<string> ChangeToList(this string value)
        {
            return value.ChangeToList(",");
        }
        /// <summary>
        /// 把分割的字符串转成列表
        /// </summary>
        /// <param name="value"></param>
        /// <param name="split"></param>
        /// <returns></returns>
        public static List<string> ChangeToList(this string value, string split)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new List<string>();
            }
            if (split.Length == 1)
            {
                return value.Split(split.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            string text = value.Replace(",", "#@#!#@!~");
            text = text.Replace(split, ",");
            List<string> source = text.ChangeToList();
            return (from e in source
                    select e.Replace("#@#!#@!~", ",")).ToList();
        }
    }
}
