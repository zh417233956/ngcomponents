using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace WebComponentWebAPI.Models
{
    //
    // 摘要:
    //     /// 通用排序字段 ///
    public class LinqOrderModel
    {
        //
        // 摘要:
        //     /// 字段名小写 ///
        public string _LowerName;

        //
        // 摘要:
        //     /// 排序名(对就实体类属性名) ///
        public PropertyInfo PInfo;

        //
        // 摘要:
        //     /// 排序(0 ASC 1 DESC) ///
        public LinqOrderType Order;

        //
        // 摘要:
        //     /// 字段名小写 ///
        public string LowerName
        {
            get
            {
                return _LowerName ?? (_LowerName = PInfo.Name.ToLower());
            }
            set
            {
                _LowerName = value;
            }
        }
    }
}
