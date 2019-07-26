using System;
using System.Collections.Generic;
using System.Text;
using WebComponentData.Models;
using WebComponentWebAPI.Ioc;
using WebComponentWebAPI.WCF.Models;

namespace WebComponentData.Interface
{
    public interface IUser_listVistor : ISingleTonInject
    {
        /// <summary>
        /// 通过id获取一个实体
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        DefaultResult<User_list> GetModelByID(int entityId);
        /// <summary>
        /// 通过指定的ids获取实例列表
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        DefaultResult<List<User_list>> GetModelByIds(List<int> idList);

        /// <summary>
        /// 通过分页、条件、排序查询数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        DefaultResult<List<User_list>> GetListByQuery(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders);

        /// <summary>
        /// 通过分页、条件、排序查询数据主键
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        DefaultResult<List<int>> GetIdListLock(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders);

    }
}
