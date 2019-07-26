using log4net;
using System;
using System.Collections.Generic;
using System.Text;
using WebComponentData.Interface;
using WebComponentData.Models;
using WebComponentWebAPI.ConfigCenter;
using WebComponentWebAPI.Configs;
using WebComponentWebAPI.WCF;
using WebComponentWebAPI.WCF.Models;

namespace WebComponentData.Data
{
    public class User_listVistor : IUser_listVistor
    {
        DateTime dt1 = DateTime.Now;
        private static readonly ILog _log = LogManager.GetLogger(ConfigManager.repository.Name, typeof(User_listVistor));
        IWCFClientHelper _wcfClientHelper;

        public User_listVistor(IWCFClientHelper wcfClientHelper)
        {
            _wcfClientHelper = wcfClientHelper;
            user_listClient = _wcfClientHelper.GetInterfaces<User_list>("/User/v3.0/NetService/User_listService.svc");
            _log.DebugFormat("User_listVistor:Init:{0}ms", (DateTime.Now - dt1).TotalMilliseconds);
        }
        private ISecondBaseInterface<User_list> user_listClient;
        private ISecondBaseInterface<User_list> User_listClient
        {
            get
            {
                return user_listClient;
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
        /// 取得实体的接口
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public DefaultResult<User_list> GetModelByID(int entityId)
        {
            //调用wcf
            var wcfRet = User_listClient.GetModelByID(entityId, WcfOtherString);
            //进行数据解密
            var modelRet = (DefaultResult<User_list>)_wcfClientHelper.Decrypt_v2019(wcfRet, Config.WCFSecretkey, Config.WCFSecretiv);

            return modelRet;
        }
        /// <summary>
        /// 通过指定的ids获取实例列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public DefaultResult<List<User_list>> GetModelByIds(List<int> idList)
        {
            //调用wcf
            var wcfRet = User_listClient.GetModelByIDS(idList, WcfOtherString);
            //进行数据解密
            var modelRet = (DefaultResult<List<User_list>>)_wcfClientHelper.Decrypt_v2019(wcfRet, Config.WCFSecretkey, Config.WCFSecretiv);
            return modelRet;
        }
        /// <summary>
        /// 通过分页、条件、排序查询数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        public DefaultResult<List<User_list>> GetListByQuery(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders)
        {
            //调用wcf
            var wcfRet = User_listClient.GetListByQuery(page, pagesize, filters, orders, WcfOtherString);
            //进行数据解密
            var modelRet = (DefaultResult<List<User_list>>)_wcfClientHelper.Decrypt_v2019(wcfRet, Config.WCFSecretkey, Config.WCFSecretiv);

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
        public DefaultResult<List<int>> GetIdListLock(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders)
        {
            var dt1 = DateTime.Now;
            //调用wcf
            var wcfRet = User_listClient.GetIdListLock(page, pagesize, filters, orders, WcfOtherString);
            var dt2 = DateTime.Now;
            //进行数据解密
            var modelRet = (DefaultResult<List<int>>)_wcfClientHelper.Decrypt_v2019(wcfRet, Config.WCFSecretkey, Config.WCFSecretiv);
            var dt3 = DateTime.Now;
            _log.DebugFormat("GetUserList:InitData_wcf_get:{0}ms|Dedata:{1}ms|wcf_RunTime:{2}ms", (dt2 - dt1).TotalMilliseconds, (dt3 - dt2).TotalMilliseconds, wcfRet.RunTime);
            return modelRet;
        }
        /// <summary>
        /// 指定列数据查询并且不进行count操作
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public DefaultResult<List<User_list>> GetColumnsNoCount(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, List<string> columns)
        {
            //调用wcf
            var wcfRet = User_listClient.GetColumnsNoCount(page, pagesize, filters, orders, columns, WcfOtherString);
            //进行数据解密
            var modelRet = (DefaultResult<List<User_list>>)_wcfClientHelper.Decrypt_v2019(wcfRet, Config.WCFSecretkey, Config.WCFSecretiv);

            return modelRet;
        }
    }
}
