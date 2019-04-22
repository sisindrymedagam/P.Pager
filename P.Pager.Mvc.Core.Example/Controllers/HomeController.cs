using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
            var pager = _data.GetMembers().ToPagedList(page, 10);
            return View(pager);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
