using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebComponentWebAPI;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserSelectionWebAPI.API
{
    [Route("api/[controller]")]
    public class Mis2014Controller : Controller
    {
        [HttpPost("GetPostData")]
        public IActionResult GetPostData()
        {
            string result = "";
            try
            {
                Mis2014Helper mis2014 = new Mis2014Helper();
                result = mis2014.GetAPIData(Request);
            }
            catch (Exception)
            {
            }
            return Content(result);
        }
        [HttpGet("Get")]
        public IActionResult Get()
        {
            string result = "";
            try
            {
                var key = WebComponentWebAPI.ConfigCenter.Config.WCFSecretkey;
                var iv = WebComponentWebAPI.ConfigCenter.Config.WCFSecretiv;
                var pwd = WebComponentWebAPI.ConfigCenter.Config.WCFPasskey;
            }
            catch (Exception)
            {
            }
            return Content(result);
        }
    }
}
