using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebComponentAPIGateway
{
    /// <summary>
    /// 组件请求数据帮助类
    /// </summary>
    public static class WebComponentHelper
    {
        /// <summary>
        /// 获取API数据
        /// </summary>
        /// <param name="Request">HTTP请求</param>
        /// <param name="Host">请求的主机地址</param>
        /// <param name="Path">API路径</param>
        /// <returns></returns>
        public static async Task<string> GetAPIData(this HttpRequest Request, string Host, string Path)
        {
            string result = "";
            string uuid = "";
            try
            {

                var PostData = new List<KeyValuePair<string, string>>();
                if (Request.Method.ToLower().Equals("post"))
                {
                    if (Request.ContentType == "application/json")
                    {
                        var formStr = HttpRequestExtensions.GetRawBodyStringAsync(Request).Result;
                        IEnumerable<JProperty> properties = JObject.Parse(formStr).Properties();

                        foreach (JProperty item in properties)
                        {
                            PostData.Add(new KeyValuePair<string, string>(item.Name, item.Value.ToString()));
                        }
                    }
                    else if (Request.Form != null)
                    {
                        foreach (var item in Request.Form)
                        {
                            PostData.Add(new KeyValuePair<string, string>(item.Key, item.Value));
                        }
                    }
                    //获取前端的uuid,方便记录日志进行追踪调试
                    if (PostData.Exists(m => m.Key.Equals("uuid")))
                    {
                        uuid = PostData.Find(m => m.Key.Equals("uuid")).Value;
                    }
                }
                else
                {
                    uuid = Request.Query["uuid"];
                    foreach (var item in Request.Query)
                    {
                        PostData.Add(new KeyValuePair<string, string>(item.Key, item.Value));
                    }
                }
                //uuid如果为空
                if (uuid == null)
                {
                    uuid = Guid.NewGuid().ToString();
                }
                await Task.Run(async () =>               
                {                 
                    StringBuilder buffer = new StringBuilder();
                    int i = 0;
                    foreach (var item in PostData)
                    {
                        if (i > 0)
                        {
                            buffer.AppendFormat("&{0}={1}", item.Key, item.Value);
                        }
                        else
                        {
                            buffer.AppendFormat("{0}={1}", item.Key, item.Value);
                        }
                        i++;
                    }
                    string cookidStr = "";
                    foreach (var item in Request.Cookies)
                    {
                        cookidStr += $"{item.Key}={item.Value};";
                    }
                    var header = new Dictionary<string, string>();
                    header.Add("Cookie", cookidStr);
                    //foreach (var item in Request.Headers)
                    //{
                    //    header.Add(item.Key, item.Value);
                    //}

                    result = await HttpClientHelper.HttpPostAsync(Host + Path, buffer.ToString(), "application/x-www-form-urlencoded", 100, header);

                });
            }
            catch (Exception ex)
            {
                //TODO:异常数据通过LTC进行记录
            }
            return result;
        }
    }
}
