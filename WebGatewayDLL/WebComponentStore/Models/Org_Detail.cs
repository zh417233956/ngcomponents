using System;
using System.Collections.Generic;
using System.Text;

namespace WebComponentStore.Models
{
    public class Org_Detail
    {
        public int? OrgID { get; set; }

        public int OrgLevelKey { get; set; }

        public int OrgParentID { get; set; }
        public string OrgParentIDALL { get; set; }
        public string OrgName { get; set; }
    }
}
