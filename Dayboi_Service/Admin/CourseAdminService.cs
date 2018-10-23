using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using System;

namespace Dayboi_Service.Admin
{
    public interface ICourseAdminService
    {
        Course Create(Course entity);
    }
    public class CourseAdminService: ICourseAdminService
    {
        private readonly ICourseRepository _courseRepository;

        private readonly IUnitOfWork _unitOfWork;

        public CourseAdminService(ICourseRepository courseRepository,
                                    IUnitOfWork unitOfWork)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        public Course Create(Course entity)
        {
            try
            {
                entity.CreatedOn = DateTime.Now;
                entity.IsDeleted = false;
                _courseRepository.Add(entity);
                _unitOfWork.Commit();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
