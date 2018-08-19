using Dayboi_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dayboi_Web.Controllers
{
    public class HomeController : Controller
    {
        ITestService testService;
        public HomeController(ITestService testService) {
            this.testService = testService;
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        public ActionResult Index()
        {
            testService.GetWinner();
            return View();
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