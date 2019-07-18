﻿using WebComponentWebAPI.ConfigCenter;
using WebComponentWebAPI.WCF;
using WebComponentWebAPI.WCF.Models;

namespace UserSelectionData
{
    public class User_listVistor : IUser_listVistor
    {
        IWCFClientHelper _wcfClientHelper;
        public User_listVistor(IWCFClientHelper wcfClientHelper)
        {
            _wcfClientHelper = wcfClientHelper;
        }
        private ISecondBaseInterface<Models.User_list> User_listClient
        {
            get
            {
                return _wcfClientHelper.GetInterfaces<Models.User_list>("/User/v3.0/NetService/User_listService.svc");
            }
        }

        /// <summary>
        /// 取得实体的接口
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public DefaultResult<Models.User_list> GetModelByID(int entityId)
        {
            //加密方式
            var passkey = Config.WCFPasskey;
            //debug:是否显示debug, 0不显示,1显示
            var isdebug = 1;
            //使用哪个加密的连接字符串
            var connkey = "new";
            var otherString = $"passkey$bc${passkey}$ac$debug$bc${isdebug}$ac$connkey$bc${connkey}";

            //调用wcf
            var wcfRet = User_listClient.GetModelByID(entityId, otherString);
            //进行数据解密
            var modelRet = (DefaultResult<Models.User_list>)_wcfClientHelper.Decrypt_v2019(wcfRet, Config.WCFSecretkey, Config.WCFSecretiv);

            return modelRet;
        }
    }
}
