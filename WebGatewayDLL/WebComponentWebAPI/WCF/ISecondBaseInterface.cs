using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using WebComponentWebAPI.WCF.Models;

namespace WebComponentWebAPI.WCF
{
    //
    // 摘要:
    //     接口的基类
    //
    // 类型参数:
    //   Entity:
    //     第一层WCF实体
    [ServiceContract]    public interface ISecondBaseInterface<Entity>    {
        //
        // 摘要:
        //     向数据库中添加数据
        //
        // 参数:
        //   entity:
        //     实体
        [OperationContract]        DefaultResult<int> Add(Entity entity, string otherString);
        //
        // 摘要:
        //     向数据库中添加数据,并返回添加后数据库中的数据
        //
        // 参数:
        //   entity:
        //     实体
        [OperationContract]        DefaultResult<Entity> AddAndGetModel(Entity entity, string otherString);
        //
        // 摘要:
        //     向数据库中添加数据集合
        //
        // 参数:
        //   entities:
        //
        //   otherString:
        [OperationContract]        DefaultResult<List<int>> AddList(List<Entity> entities, string otherString);
        //
        // 摘要:
        //     重新加载id集合对应行的Cache
        [OperationContract(Name = "CacheReloadAndUpdateByIdList")]        int CacheReloadAndUpdate(List<int> idList, string source);
        //
        // 摘要:
        //     重新加载所有Cache
        //
        // 参数:
        //   id:
        //     主键值
        [OperationContract(Name = "CacheReloadAndUpdateAll")]        int CacheReloadAndUpdate(string source);
        //
        // 摘要:
        //     重新加载id所在行的Cache
        //
        // 参数:
        //   idList:
        //     id集合
        [OperationContract(Name = "CacheReloadAndUpdateById")]        int CacheReloadAndUpdate(int id, string source);
        //
        // 摘要:
        //     删除数据记录
        //
        // 参数:
        //   entity:
        //
        //   otherString:
        [OperationContract]        DefaultResult<int> Delete(Entity entity, string otherString);
        //
        // 摘要:
        //     通过条件删除数据
        //
        // 参数:
        //   filters:
        //
        //   otherString:
        [OperationContract]        DefaultResult<int> DeleteByFilters(List<CommonFilterModel> filters, string otherString);
        //
        // 摘要:
        //     通过主键删除数据
        //
        // 参数:
        //   id:
        //
        //   otherString:
        [OperationContract]        DefaultResult<int> DeleteById(int id, string otherString);
        //
        // 摘要:
        //     获取变更id集合
        //
        // 参数:
        //   otherString:
        [OperationContract]        List<int> GetChangeIds(string otherString);
        //
        // 摘要:
        //     指定列数据查询并且不进行count操作
        //
        // 参数:
        //   page:
        //
        //   pagesize:
        //
        //   filters:
        //
        //   orders:
        //
        //   columns:
        //
        //   otherString:
        [OperationContract]        DefaultResult<List<Entity>> GetColumnsNoCount(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, List<string> columns, string otherString);
        //
        // 摘要:
        //     获取统计数
        //
        // 参数:
        //   filters:
        //
        //   otherString:
        [OperationContract]        DefaultResult<int> GetCountByQuery(List<CommonFilterModel> filters, string otherString);
        //
        // 摘要:
        //     获取统计数
        //
        // 参数:
        //   filters:
        //
        //   otherString:
        [OperationContract]        DefaultResult<int> GetCountByQueryLock(List<CommonFilterModel> filters, string otherString);
        //
        // 摘要:
        //     通过分页、条件、排序查询数据主键
        //
        // 参数:
        //   page:
        //
        //   pagesize:
        //
        //   filters:
        //
        //   orders:
        //
        //   otherString:
        [OperationContract]        DefaultResult<List<int>> GetIdList(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, string otherString);
        //
        // 摘要:
        //     通过分页、条件、排序查询数据主键
        //
        // 参数:
        //   page:
        //
        //   pagesize:
        //
        //   filters:
        //
        //   orders:
        //
        //   otherString:
        [OperationContract]        DefaultResult<List<int>> GetIdListLock(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, string otherString);
        //
        // 摘要:
        //     通过分页、条件、排序查询数据
        //
        // 参数:
        //   page:
        //
        //   pagesize:
        //
        //   filters:
        //
        //   orders:
        //
        //   otherString:
        [OperationContract]        DefaultResult<List<Entity>> GetListByQuery(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, string otherString);
        //
        // 摘要:
        //     通过分页、条件、排序查询数据
        //
        // 参数:
        //   page:
        //
        //   pagesize:
        //
        //   filters:
        //
        //   orders:
        //
        //   otherString:
        [OperationContract]        DefaultResult<List<Entity>> GetListByQueryLock(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, string otherString);
        //
        // 摘要:
        //     通过分页、条件、排序查询数据
        //
        // 参数:
        //   page:
        //
        //   pagesize:
        //
        //   filters:
        //
        //   orders:
        //
        //   skipnumber:
        //
        //   otherString:
        [OperationContract]        DefaultResult<List<Entity>> GetListByQuerySkip(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, int skipnumber, string otherString);
        //
        // 摘要:
        //     通过id获取一个实体
        //
        // 参数:
        //   id:
        //     主键
        [OperationContract]        DefaultResult<Entity> GetModelByID(int id, string otherString);
        //
        // 摘要:
        //     通过id获取一个实体并更新次数
        //
        // 参数:
        //   id:
        //     主键
        //
        //   times:
        //     次数
        //
        //   otherString:
        [OperationContract]        DefaultResult<Entity> GetModelByIDAndUpdateTimes(int id, int times, string otherString);
        //
        // 摘要:
        //     通过id获取一个实体
        //
        // 参数:
        //   id:
        //     主键
        [OperationContract]        DefaultResult<Entity> GetModelByIDLock(int id, string otherString);
        //
        // 摘要:
        //     通过id的集合获取集合
        //
        // 参数:
        //   idlist:
        //
        //   otherString:
        [OperationContract]        DefaultResult<List<Entity>> GetModelByIDS(List<int> idlist, string otherString);
        //
        // 摘要:
        //     通过id的集合获取集合
        //
        // 参数:
        //   idlist:
        //
        //   otherString:
        [OperationContract]        DefaultResult<List<Entity>> GetModelByIDSLock(List<int> idlist, string otherString);
        //
        // 摘要:
        //     获取聚合函数数据
        //
        // 参数:
        //   filters:
        //
        //   columns:
        //
        //   groups:
        //
        //   otherString:
        [OperationContract]        DefaultResult<List<Entity>> GetQueryAggregate(List<CommonFilterModel> filters, List<string> columns, List<string> groups, string otherString);
        //
        // 摘要:
        //     获取聚合函数数据
        //
        // 参数:
        //   filters:
        //
        //   columns:
        //
        //   groups:
        //
        //   otherString:
        [OperationContract]        DefaultResult<List<Entity>> GetQueryAggregateLock(List<CommonFilterModel> filters, List<string> columns, List<string> groups, string otherString);
        //
        // 摘要:
        //     获取聚合函数数据
        //
        // 参数:
        //   filters:
        //
        //   columns:
        //
        //   groups:
        //
        //   otherString:
        [OperationContract]        DefaultResult<List<Entity>> GetQueryAggregatePage(int page, int pagesize, List<CommonFilterModel> filters, List<string> columns, List<string> groups, List<CommonOrderModel> orders, string otherString);
        //
        // 摘要:
        //     获取聚合函数数据
        //
        // 参数:
        //   filters:
        //
        //   columns:
        //
        //   groups:
        //
        //   otherString:
        [OperationContract]        DefaultResult<List<Entity>> GetQueryAggregatePageLock(int page, int pagesize, List<CommonFilterModel> filters, List<string> columns, List<string> groups, List<CommonOrderModel> orders, string otherString);
        //
        // 摘要:
        //     通过分页、条件、排序查询数据列的值
        //
        // 参数:
        //   page:
        //
        //   pagesize:
        //
        //   filters:
        //
        //   orders:
        //
        //   columns:
        //
        //   otherString:
        [OperationContract]        DefaultResult<List<List<string>>> GetValuesByQuery(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, List<string> columns, string otherString);
        //
        // 摘要:
        //     通过分页、条件、排序查询数据列的值
        //
        // 参数:
        //   page:
        //
        //   pagesize:
        //
        //   filters:
        //
        //   orders:
        //
        //   columns:
        //
        //   otherString:
        [OperationContract]        DefaultResult<List<List<string>>> GetValuesByQueryLock(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, List<string> columns, string otherString);
        //
        // 摘要:
        //     更新数据库中的数据
        //
        // 参数:
        //   entity:
        //     实体
        [OperationContract]        DefaultResult<int> Update(Entity entity, string otherString);
        //
        // 摘要:
        //     按照条件更新多个数据库中的数据
        //
        // 参数:
        //   filters:
        //
        //   entity:
        //
        //   otherString:
        [OperationContract]        DefaultResult<int> UpdateByFilters(Entity entity, List<CommonFilterModel> filters, string otherString);
        //
        // 摘要:
        //     更新多条数据库中的数据
        //
        // 参数:
        //   entities:
        //     实体集合
        [OperationContract]        DefaultResult<List<int>> UpdateList(List<Entity> entities, string otherString);    }}