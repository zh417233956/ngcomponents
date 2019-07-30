using log4net;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
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
    public class CCHelper: ICCHelper
    {
        private readonly ILog _log = LogManager.GetLogger(ConfigManager.repository.Name, typeof(CCHelper));
        Config _config;
        public CCHelper(IOptions<Config> config)
        {
            //初始化连接参数            
            _config = config.Value;
            //获取WCF配置参数
            GetWcfConfig();

        }
        /// <summary>
        /// 获取配置参数
        /// </summary>
        /// <returns></returns>
        public Config GetConfig()
        {
            return _config;
        }
        /// <summary>
        /// 初始化WCF配置参数
        /// </summary>
        private void GetWcfConfig()
        {
            var SingleKey = GetSingleKey();
            _config.WCFSecretkey = GetConfig("wcf.config.conn.third.secretkey", SingleKey);
            _config.WCFSecretiv = GetConfig("wcf.config.conn.third.secretiv", SingleKey);
            _config.WCFPasskey = GetConfig("wcf.config.conn.third.passkey", SingleKey);
            if (string.IsNullOrEmpty(_config.WCFHost))
            {
                //TODO:需要从服务器拉取，暂时使用的固定值
                _config.WCFHost = GetConfig("wcf.config.conn.third.host", SingleKey);
            }
        }
        /// <summary>
        /// 获取CC通讯使用的singleKey
        /// </summary>
        /// <returns></returns>
        private string GetSingleKey()
        {
            string result = _config.SingleKey;

            if (!string.IsNullOrEmpty(result))
            {
                return result;
            }

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
            paramDictionary["companyKey"] = _config.CompanyKey;
            paramDictionary["compute"] = _config.Compute;
            paramDictionary["domain"] = _config.Domain;
            paramDictionary["localIp"] = _config.LocalIp;
            paramDictionary["localPort"] = _config.LocalPort.ToString();
            paramDictionary["projectKey"] = _config.ProjectKey;

            var queryString = SecretHelper.GetHaveSignatureQueryString(paramDictionary, _config.AccessKeyId, _config.AccessSecret);

            //地址栏参数中不提供?,需要添加
            var getKeyUrl = _config.ApiUrl + "/Api/SingleKey.aspx";
            var apiUrl = string.Format("{0}?{1}", getKeyUrl, queryString);
            //调用API
            var _res = HttpClientHelper.HttpGet(apiUrl);

            //记录日志
            _log.DebugFormat("GetSingleKey:{0}\r\nResult:{1}", apiUrl, _res);

            var resModel = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(_res, new { Status = "", Result = "", ErrorMessage = "" });
            if (resModel.Status == "success")
            {
                result = resModel.Result;
                //设置SingleKey
                _config.SingleKey = result;
            }
            else
            {
                throw new Exception(resModel.ErrorMessage);
            }

            return result;
        }
        /// <summary>
        /// 取得配置
        /// </summary>
        /// <param name="configKey"></param>
        /// <param name="singleKey"></param>
        /// <returns></returns>
        public string GetConfig(string configKey, string singleKey)
        {
            string result = "";
            var paramDict = new Dictionary<string, string>();
            paramDict["configKey"] = configKey;
            paramDict["singleKey"] = singleKey;
            paramDict["timeticks"] = DateTime.Now.Ticks.ToString();

            var queryString = SecretHelper.GetHaveSignatureQueryString(paramDict, _config.AccessKeyId, _config.AccessSecret);


            var getUrl = _config.ApiUrl + "/Api/Config.aspx";
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
