using AutoMapper;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using Dayboi_Web.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Dayboi_Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        // GET: Course
        public ActionResult Index()
        {
            return View(GetCourses());
        }

        private IEnumerable<CourseViewModel> GetCourses()
        {
            var blogs = _courseRepository.GetMany(x => x.IsActive &&
                                                !x.IsDeleted)
                                                .Select(x => new CourseViewModel
                                                {
                                                    Id = x.Id,
                                                    Name = x.Name,
                                                    Image = x.Image,
                                                    CreatedOn = x.CreatedOn,
                                                    Description = x.Description,
                                                    Alias = x.Alias
                                                }).ToList();
            return blogs;
        }

        [HttpGet]
        public ActionResult CourseDetail(int courseId)
        {
            return View(GetCourseById(courseId));
        }

        private CourseViewModel GetCourseById(int blogId)
        {
            var course = _courseRepository.GetMany(x => x.Id == blogId
                                                && x.IsActive
                                                && !x.IsDeleted)
                                                .Include(x => x.CourseTags)
                                                .FirstOrDefault();

            var returnBlog = Mapper.Map<Course, CourseViewModel>(course);
            returnBlog.OtherCourses = _courseRepository.GetMany(x => x.Id != blogId
                                                  && !x.IsDeleted && x.IsActive)
                                                  .Select(x => new CourseViewModel()
                                                  {
                                                      Id = x.Id,
                                                      Name = x.Name,
                                                      Alias = x.Alias,
                                                      Image = x.Image
                                                  }).ToList();
            return returnBlog;
        }
    }
}