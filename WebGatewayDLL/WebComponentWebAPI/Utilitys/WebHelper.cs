using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WebComponentWebAPI.Utilitys
{
    /// <summary>
    /// 站点WEB帮助函数
    /// </summary>
    public class WebHelper
    {
        #region 帮助类   
        /// <summary>
        /// 解码操作
        /// </summary>
        /// <param name="instring">解码字符串</param>
        /// <returns></returns>
        public static string unExcString(string instring)
        {
            return HttpUtility.UrlDecode(HttpUtility.UrlDecode(instring));
        }
                  
        /// <summary>
        /// 解码操作
        /// </summary>
        /// <param name="instring">加密字符串</param>
        /// <returns></returns>
        public static string ExcString(string instring)
        {
            //return HttpUtility.UrlEncodeUnicode(instring);
            return HttpUtility.UrlEncode(instring);
        }    
        #endregion
    }
}
