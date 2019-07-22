using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using UserSelectionData;
using WebComponentWebAPI.Configs;
using WebComponentWebAPI.Utilitys;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserSelectionWebAPI.API
{
    [Route("api/[controller]")]
    public class Mis2014Controller : Controller
    {
        private static readonly ILog _log = LogManager.GetLogger(ConfigManager.repository.Name, typeof(Mis2014Controller));
        IUser_listService _user_listService;
        public Mis2014Controller(IUser_listService user_listService)
        {
            _user_listService = user_listService;
        }

        [HttpPost("GetPostData")]
        public IActionResult GetPostData()
        {
            string result = "";
            try
            {
                result = GetAPIData(Request);
            }
            catch (Exception)
            {
            }
            return Content(result);
        }
        [HttpGet("Get/{id}")]
        public IActionResult Get(string id)
        {
            string result = "";
            try
            {
                var modelRet = _user_listService.GetModelByIds(id);
                result = JsonConvert.SerializeObject(modelRet);
            }
            catch (Exception)
            {
            }
            return Content(result);
        }
        [HttpGet("GetIds/{ids}")]
        public IActionResult GetIds(string ids)
        {
            string result = "";
            try
            {
                var modelRet = _user_listService.GetModelByIds(ids);
                result = JsonConvert.SerializeObject(modelRet);
            }
            catch (Exception)
            {
            }
            return Content(result);
        }
        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            string result = "";
            try
            {
                DateTime dt1 = DateTime.Now;
                var modelRet = _user_listService.GetUserList();
                DateTime dt2 = DateTime.Now;
                modelRet.debug += $"查询耗时：{(dt2 - dt1).TotalMilliseconds}ms";
                result = JsonConvert.SerializeObject(modelRet);
            }
            catch (Exception)
            {
            }
            return Content(result);
        }
        /// <summary>
        /// 获取mis2014中的数据
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public string GetAPIData(HttpRequest Request)
        {
            string result = "";

            string postData = Request.GetRawBodyStringAsync().Result;

            _log.DebugFormat("HttpRequest==>Request:{0}", postData);

            //获取Mis2014的数据
            string apiUrl = "https://mis.517.cn/a10_common/a1020_selection/Actions/UserAction.ashx?action=user&pagename=noPageName&type=otherOrg&size=20&orgId=157&isShowDeleted=0&selectIds=&mastOrg=&isJJr=&ispowerorg=0";

            //TODO:需要实现API获取数据
            //result = HttpClientHelper.HttpPost(apiUrl, "");

            result = "{\"data\":{\"data\":[{\"UserId\":59632,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"邵文\",\"orgid\":22,\"isjjr\":0,\"OrgName\":\"研发部\",\"mobile\":\"15840452469\",\"RzRuzhiDate\":\"2019-06-12\",\"isyunying\":false},{\"UserId\":55454,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"苑鹏掣\",\"orgid\":22,\"isjjr\":13,\"OrgName\":\"研发部\",\"mobile\":\"15604025257\",\"RzRuzhiDate\":\"2018-08-27\",\"isyunying\":false},{\"UserId\":58988,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"钟海\",\"orgid\":22,\"isjjr\":9,\"OrgName\":\"研发部\",\"mobile\":\"18802447663\",\"RzRuzhiDate\":\"2019-05-08\",\"isyunying\":false},{\"UserId\":12354,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"黄鑫\",\"orgid\":22,\"isjjr\":10,\"OrgName\":\"研发部\",\"mobile\":\"18698883789\",\"RzRuzhiDate\":\"2011-01-10\",\"isyunying\":false},{\"UserId\":57747,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"曲振林\",\"orgid\":22,\"isjjr\":13,\"OrgName\":\"研发部\",\"mobile\":\"15714010102\",\"RzRuzhiDate\":\"2019-02-25\",\"isyunying\":false},{\"UserId\":55967,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"侯福艳\",\"orgid\":22,\"isjjr\":9,\"OrgName\":\"研发部\",\"mobile\":\"13194200618\",\"RzRuzhiDate\":\"2018-09-17\",\"isyunying\":false},{\"UserId\":44434,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"南丙坤\",\"orgid\":22,\"isjjr\":9,\"OrgName\":\"研发部\",\"mobile\":\"15640440181\",\"RzRuzhiDate\":\"2017-04-10\",\"isyunying\":false},{\"UserId\":56599,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"魏秋实\",\"orgid\":22,\"isjjr\":9,\"OrgName\":\"研发部\",\"mobile\":\"13998272237\",\"RzRuzhiDate\":\"2018-10-22\",\"isyunying\":false},{\"UserId\":45848,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"王天\",\"orgid\":22,\"isjjr\":9,\"OrgName\":\"研发部\",\"mobile\":\"13591667022\",\"RzRuzhiDate\":\"2017-06-19\",\"isyunying\":false},{\"UserId\":45208,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"胡泽军\",\"orgid\":22,\"isjjr\":9,\"OrgName\":\"研发部\",\"mobile\":\"18604020570\",\"RzRuzhiDate\":\"2017-05-25\",\"isyunying\":false},{\"UserId\":22565,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"崔玮\",\"orgid\":22,\"isjjr\":9,\"OrgName\":\"研发部\",\"mobile\":\"13504944808\",\"RzRuzhiDate\":\"2014-04-07\",\"isyunying\":false},{\"UserId\":52525,\"ZaiZhiZhuangTai\":\"在职\",\"UserName\":\"苑琳琳\",\"orgid\":22,\"isjjr\":9,\"OrgName\":\"研发部\",\"mobile\":\"15524257001\",\"RzRuzhiDate\":\"2018-04-14\",\"isyunying\":false}],\"count\":12,\"msg\":\"\",\"history\":[59632,55454,58988,12354,57747,55967,44434,56599,45848,45208,22565,52525],\"changyong\":[58988,12354,45208,52525,22565,56599,45848,57747,55454,44434,55967,59632]},\"flag\":1,\"debug\":\"\"}";

            _log.DebugFormat("GetAPIData==>apiurl:{0}\r\nresult:{1}", apiUrl, result);

            return result;
        }
    }
}
