using System;
using System.Collections.Generic;
using System.Text;

namespace WebComponentStore.Models
{
    public class User_Detail
    {
        public int UserId { get; set; }
        public string UserName2 { get; set; }
        public int orgid { get; set; }
        public int flag { get; set; }
        public int sex { get; set; }
        public int isjjr { get; set; }
        public int UserGrade { get; set; }
        public string HeadImg { get; set; }
        public DateTime? RzRuzhiDate { get; set; }
        public DateTime? lasttime { get; set; }
        public int CompanyId { get; set; }
        public string mobile { get; set; }
        public string OrgName { get; set; }
    }
}
