using System;
using System.Collections.Generic;
using System.Text;
using WebComponentData.Interface;
using WebComponentData.Models;
using WebComponentWebAPI.ConfigCenter;
using WebComponentWebAPI.WCF;
using WebComponentWebAPI.WCF.Models;
using WebComponentWebAPI.WCF.Post;

namespace WebComponentData.Data
{
    public class Pub_DictVistor : IPub_DictVistor
    {
        IWCFClientHelper _wcfClientHelper;

        public Pub_DictVistor(IWCFClientHelper wcfClientHelper)
        {
            _wcfClientHelper = wcfClientHelper;
            //pub_DictClient = _wcfClientHelper.GetInterfaces<Pub_Dict>("/User/v3.0/NetService/Pub_DictService.svc");
            pub_DictClient = new WCFService<Pub_Dict>("/User/v3.0/NetService/Pub_DictService.svc");
        }
        private IWCFService<Pub_Dict> pub_DictClient;
        private IWCFService<Pub_Dict> Pub_DictClient
        {
            get
            {
                return pub_DictClient;
            }
        }
        private string WcfOtherString
        {
            get
            {
                //加密方式
                var passkey = Config.WCFPasskey;
                //使用哪个加密的连接字符串
                var connkey = "new";
                return $"passkey$bc${passkey}$ac$debug$bc${IsDebug}$ac$connkey$bc${connkey}";
            }
        }
        private int isdebug = 1;
        /// <summary>
        /// 是否显示debug, 0不显示,1显示
        /// </summary>
        public int IsDebug
        {
            get { return isdebug; }
            set { isdebug = value; }
        }
        /// <summary>
        /// 通过指定ID获取字典列表
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DefaultResult<List<Pub_Dict>> GetListByClassId(int classId)
        {
            var filterList = new List<CommonFilterModel>();
            var orderby = new List<CommonOrderModel>() {
                    new CommonOrderModel(){ Name="DicID",Order=0 }
                };
            filterList.Add(new CommonFilterModel("DicClassID", "=", classId.ToString()));
            filterList.Add(new CommonFilterModel("isdel", "=", "0"));

            //调用wcf
            var wcfRet = Pub_DictClient.GetListByQuery(1, 50, filterList, orderby, WcfOtherString);
            //进行数据解密
            var modelRet = (DefaultResult<List<Pub_Dict>>)_wcfClientHelper.Decrypt_v2019(wcfRet, Config.WCFSecretkey, Config.WCFSecretiv);

            return modelRet;

        }
    }
}
