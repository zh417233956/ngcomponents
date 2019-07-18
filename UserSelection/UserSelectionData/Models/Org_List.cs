using System;
using System.Collections.Generic;
using System.Text;

namespace UserSelectionData.Models
{
    public class Org_List
    {
        public int? OrgID { get; set; }

        public int OrgLevelKey { get; set; }

        public int OrgParentID { get; set; }
        public string OrgParentIDALL { get; set; }
        public string OrgName { get; set; }

    }
}
