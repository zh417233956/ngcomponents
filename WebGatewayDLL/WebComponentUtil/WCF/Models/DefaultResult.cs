using System;
using System.Runtime.Serialization;

namespace WebComponentUtil.WCF.Models
{
    /// <summary>
    /// 包含 KEY Type  Debug Runtime
    /// </summary>
    /// <typeparam name="MT">The type of the T.</typeparam>
    [Serializable]
    [DataContract(Name = "R_{0}", Namespace = "http://schemas.datacontract.org/2004/07/TT.Common.Frame.Model")]
    public class DefaultResult<MT>
    {
        /// <summary>
        /// 操作名称
        /// </summary>
        [DataMember]
        public string Key { get; set; }
        /// <summary>
        /// 数据集合，添加数据时为主键
        /// </summary>
        [DataMember]
        public MT Data { get; set; }
        /// <summary>
        /// 加密数据字符串
        /// </summary>
        [DataMember]
        public string RETData { get; set; }

        private string _debug;
        /// <summary>
        /// 调试信息
        /// </summary>
        [DataMember]
        public string Debug
        {
            get
            {
                return _debug ?? "";
            }
            set { _debug = value; }
        }
        /// <summary>
        /// 执行耗时
        /// </summary>
        [DataMember]
        public double RunTime { get; set; }
        /// <summary>
        /// 数据影响行数
        /// </summary>
        [DataMember]
        public int RetInt { get; set; }
    }


}