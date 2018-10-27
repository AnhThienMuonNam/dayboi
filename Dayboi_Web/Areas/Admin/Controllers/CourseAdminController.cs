using AutoMapper;
using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using Dayboi_Service.Admin;
using Dayboi_Web.Areas.Admin.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Dayboi_Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class CourseAdminController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseAdminService _courseAdminService;
        private readonly ICourseTagRepository _courseTagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CourseAdminController(ICourseRepository courseRepository,
                                   ICourseAdminService courseAdminService,
                                   ICourseTagRepository courseTagRepository,
                                   IUnitOfWork unitOfWork)
        {
            _courseRepository = courseRepository;
            _courseTagRepository = courseTagRepository;
            _courseAdminService = courseAdminService;
            _unitOfWork = unitOfWork;
        }
        // GET: Admin/CourseAdmin
        public ActionResult Index()
        {
            var courses = GetCourses();
            return View(courses);
        }

        private IEnumerable<CourseModel> GetCourses()
        {
            var courses = _courseRepository.GetMany(x => !x.IsDeleted).ToList();

            var toReturn = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseModel>>(courses);
            return toReturn;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateCourse(CourseModel model)
        {
            var course = Mapper.Map<CourseModel, Course>(model);
            AddCourseTag(course, model.Tags);
            if (User.Identity.GetUserId() != null)
            {
                course.CreatedBy = User.Identity.GetUserId();
            }
            var toReturn = _courseAdminService.Create(course);
            return Json(new
            {
                IsSuccess = true,
                Data = toReturn
            });
        }

        public ActionResult Edit(int id)
        {
            if (id > 0)
            {
                var course = _courseRepository.GetMany(x => !x.IsDeleted &&
                                                        x.Id == id)
                                                        .Include(x => x.CourseTags)
                                                        .FirstOrDefault();
                if (course != null)
                {
                    var toReturn = Mapper.Map<Course, CourseModel>(course);
                    return View(toReturn);
                }
                else
                    return null;
            }
            return null;
        }

        [HttpPost]
        public JsonResult UpdateCourse(CourseModel model)
        {
            try
            {
                var entity = _courseRepository.GetMany(x => x.Id == model.Id && !x.IsDeleted)
                                                .Include(x => x.CourseTags)
                                                .FirstOrDefault();
                if (entity != null)
                {
                    entity.Name = model.Name;
                    entity.Alias = model.Alias;
                    entity.MetaKeyword = model.MetaKeyword;
                    entity.Description = model.Description;
                    entity.Image = model.Image;
                    entity.IsActive = model.IsActive;
                    entity.Content = model.Content;

                    AddCourseTag(entity, model.Tags);
                    if (User.Identity.IsAuthenticated)
                    {
                        entity.UpdatedBy = User.Identity.GetUserId();
                    }
                    _courseRepository.Update(entity);
                    _unitOfWork.Commit();
                }
                return Json(new
                {
                    IsSuccess = true
                });
            }
            catch
            {
                return Json(new
                {
                    IsSuccess = false
                });
            }
        }

        private void AddCourseTag(Course course, List<string> tags)
        {
            if (course.Id > 0)
            {
                _courseTagRepository.DeleteMulti(x => x.CourseId == course.Id);
            }
            else
            {
                course.CourseTags = new List<CourseTag>();
            }
            if (tags.Count > 0)
            {
                foreach (var newTag in tags)
                {
                    var tag = new CourseTag();
                    tag.Tag = newTag;
                    course.CourseTags.Add(tag);
                }
            }
        }
    }
}