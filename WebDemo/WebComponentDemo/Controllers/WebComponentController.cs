using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebComponentAPIGateway;

namespace WebComponentDemo.Controllers
{
    public class WebComponentController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var host = "http://127.0.0.1:8030";
            var path = "/api/getdata";
            //转发获取数据
            var result = await Request.GetAPIData(host, path);
            return Content(result);
        }
    }
}