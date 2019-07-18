using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
                }
                //uuid如果为空
                if (uuid == null)
                {
                    uuid = Guid.NewGuid().ToString();
                }
                await Task.Run(async () =>
                //await Task.Run(() =>
                {
                    var requsetData = new { Cookies = Request.Cookies, Header = Request.Headers, Method = Request.Method, QueryString = Request.Query, PostData = PostData };
                    var param = Newtonsoft.Json.JsonConvert.SerializeObject(requsetData);
                    //进行请求转发，通过微服务API获取真正的组件数据
                    result = await HttpClientHelper.HttpPostAsync(Host + Path, param, "application/json");
                });
            }
            catch (Exception)
            {
                //TODO:异常数据通过LTC进行记录
            }
            return result;
        }
    }
}
