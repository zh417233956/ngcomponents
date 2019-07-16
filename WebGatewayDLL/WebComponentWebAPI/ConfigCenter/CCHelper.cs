using log4net;
using System;
using System.Collections.Generic;
using System.Text;
using WebComponentWebAPI.Configs;
using WebComponentWebAPI.Utilitys;

namespace WebComponentWebAPI.ConfigCenter
{
    /// <summary>
    /// ConfigCenter帮助类
    /// IV:wcf.config.conn.third.secretiv
    /// KEY:wcf.config.conn.third.secretkey
    /// PassKey:wcf.config.conn.third.passkey
    /// </summary>
    public class CCHelper
    {
        private static readonly ILog _log = LogManager.GetLogger(ConfigManager.repository.Name, typeof(CCHelper));
        /// <summary>
        /// 获取CC通讯使用的singleKey
        /// </summary>
        /// <returns></returns>
        public static string GetSingleKey()
        {
            string result = "";

            /*
            companyKey	站点所属公司	zy
            compute	站点所在机器名	SERVER7
            domain	站点所在机器名域名	517IDC
            localIp	站点提供的局域网访问IP	192.168.112.7
            localPort	站点提供的局域网访问端口号	8301
            projectKey	站点在跑的是哪个项目	mis2014
             * 
             */
            var paramDictionary = new Dictionary<string, string>();
            paramDictionary["companyKey"] = Config.CompanyKey;
            paramDictionary["compute"] = Config.Compute;
            paramDictionary["domain"] = Config.Domain;
            paramDictionary["localIp"] = Config.LocalIp;
            paramDictionary["localPort"] = Config.LocalPort.ToString();
            paramDictionary["projectKey"] = Config.ProjectKey;

            var queryString = SecretHelper.GetHaveSignatureQueryString(paramDictionary, Config.AccessKeyId, Config.AccessSecret);

            //地址栏参数中不提供?,需要添加
            var getKeyUrl = Config.ApiUrl + "/Api/SingleKey.aspx";
            var apiUrl = string.Format("{0}?{1}", getKeyUrl, queryString);
            //调用API
            var _res = HttpClientHelper.HttpGet(apiUrl);

            //记录日志
            _log.DebugFormat("GetSingleKey:{0}\r\nResult:{1}", apiUrl, _res);

            var resModel = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(_res, new { Status = "", Result = "", ErrorMessage = "" });
            if (resModel.Status == "success")
            {
                result = resModel.Result;
            }
            else
            {
                throw new Exception(resModel.ErrorMessage);
            }

            return result;
        }

        public static string GetConfig(string configKey, string singleKey)
        {
            string result = "";
            var paramDict = new Dictionary<string, string>();
            paramDict["configKey"] = configKey;
            paramDict["singleKey"] = singleKey;
            paramDict["timeticks"] = DateTime.Now.Ticks.ToString();

            var queryString = SecretHelper.GetHaveSignatureQueryString(paramDict, Config.AccessKeyId, Config.AccessSecret);


            var getUrl = Config.ApiUrl + "/Api/Config.aspx";
            var apiUrl = string.Format("{0}?{1}", getUrl, queryString);

            //调用API
            var _res = HttpClientHelper.HttpGet(apiUrl);

            //记录日志
            _log.DebugFormat("GetConfig:{0}\r\nResult:{1}", apiUrl, _res);

            var resModel = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(_res, new { Status = "", Result = "", ErrorMessage = "" });
            if (resModel.Status == "success")
            {
                result = resModel.Result;
            }
            else
            {
                throw new Exception(resModel.ErrorMessage);
            }

            return result;
        }

    }
}
