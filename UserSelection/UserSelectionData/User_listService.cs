using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using WebComponentData.Interface;
using WebComponentData.Models;
using WebComponentStore.Interface;
using WebComponentStore.Models;
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
        IUser_listVistor _user_listVistor;
        IPub_DictVistor _pub_DictVistor;
        IPub_DicExtendItemVistor _pub_DicExtendItemVistor;
        IOrg_ListVistor _org_ListVistor;
        IOrgStore _orgStore;
        IUserCache _userCache;
        IPinYinLibraryHelper _pinYinLibraryHelper;
        /// <summary>
        /// 当前上下文
        /// </summary>
        public HttpContext _httpContext => _contextAccessor.HttpContext;
        public User_listService(
            IUser_listVistor user_listVistor,
        IHttpContextAccessor contextAccessor,
            IUserStore userStore,
            IDictStore dictStore,
            IPub_DictVistor pub_DictVistor,
            IPub_DicExtendItemVistor pub_DicExtendItemVistor,
            IOrg_ListVistor org_ListVistor,
            IOrgStore orgStore,
            IUserCache userCache,
        IPinYinLibraryHelper pinYinLibraryHelper)
        {
            _user_listVistor = user_listVistor;
            _contextAccessor = contextAccessor;
            _userStore = userStore;
            _dictStore = dictStore;
            _pub_DictVistor = pub_DictVistor;
            _pub_DicExtendItemVistor = pub_DicExtendItemVistor;
            _org_ListVistor = org_ListVistor;
            _orgStore = orgStore;
            _userCache = userCache;
            _pinYinLibraryHelper = pinYinLibraryHelper;
            //初始化用户缓存数据
            UserCacheList(false);
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
                    var modelRet = _user_listVistor.GetModelByIds(idList);

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
                #region 参数处理
                //TODO:OK,当前用户信息,从cookie中获取newframeuid
                int UserId = _httpContext.Request.GetCookieKeyInt("newframeuid");
                //TODO:暂时如果未登录，使用模拟数据orgid=22
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

                #endregion 参数处理

                #region 条件过滤处理
                var tempList = new List<int>();
                var selectList = new List<User_list>();

                Org_List myorg = new Org_List();
                //所有组织名称拼音包含搜索关键字拼音的组织
                var orgs = new List<int>();

                //wcf查询过滤条件及排序方式
                var filterList = new List<CommonFilterModel>();
                var orderby = new List<CommonOrderModel>() {
                    new CommonOrderModel(){ Name="UserId",Order=0 }
                };

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
                        //TODO:OK,通过模糊查询获取orglist
                        var otherOrgfilterList = new List<CommonFilterModel>();
                        otherOrgfilterList.Add(new CommonFilterModel("OrgName", "like", $"%{orgId}%"));

                        var otherOrgOrderby = new List<CommonOrderModel>() {
                            new CommonOrderModel(){ Name="OrgID",Order=0 }
                        };

                        var orglike = _org_ListVistor.GetIdList(1, 5, otherOrgfilterList, otherOrgOrderby).Data;
                        orgs = orglike == null ? new List<int>() : orglike.ToList();
                    }
                }
                else
                {
                    //TODO:OK,当前用户的组织
                    myorg = new Org_List() { OrgID = LoginUser.orgid.Value };
                    //filterList.Add(new CommonFilterModel("orgid", "=", LoginUser.orgid.ToString()));
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

                //显示离职员工 （限制类）
                //isshowdelete;0=在职(flag=1),1=全部;2=(flag in (0,1,9))    
                var strWhereFlag2 = "0,1,9".Split(',').Select(s => (object)s).ToList();
                switch (isShowDel)
                {
                    case 0:
                        filterList.Add(new CommonFilterModel("flag", "=", "1"));
                        break;
                    case 2:
                        filterList.Add(new CommonFilterModel("flag", "in", strWhereFlag2));
                        break;
                }
                //限制经纪人等级 （限制类）
                if (isJJrList != null && isJJrList.Count > 0)
                {
                    filterList.Add(new CommonFilterModel("isjjr", "in", isJJrList.Select(s => (object)s).ToList()));
                }

                //TODO:OK,必须在指定组织内,此处有待确认
                if (mastOrgId != null && mastOrgId.Count > 0)
                {
                    filterList.Add(new CommonFilterModel("orgid", "in", mastOrgId.Select(s => (object)s).ToList()));
                }

                #endregion 条件过滤处理

                switch (action)
                {
                    case "myorg":
                        //获取我所在组织的用户
                        var users = new List<int>();
                        //增加过滤条件
                        filterList.Add(new CommonFilterModel("orgid", "=", myorg.OrgID.Value.ToString()));
                        var wcfUsers = _user_listVistor.GetIdListLock(current, pagesize, filterList, orderby);
                        users = wcfUsers.Data;
                        number = wcfUsers.RetInt;
                        tempList.AddRange(users);
                        break;
                    case "otherOrg":
                        //获取组织Ids的用户
                        var usersList = new List<int>();
                        //增加过滤条件
                        if (orgs.Count > 0)
                        {
                            filterList.Add(new CommonFilterModel("orgid", "in", orgs.Select(s => (object)s).ToList()));
                        }
                        else
                        {
                            filterList.Add(new CommonFilterModel("orgid", "=", LoginUser.orgid.ToString()));
                        }
                        var wcfUsersList = _user_listVistor.GetIdListLock(current, pagesize, filterList, orderby);
                        usersList = wcfUsersList.Data;
                        number = wcfUsersList.RetInt;
                        tempList.AddRange(usersList);
                        break;
                    case "myarea":
                    case "mydian":
                        //TODO:OK,mydian
                        var myorgDetail = _orgStore.GetModel(myorg.OrgID.Value);
                        if (myorgDetail == null)
                        {
                            break;
                        }
                        int key = action == "mydian" ? 800 : 700;
                        if (myorg.OrgLevelKey <= key || myorg.OrgLevelKey == 900)
                        {
                            filterList.Add(new CommonFilterModel("orgid", "=", myorg.OrgLevelKey == 900 ? myorg.OrgParentID.ToString() : myorg.OrgID.ToString()));

                        }
                        else if (myorg.OrgLevelKey > key && !string.IsNullOrEmpty(myorg.OrgParentIDALL))
                        {
                            //MisCommonCache.OrgStore.Get(e => myorg.OrgParentIDALL.Contains("|" + e.OrgID + "|")).FirstOrDefault().OrgID.GetValueOrDefault(1);                          

                            var myorgArea = FindOrgArea(myorg.OrgID.GetValueOrDefault(1));
                            if (myorgArea.OrgID == null)
                            {
                                break;
                            }
                            else
                            {
                                filterList.Add(new CommonFilterModel("orgid", "=", myorgArea.OrgID.ToString()));
                            }
                        }
                        else
                        {
                            break;
                        }
                        //根据过滤条件查询处理
                        var wcfUsermydianChildList = _user_listVistor.GetIdListLock(current, pagesize, filterList, orderby);
                        var mydianUserList = wcfUsermydianChildList.Data;
                        number = wcfUsermydianChildList.RetInt;
                        tempList.AddRange(mydianUserList);

                        break;
                    case "myareachild":
                        //TODO:OK,myareachild
                        var orgArea = FindOrgArea(myorg.OrgID.GetValueOrDefault(1));
                        if (orgArea.OrgID == null)
                        {
                            break;
                        }
                        List<int> orgids = FindOrgChilds(orgArea.OrgID.GetValueOrDefault(1)).Select(o => o.OrgID.GetValueOrDefault()).ToList();
                        if (orgids.Count > 0)
                        {
                            filterList.Add(new CommonFilterModel("orgid", "in", orgids.Select(s => (object)s).ToList()));
                            var wcfUserOrgChildList = _user_listVistor.GetIdListLock(current, pagesize, filterList, orderby);

                            var userOrgChildList = wcfUserOrgChildList.Data;
                            number = wcfUserOrgChildList.RetInt;
                            tempList.AddRange(userOrgChildList);
                        }

                        break;
                    case "selectIds":
                        //获取指定Ids的用户
                        var usersIdList = new List<int>();
                        //增加过滤条件
                        filterList.Add(new CommonFilterModel("orgid", "in", idsIn.Select(id => (object)id).ToList()));
                        var wcfUsersIdList = _user_listVistor.GetIdListLock(current, pagesize, filterList, orderby);
                        usersIdList = wcfUsersIdList.Data;
                        number = wcfUsersIdList.RetInt;
                        tempList.AddRange(usersIdList);

                        break;
                    default:
                        #region default
                        int temp;
                        if (int.TryParse(action, out temp))
                        {
                            if (temp > 10000 && temp < 99999)
                            {
                                filterList.Add(new CommonFilterModel("UserId", "=", action));

                                var wcfdefaultUserList = _user_listVistor.GetIdListLock(current, pagesize, filterList, orderby);
                                var defaultUserList = wcfdefaultUserList.Data;
                                number = wcfdefaultUserList.RetInt;
                                tempList.AddRange(defaultUserList);
                            }
                        }
                        else
                        {
                            var arr = action.Split(',');
                            if (arr.Length > 1)
                            {
                                var userids = arr.Select(a => a.Int()).Where(a => a != 0).Distinct().ToList();
                                filterList.Add(new CommonFilterModel("UserId", "in", userids.Cast<object>().ToList()));

                                var wcfdefaultUserList = _user_listVistor.GetIdListLock(current, pagesize, filterList, orderby);
                                var defaultUserList = wcfdefaultUserList.Data;
                                number = wcfdefaultUserList.RetInt;
                                tempList.AddRange(defaultUserList);
                            }
                            else
                            {
                                if (action.Length < 1)
                                {
                                    return ReturnUsers(null, -1, "请使用1个以上的拼音进行查询");
                                }

                                List<PinYinResult> pinyinResult;
                                ////TODO:wcf获取指定条件的用户信息,此处数据如何实现，待商榷
                                //List<string> columns = new List<string>() {
                                //    "UserId",
                                //    "UserName2"
                                //};
                                //var wcfdefaultUserList = _user_listVistor.GetColumnsNoCount(1, 200, filterList, orderby, columns);
                                //var defaultUserList = wcfdefaultUserList.Data;
                                //number = wcfdefaultUserList.RetInt;


                                var defaultUserList = UserCacheList();

                                #region 特殊数据过滤

                                //显示离职员工 （限制类）         
                                switch (isShowDel)
                                {
                                    case 0:
                                        defaultUserList = defaultUserList.Where(m => m.flag == 1).ToList();
                                        break;
                                    case 2:
                                        defaultUserList = defaultUserList.Where(m => strWhereFlag2.Contains(m.flag)).ToList();
                                        break;
                                }
                                //限制经纪人等级 （限制类）
                                if (isJJrList != null && isJJrList.Count > 0)
                                {
                                    defaultUserList = defaultUserList.Where(m => isJJrList.Contains(m.isjjr)).ToList();
                                }

                                //必须在指定组织内
                                if (mastOrgId != null && mastOrgId.Count > 0)
                                {
                                    defaultUserList = defaultUserList.Where(m => mastOrgId.Contains(m.orgid.Value)).ToList();
                                }

                                #endregion 特殊数据过滤


                                var pinYinSourceList = new List<PinYinSource>();
                                foreach (var userDetail in defaultUserList)
                                {
                                    if (userDetail != null && !string.IsNullOrWhiteSpace(userDetail.UserName2))
                                    {
                                        pinYinSourceList.Add(new PinYinSource
                                        {
                                            ID = userDetail.UserId,
                                            Name = userDetail.UserName2
                                        });
                                    }
                                }

                                pinyinResult = _pinYinLibraryHelper.GetPinYinAndHanZiResult("UserSelectionData", pinYinSourceList, action, pagesize, out number, current);

                                if (pinyinResult != null && pinyinResult.Count > 0)
                                {
                                    tempList.AddRange(pinyinResult.Select(p => p.ID).ToList());
                                }
                            }
                        }

                        #endregion default

                        break;
                }

                #region 历史记录及常用信息
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
                #endregion 历史记录及常用信息

                result = ReturnUsers(tempList, number, _httpContext.Request.GetKey("check") ?? "", history, changyong);
            }
            catch (Exception)
            {
                result = ReturnUsers(null, -2, "(catch)选人插件代码错误");
            }

            return result;
        }


        #region 私有方法      

        #region 获取组织父级


        /// <summary>
        /// 获取指定组织的700父级
        /// </summary>
        /// <param name="OrgID"></param>
        /// <returns></returns>
        private Org_Detail FindOrgArea(int orgID)
        {
            //获取OrgID所在的父级
            var orgdetail = _orgStore.GetModel(orgID);
            if (orgdetail != null)
            {
                List<Org_Detail> list = currentOrgParents(orgdetail, 700).ToList();
                if (list.Count > 0)
                {
                    return list[0];
                }
            }

            return new Org_Detail();

        }
        /// <summary>
        /// 对应等级的父级
        /// </summary>
        /// <param name="item"></param>
        /// <param name="parentLevel">父级等级</param>
        /// <returns></returns>
        private Org_Detail[] currentOrgParents(Org_Detail item, int parentLevel = 0)
        {
            if (string.IsNullOrEmpty(item?.OrgParentIDALL))
            {
                return new Org_Detail[0];
            }
            //父级等级为0
            if (parentLevel == 0)
            {
                var array = GetCurrentOrgAndOrgParentIds(item);

                return array;
            }
            //当前组织的级别与所要获取级别的等级一致，比如当前组织级别为700，需要获取的级别也为700
            if (item.OrgLevelKey == parentLevel)
            {
                return new Org_Detail[1]
                {
                    item
                };
            }
            //所在组织级别小于要获取的级别
            if (item.OrgLevelKey < parentLevel)
            {
                return new Org_Detail[0];
            }
            //所在组织级别大于要获取的级别，往所要查找的级别获取
            var array2 = GetCurrentOrgAndOrgParentIds(item, parentLevel);
            return array2;
        }
        /// <summary>
        /// 取得当前组织与组织对应等级的子集
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="getLevel"></param>
        /// <returns></returns>
        public Org_Detail[] GetCurrentOrgAndOrgParentIds(Org_Detail item, int getLevel = 0)
        {
            //TODO:OK,获取父级组织的核心方法
            if (getLevel == 0)
            {
                return new Org_Detail[1]
                {
                    item
                };
            }
            //获取指定等级的组织的父级ID
            List<int> list = (from e in ExpandHelper.ChangeToIntList(item.OrgParentIDALL.Replace("|", "")).Distinct()
                              where e != 0
                              select e).ToList();
            Org_Detail[] array = new Org_Detail[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                //TODO:OK.遍历通过redis获取组织信息,当前组织的父级节点，到根节点3级左右
                array[i] = _orgStore.GetModel(list[i]) ?? new Org_Detail();
            }
            //获取大于等于指定级别的组织
            return array.Where(m => m.OrgLevelKey >= getLevel && m.OrgID > 0).OrderByDescending(b => b.OrgLevelKey).ToArray();
        }

        #endregion 获取组织父级

        #region 获取组织子级

        /// <summary>
        ///  对应等级的子级(包括自身)
        /// </summary>
        /// <param name="orgID">要查找的组织</param>
        /// <param name="LevelKey"> 对应等级(0为全部)</param>
        /// <returns></returns>
        private List<Org_Detail> FindOrgChilds(int orgID, int LevelKey = 0)
        {
            var item = _orgStore.GetModel(orgID);
            if (item == null || !item.OrgID.HasValue)
            {
                return new List<Org_Detail>();
            }
            if (LevelKey != 0 && item.OrgLevelKey == LevelKey)
            {
                return new List<Org_Detail>
                {
                    item
                };
            }
            if (LevelKey != 0 && item.OrgLevelKey > LevelKey)
            {
                return new List<Org_Detail>();
            }
            return GetCurrentOrgAndOrgChilds(item, LevelKey);
        }

        /// <summary>
        /// 取得当前组织与组织对应等级的子集
        /// </summary>
        /// <param name="item">当前组织</param>
        /// <param name="getLevel">取得等级</param>
        /// <returns></returns>
        public List<Org_Detail> GetCurrentOrgAndOrgChilds(Org_Detail item, int getLevel = 0)
        {
            var filterList = new List<CommonFilterModel>();
            var orderby = new List<CommonOrderModel>() {
                    new CommonOrderModel(){ Name="OrgID",Order=0 }
                };

            if (getLevel != 0)
            {
                //指定级别
                filterList.Add(new CommonFilterModel("OrgLevelKey", "=", getLevel.ToString()));
            }
            //模糊查询获取所有的子节点
            filterList.Add(new CommonFilterModel("OrgParentIDALL", "like", $"%|{item.OrgID}|%"));

            //TODO:OK.通过wcf获取指定组织的子节点
            List<int> list = new List<int>();
            var wcfList = _org_ListVistor.GetIdList(1, 100, filterList, orderby);
            if (wcfList.RetInt > 0)
            {
                list = wcfList.Data.Select(m => m).ToList();
            }

            List<Org_Detail> resultList = new List<Org_Detail>();

            foreach (var itemChilds in list)
            {
                Org_Detail org_Detail = _orgStore.GetModel(itemChilds) ?? new Org_Detail();
                resultList.Add(org_Detail);
            }
            return resultList;
        }

        #endregion 获取组织子级

        #region 用户变更数据操作
        /// <summary>
        /// 用户数据缓存处理
        /// </summary>
        /// <param name="retFlag">是否返回数据，默认返回</param>
        /// <returns></returns>
        private List<User_Detail> UserCacheList(bool retFlag=true)
        {
            //通过wcf处理变更集
            var lastUpdateTime = _userCache.GetLastUpdateTime();
            //初始化数据状态
            bool InitTag = lastUpdateTime.Year > 1970 ? true : false;

            //wcf查询过滤条件及排序方式
            var filterList = new List<CommonFilterModel>()
            {
                new CommonFilterModel("UserId", ">", "10000")
            };

            if (InitTag)
            {
                filterList.Add(new CommonFilterModel("LastTime", ">", lastUpdateTime.ToString("yyyy-MM-dd HH:mm:ss")));
            }

            var orderby = new List<CommonOrderModel>() {
                new CommonOrderModel(){ Name="UserId",Order=0 }
            };


            var changeUsers = new List<int>();

            //查询wcf

            int page = 1;
            int pagesize = 5;
            var wcfChangeUsers = _user_listVistor.GetIdListLock(page, pagesize, filterList, orderby);
            //返回总条数
            int changeCount = wcfChangeUsers.RetInt;
            if (changeCount > 0)
            {
                //返回数据
                changeUsers.AddRange(wcfChangeUsers.Data);
                //计算总页数
                var pagecount = (changeCount / pagesize) + (changeCount % pagesize > 0 ? 1 : 0);
                //获取剩余页数
                for (int i = 2; i <= pagecount && i < 5; i++)
                {
                    page++;
                    wcfChangeUsers = _user_listVistor.GetIdListLock(page, pagesize, filterList, orderby);
                    //返回数据
                    changeUsers.AddRange(wcfChangeUsers.Data);
                }

                var userDetailList = new List<User_Detail>();
                foreach (var item in changeUsers)
                {
                    var itemUser = _userStore.GetUser(item);
                    if (itemUser != null)
                    {
                        userDetailList.Add(itemUser);
                    }
                }
                //更新缓存
                _userCache.SetUserList(userDetailList);
            }

            //数据返回
            if (retFlag)
            {
                //返回缓存数据
                return _userCache.GetUserList();                
            }
            else
            {
                return null;
            }
        }


        #endregion 用户变更数据操作

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
