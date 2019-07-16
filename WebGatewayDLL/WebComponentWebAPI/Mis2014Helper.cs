using log4net;
using Microsoft.AspNetCore.Http;
using WebComponentWebAPI.Configs;
using WebComponentWebAPI.Utilitys;
using WebComponentWebAPI.WCF;

namespace WebComponentWebAPI
{
    public class Mis2014Helper
    {
        private static readonly ILog _log = LogManager.GetLogger(ConfigManager.repository.Name, typeof(Mis2014Helper));

        /// <summary>
        /// 获取mis2014中的数据
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public string GetAPIData(HttpRequest Request)
        {
            string result = "";

            string postData = Request.GetRawBodyStringAsync().Result;

            _log.DebugFormat("HttpRequest==>Request:{0}", postData);

            //获取Mis2014的数据
            string apiUrl = "https://mis.517.cn/a10_common/a1020_selection/Actions/UserAction.ashx?action=user&pagename=noPageName&type=otherOrg&size=20&orgId=157&isShowDeleted=0&selectIds=&mastOrg=&isJJr=&ispowerorg=0";

            //TODO:需要实现mis2014获取数据
            //result = HttpClientHelper.HttpPost(apiUrl, "");

            result = "{\"data\":{\"data\":[{\"UserId\":59632,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"邵文\",\"orgid\":22,\"isjjr\":0,\"OrgName\":\"研发部\",\"mobile\":\"15840452469\",\"RzRuzhiDate\":\"2019-06-12\",\"isyunying\":false},{\"UserId\":55454,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"苑鹏掣\",\"orgid\":22,\"isjjr\":13,\"OrgName\":\"研发部\",\"mobile\":\"15604025257\",\"RzRuzhiDate\":\"2018-08-27\",\"isyunying\":false},{\"UserId\":58988,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"钟海\",\"orgid\":22,\"isjjr\":9,\"OrgName\":\"研发部\",\"mobile\":\"18802447663\",\"RzRuzhiDate\":\"2019-05-08\",\"isyunying\":false},{\"UserId\":12354,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"黄鑫\",\"orgid\":22,\"isjjr\":10,\"OrgName\":\"研发部\",\"mobile\":\"18698883789\",\"RzRuzhiDate\":\"2011-01-10\",\"isyunying\":false},{\"UserId\":57747,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"曲振林\",\"orgid\":22,\"isjjr\":13,\"OrgName\":\"研发部\",\"mobile\":\"15714010102\",\"RzRuzhiDate\":\"2019-02-25\",\"isyunying\":false},{\"UserId\":55967,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"侯福艳\",\"orgid\":22,\"isjjr\":9,\"OrgName\":\"研发部\",\"mobile\":\"13194200618\",\"RzRuzhiDate\":\"2018-09-17\",\"isyunying\":false},{\"UserId\":44434,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"南丙坤\",\"orgid\":22,\"isjjr\":9,\"OrgName\":\"研发部\",\"mobile\":\"15640440181\",\"RzRuzhiDate\":\"2017-04-10\",\"isyunying\":false},{\"UserId\":56599,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"魏秋实\",\"orgid\":22,\"isjjr\":9,\"OrgName\":\"研发部\",\"mobile\":\"13998272237\",\"RzRuzhiDate\":\"2018-10-22\",\"isyunying\":false},{\"UserId\":45848,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"王天\",\"orgid\":22,\"isjjr\":9,\"OrgName\":\"研发部\",\"mobile\":\"13591667022\",\"RzRuzhiDate\":\"2017-06-19\",\"isyunying\":false},{\"UserId\":45208,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"胡泽军\",\"orgid\":22,\"isjjr\":9,\"OrgName\":\"研发部\",\"mobile\":\"18604020570\",\"RzRuzhiDate\":\"2017-05-25\",\"isyunying\":false},{\"UserId\":22565,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"崔玮\",\"orgid\":22,\"isjjr\":9,\"OrgName\":\"研发部\",\"mobile\":\"13504944808\",\"RzRuzhiDate\":\"2014-04-07\",\"isyunying\":false},{\"UserId\":52525,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"苑琳琳\",\"orgid\":22,\"isjjr\":9,\"OrgName\":\"研发部\",\"mobile\":\"15524257001\",\"RzRuzhiDate\":\"2018-04-14\",\"isyunying\":false}],\"count\":12,\"msg\":\"\",\"history\":[59632,55454,58988,12354,57747,55967,44434,56599,45848,45208,22565,52525],\"changyong\":[58988,12354,45208,52525,22565,56599,45848,57747,55454,44434,55967,59632]},\"flag\":1,\"debug\":\"\"}";

            _log.DebugFormat("GetAPIData==>apiurl:{0}\r\nresult:{1}", apiUrl, result);

            return result;
        }
        public object GetWCFData()
        {
            string result = "";
            string apiUrl = "http://apicache200.517.dev:51707/User/v3.0/NetService/";

            return null;
        }

        public ISecondBaseInterface<MT> GetInterfaces<MT>(string url)
        {
            var address = new System.ServiceModel.EndpointAddress(url);
            var ws = new System.ServiceModel.BasicHttpBinding();
            ws.AllowCookies = true;
            ws.MaxReceivedMessageSize = 2147483647;
            ws.ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas();
            ws.ReaderQuotas.MaxArrayLength = int.MaxValue;
            ws.ReaderQuotas.MaxStringContentLength = int.MaxValue;
            ws.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
            if (url.ToLower().StartsWith("https://"))
            {
                ws.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                //ws.Security.Transport = new HttpTransportSecurity() { ClientCredentialType = HttpClientCredentialType.None };
            }

            var factory = new System.ServiceModel.ChannelFactory<ISecondBaseInterface<MT>>(ws, address);
            foreach (System.ServiceModel.Description.OperationDescription op in factory.Endpoint.Contract.Operations)
            {
                var dataContractBehavior = op.Behaviors.Find<System.ServiceModel.Description.DataContractSerializerOperationBehavior>();
                if (dataContractBehavior != null)
                {
                    dataContractBehavior.MaxItemsInObjectGraph = int.MaxValue;
                }
            }
            return factory.CreateChannel();

        }
    }
}
