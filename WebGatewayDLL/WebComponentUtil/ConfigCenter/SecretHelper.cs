using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebComponentUtil.ConfigCenter
{
    /// <summary>
    /// 加密帮助类
    /// </summary>
    public class SecretHelper
    {
        /// <summary>
        /// 取得用于验证的QueryString字符串,返回结果没有最开始的问号
        /// </summary>
        /// <param name="urlParams">参数</param>
        /// <param name="accessKeyId">公钥</param>
        /// <param name="secretKey">私钥</param>
        /// <returns>返回不带?的条件字符串</returns>
        public static string GetHaveSignatureQueryString(Dictionary<string, string> urlParams, string accessKeyId, string secretKey)
        {
            string oldAccessKeyId;
            if (!urlParams.TryGetValue("AccessKeyId", out oldAccessKeyId))
            {
                urlParams["AccessKeyId"] = accessKeyId;
            }
            var sortedQueryString = GetSortedQueryString(urlParams);
            var sign = SignCompute(secretKey + "&", "GET&" + SpecialUrlEncode("/") + "&" + SpecialUrlEncode(sortedQueryString));
            var currentSignature = SpecialUrlEncode(sign);
            return $"Signature={currentSignature}&{sortedQueryString}";
        }
        /// <summary>
        /// 取得排序后的地址栏参数
        /// </summary>
        /// <param name="urlParams"></param>
        /// <returns></returns>
        private static string GetSortedQueryString(Dictionary<string, string> urlParams)
        {
            var sortList = urlParams.Keys.ToList();
            sortList.Sort(string.CompareOrdinal);
            return string.Join("&", sortList.Where(p => urlParams[p] != null).Select(p => SpecialUrlEncode(p) + "=" + SpecialUrlEncode(urlParams[p])));
        }

        private static string SignCompute(string accessSecret, string stringToSign)
        {
            var hmacsha1 = new System.Security.Cryptography.HMACSHA1 { Key = Encoding.UTF8.GetBytes(accessSecret) };
            var dataBuffer = Encoding.UTF8.GetBytes(stringToSign);
            var hashBytes = hmacsha1.ComputeHash(dataBuffer);
            return Convert.ToBase64String(hashBytes);
        }
        /// <summary>
        /// 进行UrlEncode.传递前需要编码
        /// </summary>
        /// <param name="v">要传递的字符串</param>
        /// <returns></returns>
        private static string SpecialUrlEncode(string v)
        {
            if (string.IsNullOrWhiteSpace(v)) return v;
            var str = HttpUtility.UrlEncode(v, Encoding.UTF8).Replace("+", "%20").Replace("*", "%2A").Replace("%7E", "~");
            var index = 0;
            while ((index = str.IndexOf("%", index, StringComparison.Ordinal)) > -1)
            {
                index++;
                var str1 = str.Substring(0, index);
                var str2 = str.Substring(index, 2).ToUpper();
                var str3 = str.Substring(index + 2);
                str = str1 + str2 + str3;
            }
            return str;
        }
    }
}
