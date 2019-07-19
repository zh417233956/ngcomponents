using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WebComponentData.Models
{
    [DataContract(Namespace = "", Name = "T")]
    public class Pub_Dict
    {
        /// <summary>
        /// 字典编号
        /// </summary>
        [DataMember]
        public int? DicID { get; set; }

        /// <summary>
        /// 字典类别编号
        /// </summary>
        [DataMember]
        public int? DicClassID { get; set; }

        /// <summary>
        /// 本身使用的ID
        /// </summary>
        [DataMember]
        public int? DictUseId { get; set; }

        /// <summary>
        /// 字典名称
        /// </summary>
        [DataMember]
        public string DicName { get; set; }

        /// <summary>
        /// 字典描述
        /// </summary>
        [DataMember]
        public string DicMemo { get; set; }

        /// <summary>
        /// 添加人
        /// </summary>
        [DataMember]
        public int? adduserid { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime? addtime { get; set; }

        /// <summary>
        /// 优先等级
        /// </summary>
        [DataMember]
        public int? disorder { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [DataMember]
        public int? isdel { get; set; }

        /// <summary>
        /// 城市ID
        /// </summary>
        [DataMember]
        public int? cityid { get; set; }

        /// <summary>
        /// vers
        /// </summary>
        [DataMember]
        public int? vers { get; set; }

        /// <summary>
        /// lasttime
        /// </summary>
        [DataMember]
        public DateTime? lasttime { get; set; }
    }
}
