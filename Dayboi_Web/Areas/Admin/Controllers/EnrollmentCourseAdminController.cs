using AutoMapper;
using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using Dayboi_Web.Areas.Admin.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Dayboi_Web.Areas.Admin.Controllers
{
    public class EnrollmentCourseAdminController : Controller
    {
        private readonly IEnrollmentCourseRepository _enrollmentCourseRepository;
        private readonly IEnrollmentCourseStatusRepository _enrollmentCourseStatusRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EnrollmentCourseAdminController(IEnrollmentCourseRepository enrollmentCourseRepository,
                                                IUnitOfWork unitOfWork,
                                                ICourseRepository courseRepository,
                                                IEnrollmentCourseStatusRepository enrollmentCourseStatusRepository)
        {
            _enrollmentCourseRepository = enrollmentCourseRepository;
            _unitOfWork = unitOfWork;
            _courseRepository = courseRepository;
            _enrollmentCourseStatusRepository = enrollmentCourseStatusRepository;
        }
        // GET: Admin/EnrollmentCourseAdmin
        public ActionResult Index()
        {
            return View(GetEnrollmentCourses());
        }

        private IEnumerable<EnrollmentCourseModel> GetEnrollmentCourses()
        {
            var enrollmentCourses = _enrollmentCourseRepository.GetMany(x => !x.IsDeleted)
                                                                .Include(x => x.Course)
                                                                .Include(x => x.EnrollmentCourseStatus)
                                                                .ToList();

            var toReturn = Mapper.Map<IEnumerable<EnrollmentCourse>, IEnumerable<EnrollmentCourseModel>>(enrollmentCourses);
            return toReturn;
        }

        public ActionResult Edit(int id)
        {
            if (id > 0)
            {
                var course = _enrollmentCourseRepository.GetMany(x => !x.IsDeleted && x.Id == id).FirstOrDefault();
                if (course != null)
                {
                    var enrollmentCourseStatues = _enrollmentCourseStatusRepository.GetMany(x => !x.IsDeleted).Select(x => new { Id = x.Id, Name = x.Name }).ToList();
                    ViewBag.EnrollmentCourseStatues = enrollmentCourseStatues;

                    var courses = _courseRepository.GetMany(x => !x.IsDeleted).Select(x => new { Id = x.Id, Name = x.Name }).ToList();
                    ViewBag.Courses = courses;

                    var toReturn = Mapper.Map<EnrollmentCourse, EnrollmentCourseModel>(course);
                    return View(toReturn);
                }
                else
                    return null;
            }
            return null;
        }

        [HttpPost]
        public JsonResult Update(EnrollmentCourseModel model)
        {
            try
            {
                var entity = _enrollmentCourseRepository.GetMany(x => x.Id == model.Id && !x.IsDeleted)
                                                .FirstOrDefault();
                if (entity != null)
                {
                    entity.FullName = model.FullName;
                    entity.Note = model.Note;
                    entity.CourseId = model.CourseId;
                    entity.EnrollmentCourseStatusId = model.EnrollmentCourseStatusId;

                    if (User.Identity.IsAuthenticated)
                    {
                        entity.UpdatedOn = DateTime.Now;
                        entity.UpdatedBy = User.Identity.GetUserId();
                    }
                    _enrollmentCourseRepository.Update(entity);
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
    }
}