using System;
using System.Collections.Generic;
using System.Text;
using WebComponentData.Interface;
using WebComponentData.Models;
using WebComponentWebAPI.ConfigCenter;
using WebComponentWebAPI.WCF;
using WebComponentWebAPI.WCF.Models;

namespace WebComponentData.Data
{
    public class Pub_DicExtendItemVistor : IPub_DicExtendItemVistor
    {

        IWCFClientHelper _wcfClientHelper;

        public Pub_DicExtendItemVistor(IWCFClientHelper wcfClientHelper)
        {
            _wcfClientHelper = wcfClientHelper;
            pub_DicExtendItemClient = _wcfClientHelper.GetInterfaces<Pub_DicExtendItem>("/User/v3.0/NetService/Pub_DicExtendItemService.svc");
        }
        private ISecondBaseInterface<Pub_DicExtendItem> pub_DicExtendItemClient;
        private ISecondBaseInterface<Pub_DicExtendItem> Pub_DicExtendItemClient
        {
            get
            {
                return pub_DicExtendItemClient;
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
        /// 获取扩展的字典项
        /// </summary>
        /// <param name="extendKey">扩展索引名</param>
        /// <param name="structKey">结构索引StructName</param>
        /// <returns></returns>
        public DefaultResult<List<Pub_DicExtendItem>> GetItemWithOutIsdel(string extendKey, string structKey)
        {
            var filterList = new List<CommonFilterModel>();
            var orderby = new List<CommonOrderModel>() {
                    new CommonOrderModel(){ Name="ItemId",Order=0 }
                };
            filterList.Add(new CommonFilterModel("ExtendKey", "=", extendKey));
            filterList.Add(new CommonFilterModel("StructKey", "=", structKey));
            filterList.Add(new CommonFilterModel("isdel", "=", "0"));

            //调用wcf
            var wcfRet = Pub_DicExtendItemClient.GetListByQuery(1, 50, filterList, orderby, WcfOtherString);
            //进行数据解密
            var modelRet = (DefaultResult<List<Pub_DicExtendItem>>)_wcfClientHelper.Decrypt_v2019(wcfRet, Config.WCFSecretkey, Config.WCFSecretiv);

            return modelRet;
        }
    }
}
