using System;
using System.Collections.Generic;
using System.Text;
using WebComponentWebAPI.Models;

namespace UserSelectionData.Models
{
    //
    // 摘要:
    //     User_list实体
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "", Name = "T")]
    public class User_list : EntityBase
    {
        public User_list()
        { }

        //
        // 摘要:
        //     [IsJYH]是否精英会
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? IsJYH { get; set; }
        //
        // 摘要:
        //     [HeadImg]用户照片
        [System.Runtime.Serialization.DataMemberAttribute]
        public string HeadImg { get; set; }
        //
        // 摘要:
        //     [SellCount]买卖房源数量
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? SellCount { get; set; }
        //
        // 摘要:
        //     [RentCount]租赁房源数量
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? RentCount { get; set; }
        //
        // 摘要:
        //     [SellHTCount]
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? SellHTCount { get; set; }
        //
        // 摘要:
        //     [RentHTCount]
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? RentHTCount { get; set; }
        //
        // 摘要:
        //     [RzRuzhiDate]人资入职时间
        [System.Runtime.Serialization.DataMemberAttribute]
        public DateTime? RzRuzhiDate { get; set; }
        //
        // 摘要:
        //     [IsJiangShi]是否讲师团
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? IsJiangShi { get; set; }
        //
        // 摘要:
        //     [vers]
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? vers { get; set; }
        //
        // 摘要:
        //     [MangoCoin]
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? MangoCoin { get; set; }
        //
        // 摘要:
        //     [lasttime]
        [System.Runtime.Serialization.DataMemberAttribute]
        public DateTime? lasttime { get; set; }
        //
        // 摘要:
        //     [UserIndexShow]是否显示该user 1显示 0不显示
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? UserIndexShow { get; set; }
        //
        // 摘要:
        //     [iWebDomainName]用户自己在网站上的名称
        [System.Runtime.Serialization.DataMemberAttribute]
        public string iWebDomainName { get; set; }
        //
        // 摘要:
        //     [MangoCoinUsed]已消耗的芒果币
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? MangoCoinUsed { get; set; }
        //
        // 摘要:
        //     [ishidden]
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? ishidden { get; set; }
        //
        // 摘要:
        //     [disorder]
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? disorder { get; set; }
        //
        // 摘要:
        //     [SellHTCountTotal]
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? SellHTCountTotal { get; set; }
        //
        // 摘要:
        //     [RentHTCountTotal]
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? RentHTCountTotal { get; set; }
        //
        // 摘要:
        //     [PF_Value_Avg]评分平均值
        [System.Runtime.Serialization.DataMemberAttribute]
        public decimal? PF_Value_Avg { get; set; }
        //
        // 摘要:
        //     [EduLevel]网校级别DicClassId=369
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? EduLevel { get; set; }
        //
        // 摘要:
        //     [CompanyId]公司id
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? CompanyId { get; set; }
        //
        // 摘要:
        //     [AddTime]
        [System.Runtime.Serialization.DataMemberAttribute]
        public DateTime? AddTime { get; set; }
        //
        // 摘要:
        //     [IsZhuanZheng]是否转正 字典285
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? IsZhuanZheng { get; set; }
        //
        // 摘要:
        //     [ZhuanZhengDate]转正时间
        [System.Runtime.Serialization.DataMemberAttribute]
        public DateTime? ZhuanZhengDate { get; set; }
        //
        // 摘要:
        //     [userid_inherit]员工id_继承人
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? userid_inherit { get; set; }
        //
        // 摘要:
        //     [isZhiying]是否直营
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? isZhiying { get; set; }
        //
        // 摘要:
        //     [IsDzChubei]是否储备店长
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? IsDzChubei { get; set; }
        //
        // 摘要:
        //     [RzRuzhiDateLastCompany]当前所在公司入职时间
        [System.Runtime.Serialization.DataMemberAttribute]
        public DateTime? RzRuzhiDateLastCompany { get; set; }
        //
        // 摘要:
        //     [JjrFenzu]经纪人租赁买卖分组
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? JjrFenzu { get; set; }
        //
        // 摘要:
        //     [主键][UserId]员工编号
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? UserId { get; set; }
        //
        // 摘要:
        //     [RoleID]角色ID
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? RoleID { get; set; }
        //
        // 摘要:
        //     [UserName]用户系统姓名,也没有啥用了
        [System.Runtime.Serialization.DataMemberAttribute]
        public string UserName { get; set; }
        //
        // 摘要:
        //     [UserName2]用于显示的名字
        [System.Runtime.Serialization.DataMemberAttribute]
        public string UserName2 { get; set; }
        //
        // 摘要:
        //     [DzBbsUid]论坛UID
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? DzBbsUid { get; set; }
        //
        // 摘要:
        //     [LoginName]用户唯一名,已作废
        [System.Runtime.Serialization.DataMemberAttribute]
        public string LoginName { get; set; }
        //
        // 摘要:
        //     [Password]用户密码
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Password { get; set; }
        //
        // 摘要:
        //     [PasswordMD5]密码MD5
        [System.Runtime.Serialization.DataMemberAttribute]
        public string PasswordMD5 { get; set; }
        //
        // 摘要:
        //     [PassErrorCount]密码错误次数
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? PassErrorCount { get; set; }
        //
        // 摘要:
        //     [rukouKey]入口密码
        [System.Runtime.Serialization.DataMemberAttribute]
        public string rukouKey { get; set; }
        //
        // 摘要:
        //     [RukouKeyMD5]入口KEYMD5
        [System.Runtime.Serialization.DataMemberAttribute]
        public string RukouKeyMD5 { get; set; }
        //
        // 摘要:
        //     [MGBeanCount]芒果豆
        [System.Runtime.Serialization.DataMemberAttribute]
        public decimal? MGBeanCount { get; set; }
        //
        // 摘要:
        //     [groupid]原系统组编号
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? groupid { get; set; }
        //
        // 摘要:
        //     [AreaID]行政区编号
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? AreaID { get; set; }
        //
        // 摘要:
        //     [orgid]组织编号
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? orgid { get; set; }
        //
        // 摘要:
        //     [adduserid]添加人
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? adduserid { get; set; }
        //
        // 摘要:
        //     [flag]开通状态
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? flag { get; set; }
        //
        // 摘要:
        //     [sex]性别 0不详 1男 2 女 字典23
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? sex { get; set; }
        //
        // 摘要:
        //     [orgzu]部门内分组
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? orgzu { get; set; }
        //
        // 摘要:
        //     [isjjr]是否经纪人,字典表ClassID=36
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? isjjr { get; set; }
        //
        // 摘要:
        //     [isjjrhouqin]后勤的职能
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? isjjrhouqin { get; set; }
        //
        // 摘要:
        //     [UserGrade]用户等级,经纪人登记ClassID=34,店长等级ClassID=35
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? UserGrade { get; set; }
        //
        // 摘要:
        //     [GzJifenXZ]行政积分
        [System.Runtime.Serialization.DataMemberAttribute]
        public decimal? GzJifenXZ { get; set; }
        //
        // 摘要:
        //     [MgoParentUserID]MGO上线编号
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? MgoParentUserID { get; set; }
        //
        // 摘要:
        //     [CityID]城市编号
        [System.Runtime.Serialization.DataMemberAttribute]
        public int? CityID { get; set; }

        ////
        //// 摘要:
        ////     本类快速排序
        ////
        //// 参数:
        ////   entityBase:
        ////     比较对象
        ////
        ////   LowerName:
        ////     小写的属性名
        //public override int CompareTo(object entityBase, string LowerName)
        //{
        //    return 0;
        //}
        ////
        //// 摘要:
        ////     本类快速查找
        ////
        //// 参数:
        ////   ColunmName:
        ////     属性名
        //public override object FindColumn(string ColunmName) {
        //    return null;
        //}
    }
}
