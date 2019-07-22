using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using WebComponentData.Interface;
using WebComponentData.Models;
using WebComponentStore.Interface;
using WebComponentWebAPI.ConfigCenter;
using WebComponentWebAPI.Models;
using WebComponentWebAPI.Utilitys;
using WebComponentWebAPI.WCF.Models;

namespace UserSelectionData
{
    public class User_listService : IUser_listService
    {
        IUserStore _userStore;
        IDictStore _dictStore;
        IHttpContextAccessor _contextAccessor;
        IUser_listVistor _uer_listVistor;
        IPub_DictVistor _pub_DictVistor;
        IPub_DicExtendItemVistor _pub_DicExtendItemVistor;
        IOrg_ListVistor _org_ListVistor;
        /// <summary>
        /// 当前上下文
        /// </summary>
        public HttpContext _httpContext => _contextAccessor.HttpContext;
        public User_listService(IHttpContextAccessor contextAccessor,
            IUserStore userStore,
            IDictStore dictStore,
            IPub_DictVistor pub_DictVistor,
            IPub_DicExtendItemVistor pub_DicExtendItemVistor,
            IOrg_ListVistor org_ListVistor)
        {
            _contextAccessor = contextAccessor;
            _userStore = userStore;
            _dictStore = dictStore;
            _pub_DictVistor = pub_DictVistor;
            _pub_DicExtendItemVistor = pub_DicExtendItemVistor;
            _org_ListVistor = org_ListVistor;
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
                    //调用wcf,获取解密数据
                    var modelRet = _uer_listVistor.GetModelByIds(idList);

                    var data = modelRet.Data;

                    if (data != null && data.Count > 0)
                    {
                        var list = data.OrderBy(d => idList.IndexOf(d.UserId ?? 0)).Select(m => m.UserId.Value).ToList();
                        result = ReturnUsers(list, data.Count, _httpContext.Request.GetKey("check") ?? "");
                    }
                    else
                    {
                        result = ReturnUsers(new List<int>(), 0, _httpContext.Request.GetKey("check") ?? "");
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
                //TODO:OK,当前用户信息,从cookie中获取newframeuid
                int UserId = _httpContext.Request.GetCookieKeyInt("newframeuid");
                var LoginUser = _userStore.GetUser(UserId) ?? new WebComponentStore.Models.User_Detail() { UserId = 58988, orgid = 22 };

                var current = _httpContext.Request.GetKeyInt("page");
                var pagesize = _httpContext.Request.GetKeyInt("size");
                var orgidstr = _httpContext.Request.GetKey("orgId");
                string action = _httpContext.Request.GetKey("type");
                //TODO:OK,如果传入字符串是有问题的,修正如下
                //string orgId = orgidstr.Int() > 0 ? orgidstr : LoginUser.orgid.ToString();
                int query_Orgid = 0;
                var query_Orgid_IsInt = int.TryParse(orgidstr, out query_Orgid);
                string orgId = query_Orgid_IsInt ? (orgidstr.Int() > 0 ? orgidstr : LoginUser.orgid.ToString()) : orgidstr;
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

                var tempList = new List<int>();
                var selectList = new List<User_list>();

                Org_List myorg = new Org_List();
                var orgs = new List<Org_List>();//所有组织名称拼音包含搜索关键字拼音的组织

                if (action == "otherOrg" && !string.IsNullOrEmpty(orgId))
                {
                    int num;//判断查询组织传入的orgId是否为数字
                    if (int.TryParse(orgId, out num))
                    {
                        action = "myorg";
                        //TODO:OK,获取指定的组织
                        myorg = new Org_List() { OrgID = num };
                    }
                    else
                    {
                        //var orglike = MisCommonCache.OrgStore.Get(o => o.OrgName.Contains(orgId) && o.isdel == 0);
                        //TODO:通过模糊查询获取orglist
                        var otherOrgfilterList = new List<CommonFilterModel>();
                        otherOrgfilterList.Add(new CommonFilterModel("OrgName", "like", $"%{orgId}%"));
                        var orglike = _org_ListVistor.GetListByQuery(1, 5, otherOrgfilterList, null).Data;
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
                    new CommonOrderModel(){ Name="UserId",Order=0 }
                };

                //显示离职员工 （限制类）
                //isshowdelete;0=在职(flag=1),1=全部;2=(flag in (0,1,9))                
                switch (isShowDel)
                {
                    case 0:
                        filterList.Add(new CommonFilterModel("flag", "=", "1"));
                        break;
                    case 2:
                        var strWhereFlag = "0,1,9".Split(',').Select(s => (object)s).ToList();
                        filterList.Add(new CommonFilterModel("flag", "in", strWhereFlag));
                        break;
                }
                //限制经纪人等级 （限制类）
                if (isJJrList != null && isJJrList.Count > 0)
                {
                    filterList.Add(new CommonFilterModel("isjjr", "in", isJJrList.Select(s => (object)s).ToList()));
                }

                switch (action)
                {
                    case "myorg":
                        //获取我所在组织的用户
                        var users = new List<int>();
                        //增加过滤条件
                        filterList.Add(new CommonFilterModel("orgid", "=", myorg.OrgID.Value.ToString()));
                        var wcfUsers = _uer_listVistor.GetIdListLock(current, pagesize, filterList, orderby);
                        users = wcfUsers.Data;
                        number = wcfUsers.RetInt;
                        tempList.AddRange(users);
                        break;
                    case "otherOrg":
                        //获取组织Ids的用户
                        var usersList = new List<int>();
                        //增加过滤条件
                        filterList.Add(new CommonFilterModel("orgid", "in", orgs.Select(s => (object)s.OrgID).ToList()));
                        var wcfUsersList = _uer_listVistor.GetIdListLock(current, pagesize, filterList, orderby);
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
                        var usersIdList = new List<int>();
                        //增加过滤条件
                        filterList.Add(new CommonFilterModel("orgid", "in", idsIn.Select(id => (object)id).ToList()));
                        var wcfUsersIdList = _uer_listVistor.GetIdListLock(current, pagesize, filterList, orderby);
                        usersIdList = wcfUsersIdList.Data;
                        number = wcfUsersIdList.RetInt;
                        tempList.AddRange(usersIdList);

                        break;
                    default:
                        break;
                }
                tempList = tempList.Where(e =>
                {
                    if (mastOrgId != null && mastOrgId.Count > 0)
                    {
                        //var tempParentOrg = CommonFrame.FindOrg(CommonFrame.FindOrg(e.orgid.Value)?.OrgParentID.Value ?? 0);
                        //if (!mastOrgId.Contains(e.orgid.Value) && !mastOrgId.Contains(tempParentOrg?.OrgID.Value ?? 0)) return false;
                    }
                    return true;
                }).ToList();

                result = ReturnUsers(tempList, number, _httpContext.Request.GetKey("check") ?? "", history, changyong);
            }
            catch (Exception)
            {
                result = ReturnUsers(null, -2, "(catch)选人插件代码错误");
            }

            return result;
        }

        #region 私有方法       
        /// <summary>
        /// 返回用户数据格式封装
        /// </summary>
        /// <param name="users"></param>
        /// <param name="number"></param>
        /// <param name="info"></param>
        /// <param name="history"></param>
        /// <param name="changyong"></param>
        /// <returns></returns>
        private ClientResult ReturnUsers(IEnumerable<int> userIds, int number, string info, List<int> history = null, List<int> changyong = null)
        {
            var result = ClientResult.Error("");
            if (userIds == null)
            {
                result = ClientResult.Ok(new { data = new List<object>(), count = 0, msg = info });
            }
            else
            {
                //TODO:OK,在职状态字典缓存，从wcf获取
                var flag_Dics = _pub_DictVistor.GetListByClassId(77).Data;
                //TODO:OK,isyunying从wcf扩展字典中获取
                var dictExtendItem = _pub_DicExtendItemVistor.GetItemWithOutIsdel("isjjr_extend", "isyunying").Data;
                var isYunYing_isjjrList = dictExtendItem.Select(e => (object)e.ItemKey).ToList();
                var list = new List<object>();

                foreach (var item in userIds)
                {
                    if (item != 0)
                    {
                        //TODO:OK,组织结构，从用户缓存获取                      
                        //TODO:OK,User_list中不存在mobile，从用户缓存获取 

                        //直接通过redis获取用户数据
                        var user_detail = _userStore.GetUser(item) ?? new WebComponentStore.Models.User_Detail();
                        list.Add(new
                        {
                            user_detail.UserId,
                            ZaiZhiZhuangTai = flag_Dics.FirstOrDefault(m => m.DictUseId == user_detail.flag)?.DicName ?? "",
                            UserName = user_detail.UserName2,
                            user_detail.orgid,
                            user_detail.isjjr,
                            user_detail.OrgName,
                            user_detail.mobile,
                            RzRuzhiDate = string.Format("{0:yyyy-MM-dd}", user_detail.RzRuzhiDate),
                            isyunying = isYunYing_isjjrList.Contains(user_detail.isjjr),

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
