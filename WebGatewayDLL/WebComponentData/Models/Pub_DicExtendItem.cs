using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WebComponentData.Models
{
    [DataContract(Namespace = "", Name = "T")]
    public class Pub_DicExtendItem
    {
        /// <summary>
        /// [主键][ItemId]
        /// </summary>
        [DataMember]
        public int? ItemId{get; set;}

        /// <summary>
        /// 字典类型主键
        /// </summary>
        [DataMember]
        public int? DicClassId { get; set; }

        /// <summary>
        /// 扩展索引名
        /// </summary>
        [DataMember]
        public string ExtendKey { get; set; }

        /// <summary>
        /// 结构索引StructName
        /// </summary>
        [DataMember]
        public string StructKey { get; set; }

        /// <summary>
        /// DicUseId
        /// </summary>
        [DataMember]
        public int? ItemKey { get; set; }

        /// <summary>
        /// ItemRowIndex
        /// </summary>
        [DataMember]
        public int? ItemRowIndex { get; set; }

        /// <summary>
        /// ItemValue
        /// </summary>
        [DataMember]
        public string ItemValue { get; set; }

        /// <summary>
        /// 添加记录时间
        /// </summary>
        [DataMember]
        public DateTime? AddTime { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        [DataMember]
        public DateTime? LastTime { get; set; }

        /// <summary>
        /// AddUserId
        /// </summary>
        [DataMember]
        public int? AddUserId { get; set; }

        /// <summary>
        /// LastUserId
        /// </summary>
        [DataMember]
        public int? LastUserId { get; set; }

        /// <summary>
        /// disorder
        /// </summary>
        [DataMember]
        public int? disorder { get; set; }

        /// <summary>
        /// [isdel]0
        /// </summary>
        [DataMember]
        public int? isdel { get; set; }
    }
}
