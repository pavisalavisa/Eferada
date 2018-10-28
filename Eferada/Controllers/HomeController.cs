using Business.Services.Contracts;
using System.Web.Mvc;

namespace Eferada.Controllers
{
    public class HomeController : Controller
    {
        private ITestService _testService;
        public HomeController(ITestService testService)
        {
            _testService = testService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = _testService.Speak();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}