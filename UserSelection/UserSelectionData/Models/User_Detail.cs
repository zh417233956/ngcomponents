using System;
using System.Collections.Generic;
using System.Text;
using WebComponentWebAPI.Models;

namespace UserSelectionData.Models
{
    //
    // 摘要:
    //     /// 重写的UserDetail ///
    [Serializable]
    public class User_Detail : EntityBase
    {
        //
        // 摘要:
        //     /// [主键][员工编号]员工编号 ///
        private int? _UserId;

        //
        // 摘要:
        //     /// [原员工编号字段]原员工编号字段 ///
        private int? _autoid;

        //
        // 摘要:
        //     /// [添加时间]添加时间 ///
        private DateTime? _addtime;

        //
        // 摘要:
        //     /// [数据来源]数据来源 ///
        private int? _DBSource;

        //
        // 摘要:
        //     /// [登陆次数]登陆次数 ///
        private int? _LoginCount;

        //
        // 摘要:
        //     /// [最后登陆时间]最后登陆时间 ///
        private DateTime? _LoginDate;

        //
        // 摘要:
        //     /// [最后活动时间]最后活动时间 ///
        private DateTime? _LiveDate;

        //
        // 摘要:
        //     /// [前台查看次数]前台查看次数 ///
        private int? _ViewCount;

        //
        // 摘要:
        //     /// [后台查看次数]后台查看次数 ///
        private int? _MisViewCount;

        //
        // 摘要:
        //     /// [当前操作位置]当前操作位置 ///
        private string _LastBehavior;

        //
        // 摘要:
        //     /// [角色ID]角色ID ///
        private int? _RoleID;

        //
        // 摘要:
        //     /// [用户系统姓名]用户系统姓名 ///
        private string _UserName;

        //
        // 摘要:
        //     /// [用户真实姓名]用户真实姓名 ///
        private string _UserName2;

        //
        // 摘要:
        //     /// [论坛UID]论坛UID ///
        private int? _DzBbsUid;

        //
        // 摘要:
        //     /// [用户登录名]用户登录名 ///
        private string _LoginName;

        //
        // 摘要:
        //     /// [用户密码]用户密码 ///
        private string _Password;

        //
        // 摘要:
        //     /// [密码MD5]密码MD5 ///
        private string _PasswordMD5;

        //
        // 摘要:
        //     /// [密码错误次数]密码错误次数 ///
        private int? _PassErrorCount;

        //
        // 摘要:
        //     /// [入口密码]入口密码 ///
        private string _rukouKey;

        //
        // 摘要:
        //     /// [入口KEYMD5]入口KEYMD5 ///
        private string _RukouKeyMD5;

        //
        // 摘要:
        //     /// [原系统组编号]原系统组编号 ///
        private int? _groupid;

        //
        // 摘要:
        //     /// [城市编号]城市编号 ///
        private int? _CityID;

        //
        // 摘要:
        //     /// [行政区编号]行政区编号 ///
        private int? _AreaID;

        //
        // 摘要:
        //     /// [组织编号]组织编号 ///
        private int? _orgid;

        //
        // 摘要:
        //     /// [添加人]添加人 ///
        private int? _adduserid;

        //
        // 摘要:
        //     /// [开通状态]开通状态 ///
        private int? _flag;

        //
        // 摘要:
        //     /// [性别]性别 ///
        private int? _sex;

        //
        // 摘要:
        //     /// [部门内分组]部门内分组 ///
        private int? _orgzu;

        //
        // 摘要:
        //     /// [是否经纪人,字典表ClassID=36]是否经纪人,字典表ClassID=36 ///
        private int? _isjjr;

        //
        // 摘要:
        //     /// [用户等级,经纪人登记ClassID=34,店长等级ClassID=35]用户等级,经纪人登记ClassID=34,店长等级ClassID=35
        //     ///
        private int? _UserGrade;

        //
        // 摘要:
        //     /// [行政积分]行政积分 ///
        private decimal? _GzJifenXZ;

        //
        // 摘要:
        //     /// [MGO上线编号]MGO上线编号 ///
        private int? _MgoParentUserID;

        //
        // 摘要:
        //     /// [经纪人租赁买卖分组]经纪人租赁买卖分组 ///
        private int? _JjrFenzu;

        //
        // 摘要:
        //     /// [是否精英会]是否精英会 ///
        private int? _IsJYH;

        //
        // 摘要:
        //     /// [是否储备店长]是否储备店长 ///
        private int? _IsDzChubei;

        //
        // 摘要:
        //     /// [是否直营]是否直营 ///
        private int? _isZhiying;

        //
        // 摘要:
        //     /// [用户照片]用户照片 ///
        private string _HeadImg;

        //
        // 摘要:
        //     /// [买卖房源数量]买卖房源数量 ///
        private int? _SellCount;

        //
        // 摘要:
        //     /// [租赁房源数量]租赁房源数量 ///
        private int? _RentCount;

        //
        // 摘要:
        //     /// [人资入职时间]人资入职时间 ///
        private DateTime? _RzRuzhiDate;

        //
        // 摘要:
        //     /// [是否讲师团]是否讲师团 ///
        private int? _IsJiangShi;

        //
        // 摘要:
        //     /// [] ///
        private int? _vers;

        //
        // 摘要:
        //     /// [] ///
        private int? _MangoCoin;

        //
        // 摘要:
        //     /// [] ///
        private int? _SellHTCount;

        //
        // 摘要:
        //     /// [] ///
        private int? _RentHTCount;

        //
        // 摘要:
        //     /// [] ///
        private int? _SellHTCountTotal;

        //
        // 摘要:
        //     /// [] ///
        private int? _RentHTCountTotal;

        //
        // 摘要:
        //     /// [] ///
        private DateTime? _lasttime;

        //
        // 摘要:
        //     /// [邮箱]邮箱 ///
        private string _email;

        //
        // 摘要:
        //     /// [QQ号]QQ号 ///
        private string _qq;

        //
        // 摘要:
        //     /// [手机号码]手机号码 ///
        private string _mobile;

        //
        // 摘要:
        //     /// [手机小号]手机小号 ///
        private string _mobileXiaohao;

        //
        // 摘要:
        //     /// [备用手机号]备用手机号 ///
        private string _mobileBeyong;

        //
        // 摘要:
        //     /// [身份证号码]身份证号码 ///
        private string _IDCNO;

        //
        // 摘要:
        //     /// [个人简介]个人简介 ///
        private string _JianJie;

        //
        // 摘要:
        //     /// [首次开单日期]首次开单日期 ///
        private DateTime? _yj_first;

        //
        // 摘要:
        //     /// [MGO推荐方式]MGO推荐方式 ///
        private int? _MgoChanquan;

        //
        // 摘要:
        //     /// [用户描述]用户描述 ///
        private string _UserMemo;

        //
        // 摘要:
        //     /// [用户照片大]用户照片大 ///
        private string _HeadImgBig;

        //
        // 摘要:
        //     /// [进店时间]进店时间 ///
        private DateTime? _jindiandate;

        //
        // 摘要:
        //     /// [人资首次入职时间]人资首次入职时间 ///
        private DateTime? _RzRuzhiDateFirst;

        //
        // 摘要:
        //     /// [人资离职时间]人资离职时间 ///
        private DateTime? _RzLeaveDate;

        //
        // 摘要:
        //     /// [用户职位]用户职位 ///
        private string _Zhiwei;

        //
        // 摘要:
        //     /// [人资转店]人资转店 ///
        private string _RzZhuanDian;

        //
        // 摘要:
        //     /// [人资转人]人资转人 ///
        private string _RzZhuanRen;

        //
        // 摘要:
        //     /// [身高]身高 ///
        private int? _shengao;

        //
        // 摘要:
        //     /// [腰围]腰围 ///
        private int? _yaowei;

        //
        // 摘要:
        //     /// [胸围]胸围 ///
        private int? _xiongwei;

        //
        // 摘要:
        //     /// [qq密码]qq密码 ///
        private string _qqmima;

        //
        // 摘要:
        //     /// [qq找回密码问题]qq找回密码问题 ///
        private string _qqonewt;

        //
        // 摘要:
        //     /// [qq找回密码问题答案]qq找回密码问题答案 ///
        private string _qqonewtda;

        //
        // 摘要:
        //     /// [QQ问题2]QQ问题2 ///
        private string _qqtwowt;

        //
        // 摘要:
        //     /// [QQ答案2]QQ答案2 ///
        private string _qqtwowtda;

        //
        // 摘要:
        //     /// [QQ问题3]QQ问题3 ///
        private string _qqthreewt;

        //
        // 摘要:
        //     /// [QQ答案3]QQ答案3 ///
        private string _qqthreewtda;

        //
        // 摘要:
        //     /// [端口个人介绍]端口个人介绍 ///
        private string _PortIntroduction;

        //
        // 摘要:
        //     /// [赌场下注次数]赌场下注次数 ///
        private int? _PkCount;

        //
        // 摘要:
        //     /// [赌场赢钱数]赌场赢钱数 ///
        private decimal? _PkWinMoney;

        //
        // 摘要:
        //     /// [赌场胜率]赌场胜率 ///
        private decimal? _PkWinPer;

        //
        // 摘要:
        //     /// [初始密码,开通帐号或重置密码明文存储,修改密码后清空]初始密码,开通帐号或重置密码明文存储,修改密码后清空 ///
        private string _PassFirst;

        //
        // 摘要:
        //     /// [初始密码,开通帐号或重置密码明文存储,修改密码后清空]初始密码,开通帐号或重置密码明文存储,修改密码后清空 ///
        private string _RukouFirst;

        //
        // 摘要:
        //     /// [最后修改密码时间]最后修改密码时间 ///
        private DateTime? _PassLastTime;

        //
        // 摘要:
        //     /// [最后修改入口密码时间]最后修改入口密码时间 ///
        private DateTime? _RukouLastTime;

        //
        // 摘要:
        //     /// [] ///
        private string _QQWeibo;

        //
        // 摘要:
        //     /// [] ///
        private string _SinaWeibo;

        //
        // 摘要:
        //     /// [] ///
        private string _QQWeixin;

        //
        // 摘要:
        //     /// [主键][员工编号]员工编号 ///
        public int? UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
            }
        }

        //
        // 摘要:
        //     /// [原员工编号字段]原员工编号字段 ///
        public int? autoid
        {
            get
            {
                return _autoid;
            }
            set
            {
                _autoid = value;
            }
        }

        //
        // 摘要:
        //     /// [添加时间]添加时间 ///
        public DateTime? addtime
        {
            get
            {
                return _addtime;
            }
            set
            {
                _addtime = value;
            }
        }

        //
        // 摘要:
        //     /// [数据来源]数据来源 ///
        public int? DBSource
        {
            get
            {
                return _DBSource;
            }
            set
            {
                _DBSource = value;
            }
        }

        //
        // 摘要:
        //     /// [登陆次数]登陆次数 ///
        public int? LoginCount
        {
            get
            {
                return _LoginCount;
            }
            set
            {
                _LoginCount = value;
            }
        }

        //
        // 摘要:
        //     /// [最后登陆时间]最后登陆时间 ///
        public DateTime? LoginDate
        {
            get
            {
                return _LoginDate;
            }
            set
            {
                _LoginDate = value;
            }
        }

        //
        // 摘要:
        //     /// [最后活动时间]最后活动时间 ///
        public DateTime? LiveDate
        {
            get
            {
                return _LiveDate;
            }
            set
            {
                _LiveDate = value;
            }
        }

        //
        // 摘要:
        //     /// [前台查看次数]前台查看次数 ///
        public int? ViewCount
        {
            get
            {
                return _ViewCount;
            }
            set
            {
                _ViewCount = value;
            }
        }

        //
        // 摘要:
        //     /// [后台查看次数]后台查看次数 ///
        public int? MisViewCount
        {
            get
            {
                return _MisViewCount;
            }
            set
            {
                _MisViewCount = value;
            }
        }

        //
        // 摘要:
        //     /// [当前操作位置]当前操作位置 ///
        public string LastBehavior
        {
            get
            {
                return _LastBehavior;
            }
            set
            {
                _LastBehavior = value;
            }
        }

        //
        // 摘要:
        //     /// [角色ID]角色ID ///
        public int? RoleID
        {
            get
            {
                return _RoleID;
            }
            set
            {
                _RoleID = value;
            }
        }

        //
        // 摘要:
        //     /// [用户系统姓名]用户系统姓名 ///
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }

        //
        // 摘要:
        //     /// [用户真实姓名]用户真实姓名 ///
        public string UserName2
        {
            get
            {
                return _UserName2;
            }
            set
            {
                _UserName2 = value;
            }
        }

        //
        // 摘要:
        //     /// [论坛UID]论坛UID ///
        public int? DzBbsUid
        {
            get
            {
                return _DzBbsUid;
            }
            set
            {
                _DzBbsUid = value;
            }
        }

        //
        // 摘要:
        //     /// [用户登录名]用户登录名 ///
        public string LoginName
        {
            get
            {
                return _LoginName;
            }
            set
            {
                _LoginName = value;
            }
        }

        //
        // 摘要:
        //     /// [用户密码]用户密码 ///
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

        //
        // 摘要:
        //     /// [密码MD5]密码MD5 ///
        public string PasswordMD5
        {
            get
            {
                return _PasswordMD5;
            }
            set
            {
                _PasswordMD5 = value;
            }
        }

        //
        // 摘要:
        //     /// [密码错误次数]密码错误次数 ///
        public int? PassErrorCount
        {
            get
            {
                return _PassErrorCount;
            }
            set
            {
                _PassErrorCount = value;
            }
        }

        //
        // 摘要:
        //     /// [入口密码]入口密码 ///
        public string rukouKey
        {
            get
            {
                return _rukouKey;
            }
            set
            {
                _rukouKey = value;
            }
        }

        //
        // 摘要:
        //     /// [入口KEYMD5]入口KEYMD5 ///
        public string RukouKeyMD5
        {
            get
            {
                return _RukouKeyMD5;
            }
            set
            {
                _RukouKeyMD5 = value;
            }
        }

        //
        // 摘要:
        //     /// [原系统组编号]原系统组编号 ///
        public int? groupid
        {
            get
            {
                return _groupid;
            }
            set
            {
                _groupid = value;
            }
        }

        //
        // 摘要:
        //     /// [城市编号]城市编号 ///
        public int? CityID
        {
            get
            {
                return _CityID;
            }
            set
            {
                _CityID = value;
            }
        }

        //
        // 摘要:
        //     /// [行政区编号]行政区编号 ///
        public int? AreaID
        {
            get
            {
                return _AreaID;
            }
            set
            {
                _AreaID = value;
            }
        }

        //
        // 摘要:
        //     /// [组织编号]组织编号 ///
        public int? orgid
        {
            get
            {
                return _orgid;
            }
            set
            {
                _orgid = value;
            }
        }

        //
        // 摘要:
        //     /// [添加人]添加人 ///
        public int? adduserid
        {
            get
            {
                return _adduserid;
            }
            set
            {
                _adduserid = value;
            }
        }

        //
        // 摘要:
        //     /// [开通状态]开通状态 ///
        public int? flag
        {
            get
            {
                return _flag;
            }
            set
            {
                _flag = value;
            }
        }

        //
        // 摘要:
        //     /// [性别]性别 ///
        public int? sex
        {
            get
            {
                return _sex;
            }
            set
            {
                _sex = value;
            }
        }

        //
        // 摘要:
        //     /// [部门内分组]部门内分组 ///
        public int? orgzu
        {
            get
            {
                return _orgzu;
            }
            set
            {
                _orgzu = value;
            }
        }

        //
        // 摘要:
        //     /// [是否经纪人,字典表ClassID=36]是否经纪人,字典表ClassID=36 ///
        public int? isjjr
        {
            get
            {
                return _isjjr;
            }
            set
            {
                _isjjr = value;
            }
        }

        //
        // 摘要:
        //     /// [用户等级,经纪人登记ClassID=34,店长等级ClassID=35]用户等级,经纪人登记ClassID=34,店长等级ClassID=35
        //     ///
        public int? UserGrade
        {
            get
            {
                return _UserGrade;
            }
            set
            {
                _UserGrade = value;
            }
        }

        //
        // 摘要:
        //     /// [行政积分]行政积分 ///
        public decimal? GzJifenXZ
        {
            get
            {
                return _GzJifenXZ;
            }
            set
            {
                _GzJifenXZ = value;
            }
        }

        //
        // 摘要:
        //     /// [MGO上线编号]MGO上线编号 ///
        public int? MgoParentUserID
        {
            get
            {
                return _MgoParentUserID;
            }
            set
            {
                _MgoParentUserID = value;
            }
        }

        //
        // 摘要:
        //     /// [经纪人租赁买卖分组]经纪人租赁买卖分组 ///
        public int? JjrFenzu
        {
            get
            {
                return _JjrFenzu;
            }
            set
            {
                _JjrFenzu = value;
            }
        }

        //
        // 摘要:
        //     /// [是否精英会]是否精英会 ///
        public int? IsJYH
        {
            get
            {
                return _IsJYH;
            }
            set
            {
                _IsJYH = value;
            }
        }

        //
        // 摘要:
        //     /// [是否储备店长]是否储备店长 ///
        public int? IsDzChubei
        {
            get
            {
                return _IsDzChubei;
            }
            set
            {
                _IsDzChubei = value;
            }
        }

        //
        // 摘要:
        //     /// [是否直营]是否直营 ///
        public int? isZhiying
        {
            get
            {
                return _isZhiying;
            }
            set
            {
                _isZhiying = value;
            }
        }

        //
        // 摘要:
        //     /// [用户照片]用户照片 ///
        public string HeadImg
        {
            get
            {
                return _HeadImg;
            }
            set
            {
                _HeadImg = value;
            }
        }

        //
        // 摘要:
        //     /// [买卖房源数量]买卖房源数量 ///
        public int? SellCount
        {
            get
            {
                return _SellCount;
            }
            set
            {
                _SellCount = value;
            }
        }

        //
        // 摘要:
        //     /// [租赁房源数量]租赁房源数量 ///
        public int? RentCount
        {
            get
            {
                return _RentCount;
            }
            set
            {
                _RentCount = value;
            }
        }

        //
        // 摘要:
        //     /// [人资入职时间]人资入职时间 ///
        public DateTime? RzRuzhiDate
        {
            get
            {
                return _RzRuzhiDate;
            }
            set
            {
                _RzRuzhiDate = value;
            }
        }

        //
        // 摘要:
        //     /// [是否讲师团]是否讲师团 ///
        public int? IsJiangShi
        {
            get
            {
                return _IsJiangShi;
            }
            set
            {
                _IsJiangShi = value;
            }
        }

        //
        // 摘要:
        //     /// [] ///
        public int? vers
        {
            get
            {
                return _vers;
            }
            set
            {
                _vers = value;
            }
        }

        //
        // 摘要:
        //     /// [] ///
        public int? MangoCoin
        {
            get
            {
                return _MangoCoin;
            }
            set
            {
                _MangoCoin = value;
            }
        }

        //
        // 摘要:
        //     /// [] ///
        public int? SellHTCount
        {
            get
            {
                return _SellHTCount;
            }
            set
            {
                _SellHTCount = value;
            }
        }

        //
        // 摘要:
        //     /// [] ///
        public int? RentHTCount
        {
            get
            {
                return _RentHTCount;
            }
            set
            {
                _RentHTCount = value;
            }
        }

        //
        // 摘要:
        //     /// [] ///
        public int? SellHTCountTotal
        {
            get
            {
                return _SellHTCountTotal;
            }
            set
            {
                _SellHTCountTotal = value;
            }
        }

        //
        // 摘要:
        //     /// [] ///
        public int? RentHTCountTotal
        {
            get
            {
                return _RentHTCountTotal;
            }
            set
            {
                _RentHTCountTotal = value;
            }
        }

        //
        // 摘要:
        //     /// [] ///
        public DateTime? lasttime
        {
            get
            {
                return _lasttime;
            }
            set
            {
                _lasttime = value;
            }
        }

        //
        // 摘要:
        //     /// [iWebDomainName]用户自己在网站上的名称 ///
        //
        // 言论：
        //     EditBy:Zxf
        public string iWebDomainName
        {
            get;
            set;
        }

        //
        // 摘要:
        //     /// [UserIndexShow]是否显示该user 1显示 0不显示 ///
        //
        // 言论：
        //     EditBy:Zxf
        public int? UserIndexShow
        {
            get;
            set;
        }

        //
        // 摘要:
        //     /// 是否隐藏 0 ->不隐藏 1->隐藏 ///
        //
        // 言论：
        //     EditBy:Zxf
        public int? ishidden
        {
            get;
            set;
        }

        //
        // 摘要:
        //     [MangoCoinUsed]已消耗的芒果币
        public int? MangoCoinUsed
        {
            get;
            set;
        }

        //
        // 摘要:
        //     [disorder]
        public int? disorder
        {
            get;
            set;
        }

        //
        // 摘要:
        //     [PF_Value_Avg]评分平均值
        public decimal? PF_Value_Avg
        {
            get;
            set;
        }

        //
        // 摘要:
        //     [EduLevel]网校级别DicClassId=369
        public int? EduLevel
        {
            get;
            set;
        }

        //
        // 摘要:
        //     [CompanyId]公司id
        public int? CompanyId
        {
            get;
            set;
        }

        //
        // 摘要:
        //     [IsZhuanZheng]是否转正 字典285
        public int? IsZhuanZheng
        {
            get;
            set;
        }

        //
        // 摘要:
        //     [ZhuanZhengDate]转正时间
        public DateTime? ZhuanZhengDate
        {
            get;
            set;
        }

        //
        // 摘要:
        //     [userid_inherit]员工id_继承人
        public int? userid_inherit
        {
            get;
            set;
        }

        //
        // 摘要:
        //     /// [UCID]UserCenter的UserID ///
        public int? UCID
        {
            get;
            set;
        }

        //
        // 摘要:
        //     /// [邮箱]邮箱 ///
        public string email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        //
        // 摘要:
        //     /// [QQ号]QQ号 ///
        public string qq
        {
            get
            {
                return _qq;
            }
            set
            {
                _qq = value;
            }
        }

        //
        // 摘要:
        //     /// [手机号码]手机号码 ///
        public string mobile
        {
            get
            {
                return _mobile;
            }
            set
            {
                _mobile = value;
            }
        }

        //
        // 摘要:
        //     /// [手机小号]手机小号 ///
        public string mobileXiaohao
        {
            get
            {
                return _mobileXiaohao;
            }
            set
            {
                _mobileXiaohao = value;
            }
        }

        //
        // 摘要:
        //     /// [备用手机号]备用手机号 ///
        public string mobileBeyong
        {
            get
            {
                return _mobileBeyong;
            }
            set
            {
                _mobileBeyong = value;
            }
        }

        //
        // 摘要:
        //     /// [身份证号码]身份证号码 ///
        public string IDCNO
        {
            get
            {
                return _IDCNO;
            }
            set
            {
                _IDCNO = value;
            }
        }

        //
        // 摘要:
        //     /// [个人简介]个人简介 ///
        public string JianJie
        {
            get
            {
                return _JianJie;
            }
            set
            {
                _JianJie = value;
            }
        }

        //
        // 摘要:
        //     /// [首次开单日期]首次开单日期 ///
        public DateTime? yj_first
        {
            get
            {
                return _yj_first;
            }
            set
            {
                _yj_first = value;
            }
        }

        //
        // 摘要:
        //     /// [MGO推荐方式]MGO推荐方式 ///
        public int? MgoChanquan
        {
            get
            {
                return _MgoChanquan;
            }
            set
            {
                _MgoChanquan = value;
            }
        }

        //
        // 摘要:
        //     /// [用户描述]用户描述 ///
        public string UserMemo
        {
            get
            {
                return _UserMemo;
            }
            set
            {
                _UserMemo = value;
            }
        }

        //
        // 摘要:
        //     /// [用户照片大]用户照片大 ///
        public string HeadImgBig
        {
            get
            {
                return _HeadImgBig;
            }
            set
            {
                _HeadImgBig = value;
            }
        }

        //
        // 摘要:
        //     /// [进店时间]进店时间 ///
        public DateTime? jindiandate
        {
            get
            {
                return _jindiandate;
            }
            set
            {
                _jindiandate = value;
            }
        }

        //
        // 摘要:
        //     /// [人资首次入职时间]人资首次入职时间 ///
        public DateTime? RzRuzhiDateFirst
        {
            get
            {
                return _RzRuzhiDateFirst;
            }
            set
            {
                _RzRuzhiDateFirst = value;
            }
        }

        //
        // 摘要:
        //     /// [人资离职时间]人资离职时间 ///
        public DateTime? RzLeaveDate
        {
            get
            {
                return _RzLeaveDate;
            }
            set
            {
                _RzLeaveDate = value;
            }
        }

        //
        // 摘要:
        //     /// [用户职位]用户职位 ///
        public string Zhiwei
        {
            get
            {
                return _Zhiwei;
            }
            set
            {
                _Zhiwei = value;
            }
        }

        //
        // 摘要:
        //     /// [人资转店]人资转店 ///
        public string RzZhuanDian
        {
            get
            {
                return _RzZhuanDian;
            }
            set
            {
                _RzZhuanDian = value;
            }
        }

        //
        // 摘要:
        //     /// [人资转人]人资转人 ///
        public string RzZhuanRen
        {
            get
            {
                return _RzZhuanRen;
            }
            set
            {
                _RzZhuanRen = value;
            }
        }

        //
        // 摘要:
        //     /// [身高]身高 ///
        public int? shengao
        {
            get
            {
                return _shengao;
            }
            set
            {
                _shengao = value;
            }
        }

        //
        // 摘要:
        //     /// [腰围]腰围 ///
        public int? yaowei
        {
            get
            {
                return _yaowei;
            }
            set
            {
                _yaowei = value;
            }
        }

        //
        // 摘要:
        //     /// [胸围]胸围 ///
        public int? xiongwei
        {
            get
            {
                return _xiongwei;
            }
            set
            {
                _xiongwei = value;
            }
        }

        //
        // 摘要:
        //     /// [qq密码]qq密码 ///
        public string qqmima
        {
            get
            {
                return _qqmima;
            }
            set
            {
                _qqmima = value;
            }
        }

        //
        // 摘要:
        //     /// [qq找回密码问题]qq找回密码问题 ///
        public string qqonewt
        {
            get
            {
                return _qqonewt;
            }
            set
            {
                _qqonewt = value;
            }
        }

        //
        // 摘要:
        //     /// [qq找回密码问题答案]qq找回密码问题答案 ///
        public string qqonewtda
        {
            get
            {
                return _qqonewtda;
            }
            set
            {
                _qqonewtda = value;
            }
        }

        //
        // 摘要:
        //     /// [QQ问题2]QQ问题2 ///
        public string qqtwowt
        {
            get
            {
                return _qqtwowt;
            }
            set
            {
                _qqtwowt = value;
            }
        }

        //
        // 摘要:
        //     /// [QQ答案2]QQ答案2 ///
        public string qqtwowtda
        {
            get
            {
                return _qqtwowtda;
            }
            set
            {
                _qqtwowtda = value;
            }
        }

        //
        // 摘要:
        //     /// [QQ问题3]QQ问题3 ///
        public string qqthreewt
        {
            get
            {
                return _qqthreewt;
            }
            set
            {
                _qqthreewt = value;
            }
        }

        //
        // 摘要:
        //     /// [QQ答案3]QQ答案3 ///
        public string qqthreewtda
        {
            get
            {
                return _qqthreewtda;
            }
            set
            {
                _qqthreewtda = value;
            }
        }

        //
        // 摘要:
        //     /// [端口个人介绍]端口个人介绍 ///
        public string PortIntroduction
        {
            get
            {
                return _PortIntroduction;
            }
            set
            {
                _PortIntroduction = value;
            }
        }

        //
        // 摘要:
        //     /// [赌场下注次数]赌场下注次数 ///
        public int? PkCount
        {
            get
            {
                return _PkCount;
            }
            set
            {
                _PkCount = value;
            }
        }

        //
        // 摘要:
        //     /// [赌场赢钱数]赌场赢钱数 ///
        public decimal? PkWinMoney
        {
            get
            {
                return _PkWinMoney;
            }
            set
            {
                _PkWinMoney = value;
            }
        }

        //
        // 摘要:
        //     /// [赌场胜率]赌场胜率 ///
        public decimal? PkWinPer
        {
            get
            {
                return _PkWinPer;
            }
            set
            {
                _PkWinPer = value;
            }
        }

        //
        // 摘要:
        //     /// [初始密码,开通帐号或重置密码明文存储,修改密码后清空]初始密码,开通帐号或重置密码明文存储,修改密码后清空 ///
        public string PassFirst
        {
            get
            {
                return _PassFirst;
            }
            set
            {
                _PassFirst = value;
            }
        }

        //
        // 摘要:
        //     /// [初始密码,开通帐号或重置密码明文存储,修改密码后清空]初始密码,开通帐号或重置密码明文存储,修改密码后清空 ///
        public string RukouFirst
        {
            get
            {
                return _RukouFirst;
            }
            set
            {
                _RukouFirst = value;
            }
        }

        //
        // 摘要:
        //     /// [最后修改密码时间]最后修改密码时间 ///
        public DateTime? PassLastTime
        {
            get
            {
                return _PassLastTime;
            }
            set
            {
                _PassLastTime = value;
            }
        }

        //
        // 摘要:
        //     /// [最后修改入口密码时间]最后修改入口密码时间 ///
        public DateTime? RukouLastTime
        {
            get
            {
                return _RukouLastTime;
            }
            set
            {
                _RukouLastTime = value;
            }
        }

        //
        // 摘要:
        //     /// [] ///
        public string QQWeibo
        {
            get
            {
                return _QQWeibo;
            }
            set
            {
                _QQWeibo = value;
            }
        }

        //
        // 摘要:
        //     /// [] ///
        public string SinaWeibo
        {
            get
            {
                return _SinaWeibo;
            }
            set
            {
                _SinaWeibo = value;
            }
        }

        //
        // 摘要:
        //     /// [] ///
        public string QQWeixin
        {
            get
            {
                return _QQWeixin;
            }
            set
            {
                _QQWeixin = value;
            }
        }

        //
        // 摘要:
        //     /// 职位描述 ///
        //
        // 言论：
        //     EditBy:Zxf
        public string ZhiWeiExtent
        {
            get;
            set;
        }

        //
        // 摘要:
        //     /// 职位描述 ///
        //
        // 言论：
        //     EditBy:Zxf
        public string FenJiHao
        {
            get;
            set;
        }

        //
        // 摘要:
        //     /// 组织名称 ///
        public string OrgName;//=> orgid.Org()?.OrgName ?? "";

        //
        // 摘要:
        //     [MGBeanCount]芒果豆
        public decimal? MGBeanCount
        {
            get;
            set;
        }

        //private static User_list CopyToBaseItem(User_Detail from, User_list to)
        //{
        //    to.set_UserId(from.UserId);
        //    to.set_UserName2(from.UserName2);
        //    return to;
        //}

        //private static User_show CopyToBaseItem(User_Detail from, User_show to)
        //{
        //    to.set_UserId(from.UserId);
        //    return to;
        //}

        //private static User_Detail CopyFromBaseItem(User_show from, User_Detail to)
        //{
        //    to.UserId = from.get_UserId();
        //    return to;
        //}

        //private static User_Detail CopyFromBaseItem(User_list from, User_Detail to)
        //{
        //    to.UserId = from.get_UserId();
        //    to.UserName2 = from.get_UserName2();
        //    return to;
        //}

        ////
        //// 摘要:
        ////     /// ///
        ////
        //// 参数:
        ////   from:
        //public static implicit operator User_Detail(User_list from)
        //{
        //    return CopyFromBaseItem(from, new User_Detail());
        //}

        ////
        //// 摘要:
        ////     /// ///
        ////
        //// 参数:
        ////   from:
        //public static implicit operator User_list(User_Detail from)
        //{
        //    //IL_0002: Unknown result type (might be due to invalid IL or missing references)
        //    //IL_000c: Expected O, but got Unknown
        //    return User_Detail.CopyToBaseItem(from, new User_list());
        //}

        ////
        //// 摘要:
        ////     /// ///
        ////
        //// 参数:
        ////   from:
        //public static implicit operator User_Detail(User_show from)
        //{
        //    return CopyFromBaseItem(from, new User_Detail());
        //}

        ////
        //// 摘要:
        ////     /// ///
        ////
        //// 参数:
        ////   from:
        //public static implicit operator User_show(User_Detail from)
        //{
        //    //IL_0002: Unknown result type (might be due to invalid IL or missing references)
        //    //IL_000c: Expected O, but got Unknown
        //    return User_Detail.CopyToBaseItem(from, new User_show());
        //}

        //
        // 摘要:
        //     /// 本类快速排序 ///
        //
        // 参数:
        //   entityBase:
        //     比较对象
        //
        //   LowerName:
        //     小写的属性名
        public override int CompareTo(object entityBase, string LowerName)
        {
            User_Detail user_Detail = entityBase as User_Detail;
            if (user_Detail != null)
            {
                switch (LowerName)
                {
                    case "userid":
                        if (!UserId.HasValue && !user_Detail.UserId.HasValue)
                        {
                            return 0;
                        }
                        if (!UserId.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.UserId.HasValue) ? 1 : user_Detail.UserId.Value.CompareTo(UserId.Value);
                    case "autoid":
                        if (!autoid.HasValue && !user_Detail.autoid.HasValue)
                        {
                            return 0;
                        }
                        if (!autoid.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.autoid.HasValue) ? 1 : user_Detail.autoid.Value.CompareTo(autoid.Value);
                    case "addtime":
                        if (!addtime.HasValue && !user_Detail.addtime.HasValue)
                        {
                            return 0;
                        }
                        if (!addtime.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.addtime.HasValue) ? 1 : DateTime.Compare(user_Detail.addtime.Value, addtime.Value);
                    case "dbsource":
                        if (!DBSource.HasValue && !user_Detail.DBSource.HasValue)
                        {
                            return 0;
                        }
                        if (!DBSource.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.DBSource.HasValue) ? 1 : user_Detail.DBSource.Value.CompareTo(DBSource.Value);
                    case "logincount":
                        if (!LoginCount.HasValue && !user_Detail.LoginCount.HasValue)
                        {
                            return 0;
                        }
                        if (!LoginCount.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.LoginCount.HasValue) ? 1 : user_Detail.LoginCount.Value.CompareTo(LoginCount.Value);
                    case "logindate":
                        if (!LoginDate.HasValue && !user_Detail.LoginDate.HasValue)
                        {
                            return 0;
                        }
                        if (!LoginDate.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.LoginDate.HasValue) ? 1 : DateTime.Compare(user_Detail.LoginDate.Value, LoginDate.Value);
                    case "livedate":
                        if (!LiveDate.HasValue && !user_Detail.LiveDate.HasValue)
                        {
                            return 0;
                        }
                        if (!LiveDate.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.LiveDate.HasValue) ? 1 : DateTime.Compare(user_Detail.LiveDate.Value, LiveDate.Value);
                    case "viewcount":
                        if (!ViewCount.HasValue && !user_Detail.ViewCount.HasValue)
                        {
                            return 0;
                        }
                        if (!ViewCount.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.ViewCount.HasValue) ? 1 : user_Detail.ViewCount.Value.CompareTo(ViewCount.Value);
                    case "misviewcount":
                        if (!MisViewCount.HasValue && !user_Detail.MisViewCount.HasValue)
                        {
                            return 0;
                        }
                        if (!MisViewCount.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.MisViewCount.HasValue) ? 1 : user_Detail.MisViewCount.Value.CompareTo(MisViewCount.Value);
                    case "lastbehavior":
                        if (LastBehavior == null && user_Detail.LastBehavior == null)
                        {
                            return 0;
                        }
                        if (LastBehavior == null)
                        {
                            return -1;
                        }
                        return (user_Detail.LastBehavior == null) ? 1 : string.Compare(user_Detail.LastBehavior, LastBehavior, StringComparison.Ordinal);
                    case "roleid":
                        if (!RoleID.HasValue && !user_Detail.RoleID.HasValue)
                        {
                            return 0;
                        }
                        if (!RoleID.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.RoleID.HasValue) ? 1 : user_Detail.RoleID.Value.CompareTo(RoleID.Value);
                    case "username":
                        if (UserName == null && user_Detail.UserName == null)
                        {
                            return 0;
                        }
                        if (UserName == null)
                        {
                            return -1;
                        }
                        return (user_Detail.UserName == null) ? 1 : string.Compare(user_Detail.UserName, UserName, StringComparison.Ordinal);
                    case "username2":
                        if (UserName2 == null && user_Detail.UserName2 == null)
                        {
                            return 0;
                        }
                        if (UserName2 == null)
                        {
                            return -1;
                        }
                        return (user_Detail.UserName2 == null) ? 1 : string.Compare(user_Detail.UserName2, UserName2, StringComparison.Ordinal);
                    case "dzbbsuid":
                        if (!DzBbsUid.HasValue && !user_Detail.DzBbsUid.HasValue)
                        {
                            return 0;
                        }
                        if (!DzBbsUid.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.DzBbsUid.HasValue) ? 1 : user_Detail.DzBbsUid.Value.CompareTo(DzBbsUid.Value);
                    case "loginname":
                        if (LoginName == null && user_Detail.LoginName == null)
                        {
                            return 0;
                        }
                        if (LoginName == null)
                        {
                            return -1;
                        }
                        return (user_Detail.LoginName == null) ? 1 : string.Compare(user_Detail.LoginName, LoginName, StringComparison.Ordinal);
                    case "password":
                        if (Password == null && user_Detail.Password == null)
                        {
                            return 0;
                        }
                        if (Password == null)
                        {
                            return -1;
                        }
                        return (user_Detail.Password == null) ? 1 : string.Compare(user_Detail.Password, Password, StringComparison.Ordinal);
                    case "passwordmd5":
                        if (PasswordMD5 == null && user_Detail.PasswordMD5 == null)
                        {
                            return 0;
                        }
                        if (PasswordMD5 == null)
                        {
                            return -1;
                        }
                        return (user_Detail.PasswordMD5 == null) ? 1 : string.Compare(user_Detail.PasswordMD5, PasswordMD5, StringComparison.Ordinal);
                    case "passerrorcount":
                        if (!PassErrorCount.HasValue && !user_Detail.PassErrorCount.HasValue)
                        {
                            return 0;
                        }
                        if (!PassErrorCount.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.PassErrorCount.HasValue) ? 1 : user_Detail.PassErrorCount.Value.CompareTo(PassErrorCount.Value);
                    case "rukoukey":
                        if (rukouKey == null && user_Detail.rukouKey == null)
                        {
                            return 0;
                        }
                        if (rukouKey == null)
                        {
                            return -1;
                        }
                        return (user_Detail.rukouKey == null) ? 1 : string.Compare(user_Detail.rukouKey, rukouKey, StringComparison.Ordinal);
                    case "rukoukeymd5":
                        if (RukouKeyMD5 == null && user_Detail.RukouKeyMD5 == null)
                        {
                            return 0;
                        }
                        if (RukouKeyMD5 == null)
                        {
                            return -1;
                        }
                        return (user_Detail.RukouKeyMD5 == null) ? 1 : string.Compare(user_Detail.RukouKeyMD5, RukouKeyMD5, StringComparison.Ordinal);
                    case "groupid":
                        if (!groupid.HasValue && !user_Detail.groupid.HasValue)
                        {
                            return 0;
                        }
                        if (!groupid.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.groupid.HasValue) ? 1 : user_Detail.groupid.Value.CompareTo(groupid.Value);
                    case "cityid":
                        if (!CityID.HasValue && !user_Detail.CityID.HasValue)
                        {
                            return 0;
                        }
                        if (!CityID.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.CityID.HasValue) ? 1 : user_Detail.CityID.Value.CompareTo(CityID.Value);
                    case "areaid":
                        if (!AreaID.HasValue && !user_Detail.AreaID.HasValue)
                        {
                            return 0;
                        }
                        if (!AreaID.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.AreaID.HasValue) ? 1 : user_Detail.AreaID.Value.CompareTo(AreaID.Value);
                    case "orgid":
                        if (!orgid.HasValue && !user_Detail.orgid.HasValue)
                        {
                            return 0;
                        }
                        if (!orgid.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.orgid.HasValue) ? 1 : user_Detail.orgid.Value.CompareTo(orgid.Value);
                    case "adduserid":
                        if (!adduserid.HasValue && !user_Detail.adduserid.HasValue)
                        {
                            return 0;
                        }
                        if (!adduserid.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.adduserid.HasValue) ? 1 : user_Detail.adduserid.Value.CompareTo(adduserid.Value);
                    case "flag":
                        if (!flag.HasValue && !user_Detail.flag.HasValue)
                        {
                            return 0;
                        }
                        if (!flag.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.flag.HasValue) ? 1 : user_Detail.flag.Value.CompareTo(flag.Value);
                    case "sex":
                        if (!sex.HasValue && !user_Detail.sex.HasValue)
                        {
                            return 0;
                        }
                        if (!sex.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.sex.HasValue) ? 1 : user_Detail.sex.Value.CompareTo(sex.Value);
                    case "orgzu":
                        if (!orgzu.HasValue && !user_Detail.orgzu.HasValue)
                        {
                            return 0;
                        }
                        if (!orgzu.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.orgzu.HasValue) ? 1 : user_Detail.orgzu.Value.CompareTo(orgzu.Value);
                    case "isjjr":
                        if (!isjjr.HasValue && !user_Detail.isjjr.HasValue)
                        {
                            return 0;
                        }
                        if (!isjjr.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.isjjr.HasValue) ? 1 : user_Detail.isjjr.Value.CompareTo(isjjr.Value);
                    case "usergrade":
                        if (!UserGrade.HasValue && !user_Detail.UserGrade.HasValue)
                        {
                            return 0;
                        }
                        if (!UserGrade.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.UserGrade.HasValue) ? 1 : user_Detail.UserGrade.Value.CompareTo(UserGrade.Value);
                    case "gzjifenxz":
                        if (!GzJifenXZ.HasValue && !user_Detail.GzJifenXZ.HasValue)
                        {
                            return 0;
                        }
                        if (!GzJifenXZ.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.GzJifenXZ.HasValue) ? 1 : user_Detail.GzJifenXZ.Value.CompareTo(GzJifenXZ.Value);
                    case "mgoparentuserid":
                        if (!MgoParentUserID.HasValue && !user_Detail.MgoParentUserID.HasValue)
                        {
                            return 0;
                        }
                        if (!MgoParentUserID.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.MgoParentUserID.HasValue) ? 1 : user_Detail.MgoParentUserID.Value.CompareTo(MgoParentUserID.Value);
                    case "jjrfenzu":
                        if (!JjrFenzu.HasValue && !user_Detail.JjrFenzu.HasValue)
                        {
                            return 0;
                        }
                        if (!JjrFenzu.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.JjrFenzu.HasValue) ? 1 : user_Detail.JjrFenzu.Value.CompareTo(JjrFenzu.Value);
                    case "isjyh":
                        if (!IsJYH.HasValue && !user_Detail.IsJYH.HasValue)
                        {
                            return 0;
                        }
                        if (!IsJYH.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.IsJYH.HasValue) ? 1 : user_Detail.IsJYH.Value.CompareTo(IsJYH.Value);
                    case "isdzchubei":
                        if (!IsDzChubei.HasValue && !user_Detail.IsDzChubei.HasValue)
                        {
                            return 0;
                        }
                        if (!IsDzChubei.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.IsDzChubei.HasValue) ? 1 : user_Detail.IsDzChubei.Value.CompareTo(IsDzChubei.Value);
                    case "iszhiying":
                        if (!isZhiying.HasValue && !user_Detail.isZhiying.HasValue)
                        {
                            return 0;
                        }
                        if (!isZhiying.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.isZhiying.HasValue) ? 1 : user_Detail.isZhiying.Value.CompareTo(isZhiying.Value);
                    case "headimg":
                        if (HeadImg == null && user_Detail.HeadImg == null)
                        {
                            return 0;
                        }
                        if (HeadImg == null)
                        {
                            return -1;
                        }
                        return (user_Detail.HeadImg == null) ? 1 : string.Compare(user_Detail.HeadImg, HeadImg, StringComparison.Ordinal);
                    case "sellcount":
                        if (!SellCount.HasValue && !user_Detail.SellCount.HasValue)
                        {
                            return 0;
                        }
                        if (!SellCount.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.SellCount.HasValue) ? 1 : user_Detail.SellCount.Value.CompareTo(SellCount.Value);
                    case "rentcount":
                        if (!RentCount.HasValue && !user_Detail.RentCount.HasValue)
                        {
                            return 0;
                        }
                        if (!RentCount.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.RentCount.HasValue) ? 1 : user_Detail.RentCount.Value.CompareTo(RentCount.Value);
                    case "rzruzhidate":
                        if (!RzRuzhiDate.HasValue && !user_Detail.RzRuzhiDate.HasValue)
                        {
                            return 0;
                        }
                        if (!RzRuzhiDate.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.RzRuzhiDate.HasValue) ? 1 : DateTime.Compare(user_Detail.RzRuzhiDate.Value, RzRuzhiDate.Value);
                    case "isjiangshi":
                        if (!IsJiangShi.HasValue && !user_Detail.IsJiangShi.HasValue)
                        {
                            return 0;
                        }
                        if (!IsJiangShi.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.IsJiangShi.HasValue) ? 1 : user_Detail.IsJiangShi.Value.CompareTo(IsJiangShi.Value);
                    case "vers":
                        if (!vers.HasValue && !user_Detail.vers.HasValue)
                        {
                            return 0;
                        }
                        if (!vers.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.vers.HasValue) ? 1 : user_Detail.vers.Value.CompareTo(vers.Value);
                    case "mangocoin":
                        if (!MangoCoin.HasValue && !user_Detail.MangoCoin.HasValue)
                        {
                            return 0;
                        }
                        if (!MangoCoin.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.MangoCoin.HasValue) ? 1 : user_Detail.MangoCoin.Value.CompareTo(MangoCoin.Value);
                    case "sellhtcount":
                        if (!SellHTCount.HasValue && !user_Detail.SellHTCount.HasValue)
                        {
                            return 0;
                        }
                        if (!SellHTCount.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.SellHTCount.HasValue) ? 1 : user_Detail.SellHTCount.Value.CompareTo(SellHTCount.Value);
                    case "renthtcount":
                        if (!RentHTCount.HasValue && !user_Detail.RentHTCount.HasValue)
                        {
                            return 0;
                        }
                        if (!RentHTCount.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.RentHTCount.HasValue) ? 1 : user_Detail.RentHTCount.Value.CompareTo(RentHTCount.Value);
                    case "lasttime":
                        if (!lasttime.HasValue && !user_Detail.lasttime.HasValue)
                        {
                            return 0;
                        }
                        if (!lasttime.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.lasttime.HasValue) ? 1 : DateTime.Compare(user_Detail.lasttime.Value, lasttime.Value);
                    case "email":
                        if (email == null && user_Detail.email == null)
                        {
                            return 0;
                        }
                        if (email == null)
                        {
                            return -1;
                        }
                        return (user_Detail.email == null) ? 1 : string.Compare(user_Detail.email, email, StringComparison.Ordinal);
                    case "qq":
                        if (qq == null && user_Detail.qq == null)
                        {
                            return 0;
                        }
                        if (qq == null)
                        {
                            return -1;
                        }
                        return (user_Detail.qq == null) ? 1 : string.Compare(user_Detail.qq, qq, StringComparison.Ordinal);
                    case "mobile":
                        if (mobile == null && user_Detail.mobile == null)
                        {
                            return 0;
                        }
                        if (mobile == null)
                        {
                            return -1;
                        }
                        return (user_Detail.mobile == null) ? 1 : string.Compare(user_Detail.mobile, mobile, StringComparison.Ordinal);
                    case "mobilexiaohao":
                        if (mobileXiaohao == null && user_Detail.mobileXiaohao == null)
                        {
                            return 0;
                        }
                        if (mobileXiaohao == null)
                        {
                            return -1;
                        }
                        return (user_Detail.mobileXiaohao == null) ? 1 : string.Compare(user_Detail.mobileXiaohao, mobileXiaohao, StringComparison.Ordinal);
                    case "mobilebeyong":
                        if (mobileBeyong == null && user_Detail.mobileBeyong == null)
                        {
                            return 0;
                        }
                        if (mobileBeyong == null)
                        {
                            return -1;
                        }
                        return (user_Detail.mobileBeyong == null) ? 1 : string.Compare(user_Detail.mobileBeyong, mobileBeyong, StringComparison.Ordinal);
                    case "idcno":
                        if (IDCNO == null && user_Detail.IDCNO == null)
                        {
                            return 0;
                        }
                        if (IDCNO == null)
                        {
                            return -1;
                        }
                        return (user_Detail.IDCNO == null) ? 1 : string.Compare(user_Detail.IDCNO, IDCNO, StringComparison.Ordinal);
                    case "jianjie":
                        if (JianJie == null && user_Detail.JianJie == null)
                        {
                            return 0;
                        }
                        if (JianJie == null)
                        {
                            return -1;
                        }
                        return (user_Detail.JianJie == null) ? 1 : string.Compare(user_Detail.JianJie, JianJie, StringComparison.Ordinal);
                    case "yj_first":
                        if (!yj_first.HasValue && !user_Detail.yj_first.HasValue)
                        {
                            return 0;
                        }
                        if (!yj_first.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.yj_first.HasValue) ? 1 : DateTime.Compare(user_Detail.yj_first.Value, yj_first.Value);
                    case "mgochanquan":
                        if (!MgoChanquan.HasValue && !user_Detail.MgoChanquan.HasValue)
                        {
                            return 0;
                        }
                        if (!MgoChanquan.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.MgoChanquan.HasValue) ? 1 : user_Detail.MgoChanquan.Value.CompareTo(MgoChanquan.Value);
                    case "usermemo":
                        if (UserMemo == null && user_Detail.UserMemo == null)
                        {
                            return 0;
                        }
                        if (UserMemo == null)
                        {
                            return -1;
                        }
                        return (user_Detail.UserMemo == null) ? 1 : string.Compare(user_Detail.UserMemo, UserMemo, StringComparison.Ordinal);
                    case "headimgbig":
                        if (HeadImgBig == null && user_Detail.HeadImgBig == null)
                        {
                            return 0;
                        }
                        if (HeadImgBig == null)
                        {
                            return -1;
                        }
                        return (user_Detail.HeadImgBig == null) ? 1 : string.Compare(user_Detail.HeadImgBig, HeadImgBig, StringComparison.Ordinal);
                    case "jindiandate":
                        if (!jindiandate.HasValue && !user_Detail.jindiandate.HasValue)
                        {
                            return 0;
                        }
                        if (!jindiandate.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.jindiandate.HasValue) ? 1 : DateTime.Compare(user_Detail.jindiandate.Value, jindiandate.Value);
                    case "rzruzhidatefirst":
                        if (!RzRuzhiDateFirst.HasValue && !user_Detail.RzRuzhiDateFirst.HasValue)
                        {
                            return 0;
                        }
                        if (!RzRuzhiDateFirst.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.RzRuzhiDateFirst.HasValue) ? 1 : DateTime.Compare(user_Detail.RzRuzhiDateFirst.Value, RzRuzhiDateFirst.Value);
                    case "rzleavedate":
                        if (!RzLeaveDate.HasValue && !user_Detail.RzLeaveDate.HasValue)
                        {
                            return 0;
                        }
                        if (!RzLeaveDate.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.RzLeaveDate.HasValue) ? 1 : DateTime.Compare(user_Detail.RzLeaveDate.Value, RzLeaveDate.Value);
                    case "zhiwei":
                        if (Zhiwei == null && user_Detail.Zhiwei == null)
                        {
                            return 0;
                        }
                        if (Zhiwei == null)
                        {
                            return -1;
                        }
                        return (user_Detail.Zhiwei == null) ? 1 : string.Compare(user_Detail.Zhiwei, Zhiwei, StringComparison.Ordinal);
                    case "rzzhuandian":
                        if (RzZhuanDian == null && user_Detail.RzZhuanDian == null)
                        {
                            return 0;
                        }
                        if (RzZhuanDian == null)
                        {
                            return -1;
                        }
                        return (user_Detail.RzZhuanDian == null) ? 1 : string.Compare(user_Detail.RzZhuanDian, RzZhuanDian, StringComparison.Ordinal);
                    case "rzzhuanren":
                        if (RzZhuanRen == null && user_Detail.RzZhuanRen == null)
                        {
                            return 0;
                        }
                        if (RzZhuanRen == null)
                        {
                            return -1;
                        }
                        return (user_Detail.RzZhuanRen == null) ? 1 : string.Compare(user_Detail.RzZhuanRen, RzZhuanRen, StringComparison.Ordinal);
                    case "shengao":
                        if (!shengao.HasValue && !user_Detail.shengao.HasValue)
                        {
                            return 0;
                        }
                        if (!shengao.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.shengao.HasValue) ? 1 : user_Detail.shengao.Value.CompareTo(shengao.Value);
                    case "yaowei":
                        if (!yaowei.HasValue && !user_Detail.yaowei.HasValue)
                        {
                            return 0;
                        }
                        if (!yaowei.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.yaowei.HasValue) ? 1 : user_Detail.yaowei.Value.CompareTo(yaowei.Value);
                    case "xiongwei":
                        if (!xiongwei.HasValue && !user_Detail.xiongwei.HasValue)
                        {
                            return 0;
                        }
                        if (!xiongwei.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.xiongwei.HasValue) ? 1 : user_Detail.xiongwei.Value.CompareTo(xiongwei.Value);
                    case "qqmima":
                        if (qqmima == null && user_Detail.qqmima == null)
                        {
                            return 0;
                        }
                        if (qqmima == null)
                        {
                            return -1;
                        }
                        return (user_Detail.qqmima == null) ? 1 : string.Compare(user_Detail.qqmima, qqmima, StringComparison.Ordinal);
                    case "qqonewt":
                        if (qqonewt == null && user_Detail.qqonewt == null)
                        {
                            return 0;
                        }
                        if (qqonewt == null)
                        {
                            return -1;
                        }
                        return (user_Detail.qqonewt == null) ? 1 : string.Compare(user_Detail.qqonewt, qqonewt, StringComparison.Ordinal);
                    case "qqonewtda":
                        if (qqonewtda == null && user_Detail.qqonewtda == null)
                        {
                            return 0;
                        }
                        if (qqonewtda == null)
                        {
                            return -1;
                        }
                        return (user_Detail.qqonewtda == null) ? 1 : string.Compare(user_Detail.qqonewtda, qqonewtda, StringComparison.Ordinal);
                    case "qqtwowt":
                        if (qqtwowt == null && user_Detail.qqtwowt == null)
                        {
                            return 0;
                        }
                        if (qqtwowt == null)
                        {
                            return -1;
                        }
                        return (user_Detail.qqtwowt == null) ? 1 : string.Compare(user_Detail.qqtwowt, qqtwowt, StringComparison.Ordinal);
                    case "qqtwowtda":
                        if (qqtwowtda == null && user_Detail.qqtwowtda == null)
                        {
                            return 0;
                        }
                        if (qqtwowtda == null)
                        {
                            return -1;
                        }
                        return (user_Detail.qqtwowtda == null) ? 1 : string.Compare(user_Detail.qqtwowtda, qqtwowtda, StringComparison.Ordinal);
                    case "qqthreewt":
                        if (qqthreewt == null && user_Detail.qqthreewt == null)
                        {
                            return 0;
                        }
                        if (qqthreewt == null)
                        {
                            return -1;
                        }
                        return (user_Detail.qqthreewt == null) ? 1 : string.Compare(user_Detail.qqthreewt, qqthreewt, StringComparison.Ordinal);
                    case "qqthreewtda":
                        if (qqthreewtda == null && user_Detail.qqthreewtda == null)
                        {
                            return 0;
                        }
                        if (qqthreewtda == null)
                        {
                            return -1;
                        }
                        return (user_Detail.qqthreewtda == null) ? 1 : string.Compare(user_Detail.qqthreewtda, qqthreewtda, StringComparison.Ordinal);
                    case "portintroduction":
                        if (PortIntroduction == null && user_Detail.PortIntroduction == null)
                        {
                            return 0;
                        }
                        if (PortIntroduction == null)
                        {
                            return -1;
                        }
                        return (user_Detail.PortIntroduction == null) ? 1 : string.Compare(user_Detail.PortIntroduction, PortIntroduction, StringComparison.Ordinal);
                    case "pkcount":
                        if (!PkCount.HasValue && !user_Detail.PkCount.HasValue)
                        {
                            return 0;
                        }
                        if (!PkCount.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.PkCount.HasValue) ? 1 : user_Detail.PkCount.Value.CompareTo(PkCount.Value);
                    case "pkwinmoney":
                        if (!PkWinMoney.HasValue && !user_Detail.PkWinMoney.HasValue)
                        {
                            return 0;
                        }
                        if (!PkWinMoney.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.PkWinMoney.HasValue) ? 1 : user_Detail.PkWinMoney.Value.CompareTo(PkWinMoney.Value);
                    case "pkwinper":
                        if (!PkWinPer.HasValue && !user_Detail.PkWinPer.HasValue)
                        {
                            return 0;
                        }
                        if (!PkWinPer.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.PkWinPer.HasValue) ? 1 : user_Detail.PkWinPer.Value.CompareTo(PkWinPer.Value);
                    case "passfirst":
                        if (PassFirst == null && user_Detail.PassFirst == null)
                        {
                            return 0;
                        }
                        if (PassFirst == null)
                        {
                            return -1;
                        }
                        return (user_Detail.PassFirst == null) ? 1 : string.Compare(user_Detail.PassFirst, PassFirst, StringComparison.Ordinal);
                    case "rukoufirst":
                        if (RukouFirst == null && user_Detail.RukouFirst == null)
                        {
                            return 0;
                        }
                        if (RukouFirst == null)
                        {
                            return -1;
                        }
                        return (user_Detail.RukouFirst == null) ? 1 : string.Compare(user_Detail.RukouFirst, RukouFirst, StringComparison.Ordinal);
                    case "passlasttime":
                        if (!PassLastTime.HasValue && !user_Detail.PassLastTime.HasValue)
                        {
                            return 0;
                        }
                        if (!PassLastTime.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.PassLastTime.HasValue) ? 1 : DateTime.Compare(user_Detail.PassLastTime.Value, PassLastTime.Value);
                    case "rukoulasttime":
                        if (!RukouLastTime.HasValue && !user_Detail.RukouLastTime.HasValue)
                        {
                            return 0;
                        }
                        if (!RukouLastTime.HasValue)
                        {
                            return -1;
                        }
                        return (!user_Detail.RukouLastTime.HasValue) ? 1 : DateTime.Compare(user_Detail.RukouLastTime.Value, RukouLastTime.Value);
                    case "qqweibo":
                        if (QQWeibo == null && user_Detail.QQWeibo == null)
                        {
                            return 0;
                        }
                        if (QQWeibo == null)
                        {
                            return -1;
                        }
                        return (user_Detail.QQWeibo == null) ? 1 : string.Compare(user_Detail.QQWeibo, QQWeibo, StringComparison.Ordinal);
                    case "sinaweibo":
                        if (SinaWeibo == null && user_Detail.SinaWeibo == null)
                        {
                            return 0;
                        }
                        if (SinaWeibo == null)
                        {
                            return -1;
                        }
                        return (user_Detail.SinaWeibo == null) ? 1 : string.Compare(user_Detail.SinaWeibo, SinaWeibo, StringComparison.Ordinal);
                    case "qqweixin":
                        if (QQWeixin == null && user_Detail.QQWeixin == null)
                        {
                            return 0;
                        }
                        if (QQWeixin == null)
                        {
                            return -1;
                        }
                        return (user_Detail.QQWeixin == null) ? 1 : string.Compare(user_Detail.QQWeixin, QQWeixin, StringComparison.Ordinal);
                    case "zhiweiextent":
                        if (ZhiWeiExtent == null && user_Detail.ZhiWeiExtent == null)
                        {
                            return 0;
                        }
                        if (ZhiWeiExtent == null)
                        {
                            return -1;
                        }
                        return (user_Detail.ZhiWeiExtent == null) ? 1 : string.Compare(user_Detail.ZhiWeiExtent, ZhiWeiExtent, StringComparison.Ordinal);
                    case "fenjihao":
                        if (FenJiHao == null && user_Detail.FenJiHao == null)
                        {
                            return 0;
                        }
                        if (FenJiHao == null)
                        {
                            return -1;
                        }
                        return (user_Detail.FenJiHao == null) ? 1 : string.Compare(user_Detail.FenJiHao, FenJiHao, StringComparison.Ordinal);
                    default:
                        return 0;
                }
            }
            return 1;
        }

        //
        // 摘要:
        //     /// 本类快速查找 ///
        //
        // 参数:
        //   ColunmName:
        //     属性名
        public override object FindColumn(string ColunmName)
        {
            switch (ColunmName.ToLower())
            {
                case "userid":
                    return UserId;
                case "autoid":
                    return autoid;
                case "addtime":
                    return addtime;
                case "dbsource":
                    return DBSource;
                case "logincount":
                    return LoginCount;
                case "logindate":
                    return LoginDate;
                case "livedate":
                    return LiveDate;
                case "viewcount":
                    return ViewCount;
                case "misviewcount":
                    return MisViewCount;
                case "lastbehavior":
                    return LastBehavior;
                case "roleid":
                    return RoleID;
                case "username":
                    return UserName;
                case "username2":
                    return UserName2;
                case "dzbbsuid":
                    return DzBbsUid;
                case "loginname":
                    return LoginName;
                case "password":
                    return Password;
                case "passwordmd5":
                    return PasswordMD5;
                case "passerrorcount":
                    return PassErrorCount;
                case "rukoukey":
                    return rukouKey;
                case "rukoukeymd5":
                    return RukouKeyMD5;
                case "groupid":
                    return groupid;
                case "cityid":
                    return CityID;
                case "areaid":
                    return AreaID;
                case "orgid":
                    return orgid;
                case "adduserid":
                    return adduserid;
                case "flag":
                    return flag;
                case "sex":
                    return sex;
                case "orgzu":
                    return orgzu;
                case "isjjr":
                    return isjjr;
                case "usergrade":
                    return UserGrade;
                case "gzjifenxz":
                    return GzJifenXZ;
                case "mgoparentuserid":
                    return MgoParentUserID;
                case "jjrfenzu":
                    return JjrFenzu;
                case "isjyh":
                    return IsJYH;
                case "isdzchubei":
                    return IsDzChubei;
                case "iszhiying":
                    return isZhiying;
                case "headimg":
                    return HeadImg;
                case "sellcount":
                    return SellCount;
                case "rentcount":
                    return RentCount;
                case "rzruzhidate":
                    return RzRuzhiDate;
                case "isjiangshi":
                    return IsJiangShi;
                case "vers":
                    return vers;
                case "mangocoin":
                    return MangoCoin;
                case "sellhtcount":
                    return SellHTCount;
                case "renthtcount":
                    return RentHTCount;
                case "lasttime":
                    return lasttime;
                case "email":
                    return email;
                case "qq":
                    return qq;
                case "mobile":
                    return mobile;
                case "mobilexiaohao":
                    return mobileXiaohao;
                case "mobilebeyong":
                    return mobileBeyong;
                case "idcno":
                    return IDCNO;
                case "jianjie":
                    return JianJie;
                case "yj_first":
                    return yj_first;
                case "mgochanquan":
                    return MgoChanquan;
                case "usermemo":
                    return UserMemo;
                case "headimgbig":
                    return HeadImgBig;
                case "jindiandate":
                    return jindiandate;
                case "rzruzhidatefirst":
                    return RzRuzhiDateFirst;
                case "rzleavedate":
                    return RzLeaveDate;
                case "zhiwei":
                    return Zhiwei;
                case "rzzhuandian":
                    return RzZhuanDian;
                case "rzzhuanren":
                    return RzZhuanRen;
                case "shengao":
                    return shengao;
                case "yaowei":
                    return yaowei;
                case "xiongwei":
                    return xiongwei;
                case "qqmima":
                    return qqmima;
                case "qqonewt":
                    return qqonewt;
                case "qqonewtda":
                    return qqonewtda;
                case "qqtwowt":
                    return qqtwowt;
                case "qqtwowtda":
                    return qqtwowtda;
                case "qqthreewt":
                    return qqthreewt;
                case "qqthreewtda":
                    return qqthreewtda;
                case "portintroduction":
                    return PortIntroduction;
                case "pkcount":
                    return PkCount;
                case "pkwinmoney":
                    return PkWinMoney;
                case "pkwinper":
                    return PkWinPer;
                case "passfirst":
                    return PassFirst;
                case "rukoufirst":
                    return RukouFirst;
                case "passlasttime":
                    return PassLastTime;
                case "rukoulasttime":
                    return RukouLastTime;
                case "qqweibo":
                    return QQWeibo;
                case "sinaweibo":
                    return SinaWeibo;
                case "qqweixin":
                    return QQWeixin;
                case "zhiweiextent":
                    return ZhiWeiExtent;
                case "fenjihao":
                    return FenJiHao;
                default:
                    return null;
            }
        }
    }
}
