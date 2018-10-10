using AutoMapper;
using Dayboi_Infrastructure.Models;
using Dayboi_Service;
using Dayboi_Service.Admin;
using Dayboi_Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dayboi_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            var headerModel = new HeaderModel();
            var categories = _categoryService.GetAll();
            var categoryModels = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel>>(categories);
            headerModel.Categories = categoryModels;
            return PartialView(headerModel);
        }

        [Authorize (Roles ="client")]
        public ActionResult Index()
        {
            //testdayboi
            var user = User.Identity;
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