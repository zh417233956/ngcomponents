using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebComponentAPIGateway;

namespace WebComponentDemo.Controllers
{
    public class WebComponentController : Controller
    {
        public IActionResult Index()
        {
            var webcpt = new WebComponentHelper();
            var requsetData = new { Cookies = Request.Cookies, Header = Request.Headers, QueryString = Request.Query };

            var param = Newtonsoft.Json.JsonConvert.SerializeObject(requsetData);
            var host = "http://127.0.0.1:8030";
            var path = "/api/getdata";
            var result = webcpt.GetAPIData(host, path, param);
            return Content(result);
        }
    }
}