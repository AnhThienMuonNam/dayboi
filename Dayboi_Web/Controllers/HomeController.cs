using AutoMapper;
using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using Dayboi_Service.Admin;
using Dayboi_Service.Enum;
using Dayboi_Web.ViewModels;
using Microsoft.AspNet.Identity;
using System;
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
        private readonly IEnrollmentCourseRepository _enrollmentCourseRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IUnitOfWork _unitOfWork;

        private List<CourseViewModel> _courses = new List<CourseViewModel>();
        private List<SkillViewModel> _skill = new List<SkillViewModel>();


        public HomeController(ICategoryService categoryService,
                            IBlogRepository blogRepository,
                            IPoolCategoryRepository poolCategoryRepository,
                            ICourseRepository courseRepository,
                            IEnrollmentCourseRepository enrollmentCourseRepository,
                            ISkillRepository skillRepository,
                            IUnitOfWork unitOfWork)
        {
            _categoryService = categoryService;
            _blogRepository = blogRepository;
            _courseRepository = courseRepository;
            _skillRepository = skillRepository;
            _poolCategoryRepository = poolCategoryRepository;
            _enrollmentCourseRepository = enrollmentCourseRepository;
            _unitOfWork = unitOfWork;
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

            _skill = _skillRepository.GetMany(x => x.IsActive &&
                                                    !x.IsDeleted)
                                                    .Select(x => new SkillViewModel
                                                    {
                                                        Id = x.Id,
                                                        Name = x.Name,
                                                        Alias = x.Alias,
                                                        Image = x.Image,
                                                        Description = x.Description
                                                    }).ToList();

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
                                                                            Image = x.Image,
                                                                        }).ToList();
            headerModel.PoolCategories = poolCategoryModels;


            headerModel.Skills = _skill;

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
            homeModel.Skills = _skill;
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

        [HttpPost]
        public JsonResult RegisterCourse(EnrollmentCourseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    IsSuccess = false,
                });
            }

            try
            {
                var isExisting = _enrollmentCourseRepository.GetMany(x => x.Phone == model.Phone && x.CourseId == model.CourseId && !x.IsDeleted && x.EnrollmentCourseStatusId == (int)eEnrollmentCourseStatus.ChoXacNhan).Any();
                if (isExisting)
                {
                    return Json(new
                    {
                        IsSuccess = false,
                        Message = "Bạn đã đăng ký khoá học này!"
                    });
                }

                var entity = Mapper.Map<EnrollmentCourseViewModel, EnrollmentCourse>(model);
                entity.EnrollmentCourseStatusId = (int)eEnrollmentCourseStatus.ChoXacNhan;
                entity.CreatedOn = DateTime.Now;
                if (User.Identity.IsAuthenticated)
                {
                    entity.CreatedBy = User.Identity.GetUserId();
                    entity.UserId = User.Identity.GetUserId();
                }

                _enrollmentCourseRepository.Add(entity);
                _unitOfWork.Commit();
                return Json(new
                {
                    IsSuccess = true
                });
            }

            catch (Exception ex)
            {
                return Json(new
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                });
            }
        }
    }
}