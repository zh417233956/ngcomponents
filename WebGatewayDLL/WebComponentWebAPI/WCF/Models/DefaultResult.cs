using System;
using System.Collections.Generic;
using System.Text;

namespace WebComponentWebAPI.WCF.Models
{
    //
    // 摘要:
    //     包含 KEY Type Debug Runtime
    //
    // 类型参数:
    //   MT:
    //     The type of the T.
    [System.Runtime.Serialization.DataContractAttribute(Name = "R_{0}")]
    public class DefaultResult<MT>
    {
        public DefaultResult()
        { }

        //
        // 摘要:
        //     操作名称
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Key { get; set; }
        //
        // 摘要:
        //     数据集合,Add时该值是主键
        [System.Runtime.Serialization.DataMemberAttribute]
        public MT Data { get; set; }
        //
        // 摘要:
        //     加密数据字符串
        [System.Runtime.Serialization.DataMemberAttribute]
        public string RETData { get; set; }
        //
        // 摘要:
        //     调试信息
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Debug { get; set; }
        //
        // 摘要:
        //     执行耗时
        [System.Runtime.Serialization.DataMemberAttribute]
        public double RunTime { get; set; }
        //
        // 摘要:
        //     数据影响行数
        [System.Runtime.Serialization.DataMemberAttribute]
        public int RetInt { get; set; }
    }
}
