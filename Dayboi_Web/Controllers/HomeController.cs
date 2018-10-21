using AutoMapper;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using Dayboi_Service.Admin;
using Dayboi_Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Dayboi_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IBlogRepository _blogRepository;

        public HomeController(ICategoryService categoryService, IBlogRepository blogRepository)
        {
            _categoryService = categoryService;
            _blogRepository = blogRepository;
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

        public ActionResult Index()
        {
            var homeModel = new HomeModel();
            var blogs = _blogRepository.GetMany(x => !x.IsDeleted &&
                                                x.IsActive)
                                                .OrderByDescending(x => x.CreatedOn)
                                                .Take(4)
                                                .ToList();

            var blogModels = Mapper.Map<IEnumerable<Blog>, IEnumerable<BlogViewModel>>(blogs);
            homeModel.Blogs = blogModels;
            return View(homeModel);
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