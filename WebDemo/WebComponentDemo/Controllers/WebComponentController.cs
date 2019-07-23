using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebComponentAPIGateway;

namespace WebComponentDemo.Controllers
{
    public class WebComponentController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //var host = "http://ng-userselect.me.517.me";
            var host = Startup.UserselectionAPI;
            var path = "/api/mis2014/getlist";
            //转发获取数据
            var result = await Request.GetAPIData(host, path);
            return Content(result);
        }
    }
}