using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using UserSelectionData.Models;
using WebComponentWebAPI.ConfigCenter;
using WebComponentWebAPI.Models;
using WebComponentWebAPI.WCF;
using WebComponentWebAPI.WCF.Models;
using WebComponentWebAPI.Utilitys;

namespace UserSelectionData
{
    public class User_listVistor : IUser_listVistor
    {
        IWCFClientHelper _wcfClientHelper;
        private IHttpContextAccessor _contextAccessor;
        /// <summary>
        /// 当前上下文
        /// </summary>
        public HttpContext _httpContext => _contextAccessor.HttpContext;
        public User_listVistor(IWCFClientHelper wcfClientHelper, IHttpContextAccessor contextAccessor)
        {
            _wcfClientHelper = wcfClientHelper;
            _contextAccessor = contextAccessor;
        }
        private ISecondBaseInterface<User_list> User_listClient
        {
            get
            {
                return _wcfClientHelper.GetInterfaces<User_list>("/User/v3.0/NetService/User_listService.svc");
            }
        }
        private ISecondBaseInterface<User_show> User_showClient
        {
            get
            {
                return _wcfClientHelper.GetInterfaces<User_show>("/User/v3.0/NetService/User_showService.svc");
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
        public DefaultResult<User_show> GetModelByID(int entityId)
        {
            //调用wcf
            var wcfRet = User_showClient.GetModelByID(entityId, WcfOtherString);
            //进行数据解密
            var modelRet = (DefaultResult<User_show>)_wcfClientHelper.Decrypt_v2019(wcfRet, Config.WCFSecretkey, Config.WCFSecretiv);

            return modelRet;
        }
        /// <summary>
        /// 通过指定的ids获取实例列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ClientResult GetModelByIds(string ids)
        {
            var result = ClientResult.Error("");
            if (!string.IsNullOrWhiteSpace(ids))
            {
                int temp;
                var idList = ids.Split(',').Where(id => int.TryParse(id, out temp)).Select(id => Convert.ToInt32(id)).Distinct().ToList();
                if (idList.Count > 0)
                {
                    //调用wcf
                    var wcfRet = User_listClient.GetModelByIDS(idList, WcfOtherString);
                    //进行数据解密
                    var modelRet = (DefaultResult<List<User_list>>)_wcfClientHelper.Decrypt_v2019(wcfRet, Config.WCFSecretkey, Config.WCFSecretiv);

                    var data = modelRet.Data;

                    if (data != null && data.Count > 0)
                    {
                        var list = data.OrderBy(d => idList.IndexOf(d.UserId ?? 0)).ToList();
                        result = ReturnUsers(list, data.Count, _httpContext.Request.GetKey("check") ?? "");
                    }
                    else
                    {
                        result = ReturnUsers(new List<User_list>(), 0, _httpContext.Request.GetKey("check") ?? "");
                    }
                }
            }

            return result;
        }

        public ClientResult GetUserList()
        {
            var result = ClientResult.Error("");
            try
            {
                //TODO:当前用户信息暂无
                var LoginUser = new User_list() { UserId = 58988, orgid = 22 };

                var current = _httpContext.Request.GetKeyInt("page");
                var pagesize = _httpContext.Request.GetKeyInt("size");
                var orgidstr = _httpContext.Request.GetKey("orgId");
                string action = _httpContext.Request.GetKey("type");
                string orgId = orgidstr.Int() > 0 ? orgidstr : LoginUser.orgid.ToString();
                int isPower = _httpContext.Request.GetKeyInt("ispowerorg");
                int isShowDel = _httpContext.Request.GetKeyInt("isShowDeleted");
                string isJJr = _httpContext.Request.GetKey("isJJr");
                string mastOrg = _httpContext.Request.GetKey("mastOrg");
                string selectIds = _httpContext.Request.GetKey("selectIds");
                List<int> isJJrList = !string.IsNullOrEmpty(isJJr) ? isJJr
                   .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                   .Select(TypeHelper.IntConvert).ToList() : null;
                List<int> mastOrgId = !string.IsNullOrEmpty(mastOrg) ? mastOrg
                   .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                   .Select(TypeHelper.IntConvert).ToList() : null;
                List<int> idsIn = !string.IsNullOrEmpty(selectIds) ? selectIds
                   .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                   .Select(TypeHelper.IntConvert).ToList() : null;

                var tempList = new List<User_list>();
                var selectList = new List<User_list>();

                Org_List myorg = new Org_List();
                var orgs = new List<Org_List>();//所有组织名称拼音包含搜索关键字拼音的组织

                if (action == "otherOrg" && !string.IsNullOrEmpty(orgId))
                {
                    int num;//判断查询组织传入的orgId是否为数字
                    if (int.TryParse(orgId, out num))
                    {
                        action = "myorg";
                        //TODO:获取指定的组织
                        myorg = new Org_List() { OrgID = num };
                    }
                    else
                    {
                        //var orglike = MisCommonCache.OrgStore.Get(o => o.OrgName.Contains(orgId) && o.isdel == 0);
                        //TODO:通过模糊查询获取orglist
                        var orglike = new List<Org_List>();
                        orgs = orglike == null ? new List<Org_List>() : orglike.ToList();
                    }
                }
                else
                {
                    //TODO:获取指定的组织
                    myorg = new Org_List() { OrgID = LoginUser.orgid.Value };
                }

                if (action == "otherOrg" && orgId == "0")
                {
                    action = "myorg";
                }
                if (orgs.Count <= 0)
                {
                    if (myorg == null || myorg.OrgID == null)
                    {
                        result = ReturnUsers(null, -3, "本组织信息异常(系统取不到您所在的组织.组织编号" + LoginUser.orgid + "或您传入的组织Id不存在)!");
                        return result;
                    }
                }
                int number = 0;

                List<int> history = null;
                List<int> changyong = null;
                if (action == "history")
                {
                    //TODO:历史记录
                    history = new List<int>();
                    action = string.Join(",", history);
                    if (_httpContext.Request.GetKeyInt("ischangyong") == 1)
                    {
                        //TODO:常用历史记录
                        changyong = new List<int>();
                        action += "," + string.Join(",", changyong);
                    }
                }

                var filterList = new List<CommonFilterModel>();
                var orderby = new List<CommonOrderModel>() {
                    new CommonOrderModel(){Name="UserId",Order=0}
                };

                if (isShowDel == 0)
                {
                    filterList.Add(new CommonFilterModel("flag", "=", "1"));
                }

                switch (action)
                {
                    case "myorg":
                        //获取我所在组织的用户
                        var users = new List<User_list>();
                        //增加过滤条件
                        filterList.Add(new CommonFilterModel("orgid", "=", myorg.OrgID.Value.ToString()));
                        var wcfUsers = GetListByQuery(current, pagesize, filterList, orderby);
                        users = wcfUsers.Data;
                        number = wcfUsers.RetInt;
                        tempList.AddRange(users);
                        break;
                    case "otherOrg":
                        //获取组织Ids的用户
                        var usersList = new List<User_list>();
                        //增加过滤条件
                        filterList.Add(new CommonFilterModel("orgid", "in", orgs.Select(s => (object)s.OrgID).ToList()));
                        var wcfUsersList = GetListByQuery(current, pagesize, filterList, orderby);
                        usersList = wcfUsersList.Data;
                        number = wcfUsersList.RetInt;
                        tempList.AddRange(usersList);
                        break;
                    case "myarea":
                    case "mydian":
                        //TODO:mydian
                        break;
                    case "myareachild":
                        //TODO:myareachild
                        break;
                    case "selectIds":
                        //获取指定Ids的用户
                        var usersIdList = new List<User_list>();
                        //增加过滤条件
                        filterList.Add(new CommonFilterModel("orgid", "in", idsIn.Select(id => (object)id).ToList()));
                        var wcfUsersIdList = GetListByQuery(current, pagesize, filterList, orderby);
                        usersIdList = wcfUsersIdList.Data;
                        number = wcfUsersIdList.RetInt;
                        tempList.AddRange(usersIdList);

                        break;
                    default:
                        {
                        }
                        break;
                }
                tempList = tempList.Where(e =>
                {
                    //isshowdelete;0=在职(flag=1),1=全部;2=(flag in (0,1,9))


                    if (isShowDel == 0)
                    {
                        if (e == null) return false;
                        if (e.flag != 1) return false;
                    }

                    if (isShowDel == 2)
                    {

                        if (e == null) return false;
                        if (!(e.flag == 0 || e.flag == 1 || e.flag == 9)) return false;
                    }

                    if (isJJrList != null && isJJrList.Count > 0)
                    {
                        if (!isJJrList.Contains(e.isjjr.Value)) return false;
                    }
                    if (mastOrgId != null && mastOrgId.Count > 0)
                    {
                        //var tempParentOrg = CommonFrame.FindOrg(CommonFrame.FindOrg(e.orgid.Value)?.OrgParentID.Value ?? 0);
                        //if (!mastOrgId.Contains(e.orgid.Value) && !mastOrgId.Contains(tempParentOrg?.OrgID.Value ?? 0)) return false;
                    }
                    return true;
                }).ToList();
                //number = tempList.Count;
                // LogHelper.WriteCustom("员工选人插件", "tempList.Count:" + number);
                //var list = tempList.Skip((current - 1) * pagesize).Take(pagesize).ToList();
                var list = tempList;
                result = ReturnUsers(list, number, _httpContext.Request.GetKey("check") ?? "", history, changyong);
            }
            catch (Exception ex)
            {
                result = ReturnUsers(null, -2, "(catch)选人插件代码错误");
            }

            return result;
        }

        #region 私有方法

        /// <summary>
        /// 通过分页、条件、排序查询数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        private DefaultResult<List<User_list>> GetListByQuery(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders)
        {
            //调用wcf
            var wcfRet = User_listClient.GetListByQuery(page, pagesize, filters, orders, WcfOtherString);
            //进行数据解密
            var modelRet = (DefaultResult<List<User_list>>)_wcfClientHelper.Decrypt_v2019(wcfRet, Config.WCFSecretkey, Config.WCFSecretiv);

            return modelRet;
        }

        private ClientResult ReturnUsers(IEnumerable<User_list> users, int number, string info, List<int> history = null, List<int> changyong = null)
        {
            var result = ClientResult.Error("");
            if (users == null)
            {
                result = ClientResult.Ok(new { data = new List<object>(), count = 0, msg = info });
            }
            else
            {
                //var dictExtendItem = MangoMis.MisFrame.Cache.DictExtendCache.GetItemWithOutIsdel("isjjr_extend", "isyunying", null, new List<string> { "1" });
                //var isYunYing_isjjrList = dictExtendItem.Select(e => (object)e.ItemKey).ToList();
                var list = new List<object>();
                foreach (var item in users)
                {
                    if (item != null)
                    {
                        //TODO:组织结构缓存
                        //TODO:在职状态字典缓存
                        //TODO:User_list中不存在mobile
                        //TODO:isyunying 是如何判断的

                        //var org = item.orgid.Org();
                        list.Add(new
                        {
                            item.UserId,
                            ZaiZhiZhuangTai = "",// item.flag?.Int().Dict(77)?.DicName ?? "",
                            UserName = item.UserName2,
                            item.orgid,
                            item.isjjr,
                            OrgName = "",//org?.OrgName ?? "",
                            mobile = "",//item.mobile,
                            RzRuzhiDate = string.Format("{0:yyyy-MM-dd}", item.RzRuzhiDate),
                            isyunying = false, //isYunYing_isjjrList.Contains(item.isjjr),

                        });
                    }

                }
                result = ClientResult.Ok(new { data = list, count = number, msg = info, history, changyong });
            }
            return result;
        }
        #endregion
    }
}
