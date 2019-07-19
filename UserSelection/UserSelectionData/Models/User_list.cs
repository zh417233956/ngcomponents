using System;
using System.Runtime.Serialization;
using WebComponentWebAPI.Models;

namespace UserSelectionData.Models
{
    /// <summary>
    /// User_list实体
    /// </summary>
    [DataContract(Namespace = "", Name = "T")]
    public class User_list : EntityBase
    {
        [DataMember]
        public int? UserId { get; set; }
        public string UserName2 { get; set; }
        public int? orgid { get; set; }
        public int flag { get; set; }
        public int sex { get; set; }
        public int? isjjr { get; set; }
        public int UserGrade { get; set; }
        public string HeadImg { get; set; }
        public DateTime? RzRuzhiDate { get; set; }
        public DateTime? lasttime { get; set; }
        public int CompanyId { get; set; }
    }
}
