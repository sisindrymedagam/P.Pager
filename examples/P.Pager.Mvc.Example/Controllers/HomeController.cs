using P.Pager.Mvc.Example.Models;
using System.Web.Mvc;

namespace P.Pager.Mvc.Example.Controllers
{
    public class HomeController : Controller
    {
        readonly DemoData _data;
        public HomeController()
        {
            _data = new DemoData();
        }

        public ActionResult Index(int page = 1)
        {
            var pager = _data.GetMembers().ToPagerList(page, 2);
            return View(pager);
        }

    }
}