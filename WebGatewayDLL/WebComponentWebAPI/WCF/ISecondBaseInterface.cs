using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using WebComponentWebAPI.WCF.Models;

namespace WebComponentWebAPI.WCF
{
      /// <summary>
    /// 忙碌异常
    /// </summary>
    public class BusyException : Exception { }

    /// <summary>
    /// 接口的基类
    /// </summary>
    /// <typeparam name="Entity">第一层WCF实体</typeparam>
    [ServiceContractAttribute]
    public interface ISecondBaseInterface<Entity>
    {
        /// <summary>
        /// 重新加载id集合对应行的Cache
        /// </summary>
        [OperationContract(Name = "CacheReloadAndUpdateByIdList")]
        int CacheReloadAndUpdate(List<int> idList, string source);
        /// <summary>
        /// 重新加载所有Cache
        /// </summary>
        /// <param name="id">主键值</param>
        [OperationContract(Name = "CacheReloadAndUpdateAll")]
        int CacheReloadAndUpdate(string source);
        /// <summary>
        /// 重新加载id所在行的Cache
        /// </summary>
        ///<param name="idList">id集合</param>
        [OperationContract(Name = "CacheReloadAndUpdateById")]
        int CacheReloadAndUpdate(int id, string source);

        /// <summary>
        /// 向数据库中添加数据
        /// </summary>
        /// <param name="entity">实体</param>
        [OperationContract]
        DefaultResult<int> Add(Entity entity, string otherString);
        /// <summary>
        /// 向数据库中添加数据,并返回添加后数据库中的数据
        /// </summary>
        /// <param name="entity">实体</param>
        [OperationContract]
        DefaultResult<Entity> AddAndGetModel(Entity entity, string otherString);
        /// <summary>
        /// 向数据库中添加数据集合
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<List<int>> AddList(List<Entity> entities, string otherString);
        /// <summary>
        /// 更新数据库中的数据
        /// </summary>
        /// <param name="entity">实体</param>
        [OperationContract]
        DefaultResult<int> Update(Entity entity, string otherString);
        /// <summary>
        /// 更新多条数据库中的数据
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<List<int>> UpdateList(List<Entity> entities, string otherString);
        /// <summary>
        /// 按照条件更新多个数据库中的数据
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="entity"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<int> UpdateByFilters(Entity entity, List<CommonFilterModel> filters, string otherString);
        /// <summary>
        /// 删除数据记录
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<int> Delete(Entity entity, string otherString);
        /// <summary>
        /// 通过主键删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<int> DeleteById(int id, string otherString);
        /// <summary>
        /// 通过条件删除数据
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<int> DeleteByFilters(List<CommonFilterModel> filters, string otherString);


        /// <summary>
        /// 通过id获取一个实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<Entity> GetModelByID(int id, string otherString);

        /// <summary>
        /// 通过id获取一个实体并更新次数
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="times">次数</param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<Entity> GetModelByIDAndUpdateTimes(int id, int times, string otherString);

        /// <summary>
        /// 通过分页、条件、排序查询数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<List<Entity>> GetListByQuery(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, string otherString);
        /// <summary>
        /// 通过分页、条件、排序查询数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <param name="skipnumber"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<List<Entity>> GetListByQuerySkip(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, int skipnumber, string otherString);
        /// <summary>
        /// 通过分页、条件、排序查询数据主键
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<List<int>> GetIdList(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, string otherString);
        /// <summary>
        /// 通过分页、条件、排序查询数据列的值
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <param name="columns"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<List<List<string>>> GetValuesByQuery(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, List<string> columns, string otherString);
        /// <summary>
        /// 获取统计数
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<int> GetCountByQuery(List<CommonFilterModel> filters, string otherString);
        /// <summary>
        /// 获取聚合函数数据
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="columns"></param>
        /// <param name="groups"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<List<Entity>> GetQueryAggregate(List<CommonFilterModel> filters, List<string> columns, List<string> groups, string otherString);
        /// <summary>
        /// 获取聚合函数数据
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="columns"></param>
        /// <param name="groups"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<List<Entity>> GetQueryAggregatePage(int page, int pagesize, List<CommonFilterModel> filters, List<string> columns, List<string> groups, List<CommonOrderModel> orders, string otherString);
        /// <summary>
        /// 通过id的集合获取集合
        /// </summary>
        /// <param name="idlist"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<List<Entity>> GetModelByIDS(List<int> idlist, string otherString);
        /// <summary>
        /// 获取变更id集合
        /// </summary>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        List<int> GetChangeIds(string otherString);



        /// <summary>
        /// 通过id获取一个实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<Entity> GetModelByIDLock(int id, string otherString);

        /// <summary>
        /// 通过分页、条件、排序查询数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<List<Entity>> GetListByQueryLock(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, string otherString);
        /// <summary>
        /// 通过分页、条件、排序查询数据主键
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<List<int>> GetIdListLock(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, string otherString);
        /// <summary>
        /// 通过分页、条件、排序查询数据列的值
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <param name="columns"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<List<List<string>>> GetValuesByQueryLock(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, List<string> columns, string otherString);
        /// <summary>
        /// 获取统计数
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<int> GetCountByQueryLock(List<CommonFilterModel> filters, string otherString);
        /// <summary>
        /// 获取聚合函数数据
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="columns"></param>
        /// <param name="groups"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<List<Entity>> GetQueryAggregatePageLock(int page, int pagesize, List<CommonFilterModel> filters, List<string> columns, List<string> groups, List<CommonOrderModel> orders, string otherString);
        /// <summary>
        /// 通过id的集合获取集合
        /// </summary>
        /// <param name="idlist"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<List<Entity>> GetModelByIDSLock(List<int> idlist, string otherString);
        /// <summary>
        /// 获取聚合函数数据
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="columns"></param>
        /// <param name="groups"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<List<Entity>> GetQueryAggregateLock(List<CommonFilterModel> filters, List<string> columns, List<string> groups, string otherString);

        /// <summary>
        /// 指定列数据查询并且不进行count操作
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <param name="columns"></param>
        /// <param name="otherString"></param>
        /// <returns></returns>
        [OperationContract]
        DefaultResult<List<Entity>> GetColumnsNoCount(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, List<string> columns, string otherString);
    }
}
