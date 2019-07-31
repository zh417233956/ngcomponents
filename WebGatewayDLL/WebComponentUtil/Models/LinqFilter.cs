using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WebComponentUtil.Models
{
    //
    // 摘要:
    //     /// 通用生成查询条件 ///
    public class LinqFilter
    {
        private List<object> _listValue;

        //
        // 摘要:
        //     /// 当前条件使用的属性 ///
        public PropertyInfo GetterProperty
        {
            get;
            set;
        }

        //
        // 摘要:
        //     /// 小写字段名 ///
        public string LowerName
        {
            get;
            set;
        }

        //
        // 摘要:
        //     /// 字段名(对就实体类属性名) ///
        public string Name
        {
            get;
            set;
        }

        //
        // 摘要:
        //     /// 查询条件(=>....like in not in) ///
        public LinqFilterItem Filter
        {
            get;
            set;
        }

        //
        // 摘要:
        //     /// 用来查询的值 ///
        public object Value
        {
            get;
            set;
        }

        //
        // 摘要:
        //     /// 用做比较的值 ///
        public IComparable compareValue => Value as IComparable;

        //
        // 摘要:
        //     /// 用作比较的列表 ///
        public List<IComparable> compareList => (from o in ListValue
                                                 select o as IComparable).ToList();

        //
        // 摘要:
        //     /// 采用In时的列表数据 ///
        public List<object> ListValue
        {
            get
            {
                return _listValue;
            }
            set
            {
                _listValue = new List<object>();
                if (value != null)
                {
                    foreach (object item in from o in value
                                            where !_listValue.Contains(o)
                                            select o)
                    {
                        _listValue.Add(item);
                    }
                }
            }
        }

        //
        // 摘要:
        //     /// 初始化一个 TT.Common.Frame.Model.CommonFilterModel 查询对象(单值). ///
        //
        // 参数:
        //   name:
        //     字段名
        //
        //   filter:
        //     判断条件(=>....like in not in)
        //
        //   value:
        //     检索值
        public LinqFilter(string name, LinqFilterItem filter, object value)
        {
            Name = name;
            Filter = filter;
            Value = value;
        }

        //
        // 摘要:
        //     /// 初始化一个 TT.Common.Frame.Model.CommonFilterModel 查询对象(多值). ///
        //
        // 参数:
        //   name:
        //     字段名
        //
        //   filter:
        //     判断条件(=>....like in not in)
        //
        //   values:
        //     检索值
        public LinqFilter(string name, LinqFilterItem filter, List<object> values)
        {
            Name = name;
            Filter = filter;
            ListValue = values;
        }

        //
        // 摘要:
        //     /// 类型转换 ///
        //
        // 参数:
        //   newType:
        //     转换成的类型
        public void TypeConvert(Type newType)
        {
            if (Value != null && (ListValue == null || ListValue.Count <= 0))
            {
                Value = TypeConvert(Value, newType);
            }
            if (ListValue != null && ListValue.Count > 0)
            {
                for (int i = 0; i < ListValue.Count; i++)
                {
                    ListValue[i] = TypeConvert(ListValue[i], newType);
                }
            }
        }

        //
        // 摘要:
        //     /// 类型转换 ///
        //
        // 参数:
        //   turnObject:
        //     转换的对象
        //
        //   newType:
        //     转换成的类型
        private object TypeConvert(object turnObject, Type newType)
        {
            if (turnObject == null)
            {
                return null;
            }
            if (newType.IsGenericType)
            {
                newType = newType.GetGenericArguments()[0];
            }
            return typeof(IConvertible).IsAssignableFrom(newType) ? Convert.ChangeType(turnObject, newType) : turnObject;
        }

        //
        // 摘要:
        //     /// 构造函数 ///
        public LinqFilter()
        {
        }
    }
}
