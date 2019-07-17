using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSelectionData;
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
        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            string result = "";
            try
            {
                User_listVistor userVistor = new User_listVistor();
                var modelRet = userVistor.GetModel(id);
                result = Newtonsoft.Json.JsonConvert.SerializeObject(modelRet);
            }
            catch (Exception)
            {
            }
            return Content(result);
        }
    }
}
