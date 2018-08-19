using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dayboi_Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var a = 1;
            return PartialView("~/Views/Admin/Shared/Footer.cshtml");
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView("~/Views/Admin/Shared/Header.cshtml");
        }

        [ChildActionOnly]
        public ActionResult Left_Menu()
        {
            return PartialView("~/Views/Admin/Shared/Left_Menu.cshtml");
        }

        public ActionResult CreateProduct()
        {
            return View();
        }

    }
}