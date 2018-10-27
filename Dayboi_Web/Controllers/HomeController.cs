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
        private readonly ICourseRepository _courseRepository;
        private readonly IPoolCategoryRepository _poolCategoryRepository;

        private List<CourseViewModel> _courses;

        public HomeController(ICategoryService categoryService,
                            IBlogRepository blogRepository,
                            IPoolCategoryRepository poolCategoryRepository,
                            ICourseRepository courseRepository)
        {
            _categoryService = categoryService;
            _blogRepository = blogRepository;
            _courseRepository = courseRepository;
            _courses = _courseRepository.GetMany(x => x.IsActive &&
                                                          !x.IsDeleted)
                                                        .OrderBy(x => x.DisplayOrder)
                                                        .Select(x => new CourseViewModel
                                                        {
                                                            Id = x.Id,
                                                            Name = x.Name,
                                                            Alias = x.Alias,
                                                            Image = x.Image,
                                                            Description = x.Description
                                                        })
                                                        .ToList();
            _poolCategoryRepository = poolCategoryRepository;
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            var headerModel = new HeaderViewModel();
            var categories = _categoryService.GetAll();
            var categoryModels = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel>>(categories);
            headerModel.Categories = categoryModels;

            headerModel.Courses = _courses;

            var poolCategoryModels = _poolCategoryRepository.GetMany(x => x.IsActive &&
                                                                        !x.IsDeleted)
                                                                        .Select(x => new PoolCategoryViewModel
                                                                        {
                                                                            Id = x.Id,
                                                                            Name = x.Name,
                                                                            Alias = x.Alias,
                                                                            Image = x.Image
                                                                        }).ToList();
            headerModel.PoolCategories = poolCategoryModels;

            return PartialView(headerModel);
        }

        public ActionResult Index()
        {
            var homeModel = new HomeViewModel();
            var blogs = _blogRepository.GetMany(x => !x.IsDeleted &&
                                                x.IsActive)
                                                .OrderByDescending(x => x.CreatedOn)
                                                .Take(4)
                                                .ToList();

            var blogModels = Mapper.Map<List<Blog>, List<BlogViewModel>>(blogs);
            homeModel.Blogs = blogModels;
            homeModel.Courses = _courses;
            homeModel.PoolCategories = GetPoolCategories();
            return View(homeModel);
        }

        private List<PoolCategoryViewModel> GetPoolCategories()
        {
            var poolCategoryModels = _poolCategoryRepository.GetMany(x => x.IsActive &&
                                                                      !x.IsDeleted)
                                                                      .Select(x => new PoolCategoryViewModel
                                                                      {
                                                                          Id = x.Id,
                                                                          Name = x.Name,
                                                                          Alias = x.Alias,
                                                                          Image = x.Image,
                                                                          Pools = x.Pools.Select(c => new PoolViewModel { Id = c.Id, Name = c.Name, Image = c.Image, Alias = c.Alias, Address = c.Address })
                                                                      }).ToList();

            return poolCategoryModels;
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