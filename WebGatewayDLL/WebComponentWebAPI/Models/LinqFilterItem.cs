using System;
using System.Collections.Generic;
using System.Text;

namespace WebComponentWebAPI.Models
{
    //
    // 摘要:
    //     /// 检索的枚举 ///
    public enum LinqFilterItem
    {
        //
        // 摘要:
        //     /// > ///
        Dayu,
        //
        // 摘要:
        //     /// >= ///
        Dayudengyu,
        //
        // 摘要:
        //     /// < ///
        Xiaoyu,
        //
        // 摘要:
        //     /// <= ///
        Xiaoyudengyu,
        //
        // 摘要:
        //     /// <> ///
        Budeng,
        //
        // 摘要:
        //     /// = ///
        Deng,
        //
        // 摘要:
        //     /// in ///
        Inlist,
        //
        // 摘要:
        //     /// like ///
        Like,
        //
        // 摘要:
        //     /// not in ///
        Notinlist
    }
}
