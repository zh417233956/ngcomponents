﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WebComponentData.Models
{
    /// <summary>
    /// User_list实体
    /// </summary>
    [DataContract(Namespace = "", Name = "T")]
    public class User_list 
    {
        [DataMember]
        public int? UserId { get; set; }
        [DataMember]
        public string UserName2 { get; set; }
        [DataMember]
        public int? orgid { get; set; }
        [DataMember]
        public int? flag { get; set; }
        [DataMember]
        public int? sex { get; set; }
        [DataMember]
        public int? isjjr { get; set; }
        [DataMember]
        public int UserGrade { get; set; }
        [DataMember]
        public string HeadImg { get; set; }
        [DataMember]
        public DateTime? RzRuzhiDate { get; set; }
        [DataMember]
        public DateTime? lasttime { get; set; }
        [DataMember]
        public int? CompanyId { get; set; }
    }
}
