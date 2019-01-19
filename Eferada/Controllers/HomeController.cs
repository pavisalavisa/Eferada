using System.Web.Mvc;
using Eferada.Infrastructure;

namespace Eferada.Controllers
{
    [EferadaRoutePrefix(nameof(HomeController))]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}