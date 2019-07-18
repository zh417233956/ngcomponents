using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace WebComponentWebAPI.Models
{
    //
    // 摘要:
    //     /// 释放重写 IDisposable 调用GC回收机制 ///
    [Serializable]
    [DataContract(Namespace = "", Name = "BT")]
    public class EntityBase : IDisposable
    {
        private bool m_disposed;

        //
        // 摘要:
        //     /// 执行与释放或重置非托管资源相关的应用程序定义的任务。 ///
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                }
                m_disposed = true;
            }
        }

        ~EntityBase()
        {
            Dispose(disposing: false);
        }

        //
        // 摘要:
        //     /// 内容比较函数 ///
        //
        // 参数:
        //   entity:
        //     The entity.
        //
        //   LowerName:
        //     Name of the lower.
        public virtual int CompareTo(object entity, string LowerName)
        {
            return 0;
        }

        //
        // 摘要:
        //     /// 内容比较函数 ///
        //
        // 参数:
        //   entity:
        //     数据
        //
        //   orderModels:
        //     The order models.
        public int CompareTo(object entity, List<LinqOrderModel> orderModels)
        {
            foreach (LinqOrderModel orderModel in orderModels)
            {
                int num = CompareTo(entity, orderModel.LowerName);
                if (num != 0)
                {
                    LinqOrderType order = orderModel.Order;
                    if (order == LinqOrderType.Asc)
                    {
                        return -num;
                    }
                    return num;
                }
            }
            return 0;
        }

        //
        // 摘要:
        //     /// 查询字段 ///
        //
        // 参数:
        //   ColunmName:
        public virtual object FindColumn(string ColunmName)
        {
            PropertyInfo property = GetType().GetProperty(ColunmName);
            return (property == null) ? null : property.GetValue(this, null);
        }

        //
        // 摘要:
        //     /// 比较是否符合条件 ///
        //
        // 参数:
        //   filter:
        //     The filter.
        public virtual bool Equals(LinqFilter filter)
        {
            return false;
        }

        //
        // 摘要:
        //     /// 比较是否符合条件 ///
        //
        // 参数:
        //   filters:
        //     The filters.
        public bool Equals(List<LinqFilter> filters)
        {
            foreach (LinqFilter filter in filters)
            {
                if (filter.Value == null && (filter.ListValue == null || filter.ListValue.Count == 0))
                {
                    return false;
                }
                if (Equals(filter))
                {
                    return true;
                }
            }
            return false;
        }

        //
        // 摘要:
        //     /// 比较是否符合条件 ///
        //
        // 参数:
        //   value:
        //     The value.
        //
        //   filter:
        //     The filter.
        public bool Equals<MT>(MT value, LinqFilter filter) where MT : IComparable
        {
            if (value != null)
            {
                switch (filter.Filter)
                {
                    case LinqFilterItem.Deng:
                        return filter.Value != null && value.Equals(filter.Value);
                    case LinqFilterItem.Dayu:
                        return filter.Value != null && value.CompareTo(filter.Value) > 0;
                    case LinqFilterItem.Xiaoyu:
                        return filter.Value != null && value.CompareTo(filter.Value) < 0;
                    case LinqFilterItem.Dayudengyu:
                        return filter.Value != null && value.CompareTo(filter.Value) >= 0;
                    case LinqFilterItem.Xiaoyudengyu:
                        return filter.Value != null && value.CompareTo(filter.Value) <= 0;
                    case LinqFilterItem.Budeng:
                        return filter.Value != null && value.CompareTo(filter.Value) != 0;
                    case LinqFilterItem.Like:
                        return filter.Value != null && value.ToString().IndexOf(filter.Value.ToString(), StringComparison.Ordinal) > -1;
                    case LinqFilterItem.Inlist:
                        return filter.ListValue != null && filter.ListValue.Contains(value);
                    case LinqFilterItem.Notinlist:
                        return filter.ListValue == null || !filter.ListValue.Contains(value);
                    default:
                        return false;
                }
            }
            return false;
        }
    }
}
