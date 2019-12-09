using System;
using System.Collections.Generic;
using System.Text;
using WebComponentData.Models;
using WebComponentUtil.Ioc;
using WebComponentUtil.WCF.Models;

namespace WebComponentData.Interface
{
    public interface IOrg_ListVistor : ISingleTonInject
    {
        /// <summary>
        /// 通过分页、条件、排序查询数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        DefaultResult<List<Org_List>> GetListByQuery(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders);
        /// <summary>
        /// 通过分页、条件、排序查询数据主键
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        DefaultResult<List<int>> GetIdList(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders);
    }
}
