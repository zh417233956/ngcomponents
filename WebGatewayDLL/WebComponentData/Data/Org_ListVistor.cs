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
    public class Org_ListVistor : IOrg_ListVistor
    {
        IWCFClientHelper _wcfClientHelper;

        public Org_ListVistor(IWCFClientHelper wcfClientHelper)
        {
            _wcfClientHelper = wcfClientHelper;
            org_ListClient = _wcfClientHelper.GetInterfaces<Org_List>("/User/v3.0/NetService/Org_ListService.svc");
            //org_ListClient = new WCFService<Org_List>("/User/v3.0/NetService/Org_ListService.svc");
        }
        private ISecondBaseInterface<Org_List> org_ListClient;
        private ISecondBaseInterface<Org_List> Org_ListClient
        {
            get
            {
                return org_ListClient;
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
        /// 通过分页、条件、排序查询数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        public DefaultResult<List<Org_List>> GetListByQuery(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders)
        {
            //调用wcf
            var wcfRet = Org_ListClient.GetListByQuery(page, pagesize, filters, orders, WcfOtherString);
            //进行数据解密
            var modelRet = (DefaultResult<List<Org_List>>)_wcfClientHelper.Decrypt_v2019(wcfRet, Config.WCFSecretkey, Config.WCFSecretiv);

            return modelRet;
        }
        /// <summary>
        /// 通过分页、条件、排序查询数据主键
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        public DefaultResult<List<int>> GetIdList(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders)
        {
            //调用wcf
            var wcfRet = Org_ListClient.GetIdList(page, pagesize, filters, orders, WcfOtherString);
            //进行数据解密
            var modelRet = (DefaultResult<List<int>>)_wcfClientHelper.Decrypt_v2019(wcfRet, Config.WCFSecretkey, Config.WCFSecretiv);

            return modelRet;
        }
    }
}
