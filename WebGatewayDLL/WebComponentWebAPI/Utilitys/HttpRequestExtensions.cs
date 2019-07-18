using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebComponentWebAPI.Utilitys
{
    public static class HttpRequestExtensions
    {
        public static async Task<string> GetRawBodyStringAsync(this HttpRequest request, Encoding encoding = null)
        {
            if (encoding is null)
                encoding = Encoding.UTF8;

            using (var reader = new StreamReader(request.Body, encoding))
                return await reader.ReadToEndAsync();
        }
        public static async Task<byte[]> GetRawBodyBytesAsync(this HttpRequest request)
        {
            using (var ms = new MemoryStream(2048))
            {
                await request.Body.CopyToAsync(ms);
                return ms.ToArray();
            }
        }
        #region 获取参数

        /// <summary>
        /// 获取request中的参数
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetKey(this HttpRequest request, string key)
        {
            if (request == null)
            {
                return null;
            }
            string text = request.Query[key].FirstOrDefault();
            if (text != null)
            {
                return WebHelper.unExcString(text);
            }
            if (request.Method.ToLower().Equals("post"))
            {
                text = request.Form[key].FirstOrDefault();
            }
            return (text != null) ? WebHelper.unExcString(text) : null;
        }
        /// <summary>
        /// 取得Int的Key
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetKeyInt(this HttpRequest request, string key)
        {
            string key2 = request.GetKey(key);
            if (key2 == null)
            {
                return 0;
            }
            int result;
            return int.TryParse(key2, out result) ? result : 0;
        }
        #endregion 获取参数



    }
}
