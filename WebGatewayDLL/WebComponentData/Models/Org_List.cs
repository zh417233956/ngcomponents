using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WebComponentData.Models
{
    [DataContract(Namespace = "", Name = "T")]
    public class Org_List
    {
        [DataMember]
        public int? OrgID { get; set; }
        [DataMember]
        public int OrgLevelKey { get; set; }
        [DataMember]
        public int OrgParentID { get; set; }
        [DataMember]
        public string OrgParentIDALL { get; set; }
        [DataMember]
        public string OrgName { get; set; }
    }
}
