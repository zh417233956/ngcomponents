using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace WebComponentWebAPI.Utilitys
{
    public class HttpClientHelper
    {
        public static string GetPostData(string Url, string cookStr, Dictionary<string, string> header, string postDataStr)
        {
            try
            {
                string reslut = "";
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Url);

                if (Url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) =>
                    {
                        return true; //总是接受  
                    });
                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                }

                request.Accept = "application/json, text/javascript, */*; q=0.01";
                request.Method = "Post";
                request.ContentType = "application/x-www-form-urlencoded";

                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.110 Safari/537.36";
                request.Headers.Add("X-Requested-With", "XMLHttpRequest");

                if (header.ContainsKey("Host"))
                {
                    request.Host = header["Host"];
                }
                foreach (var item in header)
                {
                    if (item.Key != "Host")
                    {
                        request.Headers.Add(item.Key, item.Value);
                    }
                }

                request.Headers.Add("Cookie", cookStr);

                Encoding encoding = Encoding.UTF8;//根据网站的编码自定义
                byte[] postData = encoding.GetBytes(postDataStr);//postDataStr即为发送的数据
                request.ContentLength = postData.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(postData, 0, postData.Length);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                reslut = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                return reslut;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static string GetData(string Url, string cookStr, Dictionary<string, string> header, Encoding encode = null)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Url);

                request.Accept = "application/json, text/plain, */*";
                request.Method = "get";
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.110 Safari/537.36";
                request.Headers.Add("X-Requested-With", "XMLHttpRequest");

                if (header.ContainsKey("Host"))
                {
                    request.Host = header["Host"];
                }
                foreach (var item in header)
                {
                    if (item.Key != "Host")
                    {
                        request.Headers.Add(item.Key, item.Value);
                    }
                }

                request.Headers.Add("Cookie", cookStr);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                if (encode == null)
                {
                    encode = Encoding.GetEncoding("utf-8");
                }
                StreamReader myStreamReader = new StreamReader(myResponseStream, encode);
                string retString = myStreamReader.ReadToEnd().Replace("\r", "").Replace("\n", "").Replace("  ", "");
                myStreamReader.Close();
                myResponseStream.Close();
                return retString;
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// 发送post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="paraUrlCoded"></param>
        /// <returns>返回格式{"errcode":0,"errmsg":"ok"}</returns>
        public static string HttpPost(string url, string paraUrlCoded)
        {
            string strURL = url;
            System.Net.HttpWebRequest request;
            request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(strURL);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";

            byte[] payload;
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            request.ContentLength = payload.Length;
            System.IO.Stream writer = request.GetRequestStream();
            writer.Write(payload, 0, payload.Length);
            writer.Close();
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s;
            s = response.GetResponseStream();
            string strValue = "";
            System.IO.StreamReader Reader = new System.IO.StreamReader(s, System.Text.Encoding.UTF8);

            strValue = Reader.ReadToEnd();
            Reader.Close();
            s.Close();

            return strValue;
        }
    }
}
