using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using P.Pager.Mvc.Core.Example.Models;

namespace P.Pager.Mvc.Core.Example.Controllers
{
    public class HomeController : Controller
    {
        DemoData _data;
        public HomeController()
        {
            _data = new DemoData();
        }
        public IActionResult Index(int page = 1)
        {
            var pager = _data.GetMembers().ToPagerList(page, 2);
            return View(pager);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
