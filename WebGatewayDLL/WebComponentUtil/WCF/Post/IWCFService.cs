using System;
using System.Collections.Generic;
using System.Text;
using WebComponentUtil.Ioc;
using WebComponentUtil.WCF.Models;

namespace WebComponentUtil.WCF.Post
{
    public interface IWCFService<Entity> 
    {

        void SetRemoteAddress(string RemoteAddress);
        /// <summary>
        /// 通过id获取一个实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        DefaultResult<Entity> GetModelByID(int id, string otherString);

        /// <summary>
        /// 通过分页、条件、排序查询数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        DefaultResult<List<Entity>> GetListByQuery(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, string otherString);
        /// <summary>
        /// 通过分页、条件、排序查询数据主键
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        DefaultResult<List<int>> GetIdList(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, string otherString);
        /// <summary>
        /// 通过id的集合获取集合
        /// </summary>
        /// <param name="idlist"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        DefaultResult<List<Entity>> GetModelByIDS(List<int> idlist, string otherString);

        /// <summary>
        /// 通过分页、条件、排序查询数据主键
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        DefaultResult<List<int>> GetIdListLock(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, string otherString);

    }
}
