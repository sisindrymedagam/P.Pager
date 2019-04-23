using P.Pager.Mvc.Example.Models;
using System.Web.Mvc;

namespace P.Pager.Mvc.Example.Controllers
{
    public class HomeController : Controller
    {
        DemoData _data;
        public HomeController()
        {
            _data = new DemoData();
        }

        public ActionResult Index(int page = 1)
        {
            var pager = _data.GetMembers().ToPagedList(page, 7);
            return View(pager);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}