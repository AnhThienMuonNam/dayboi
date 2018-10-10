using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using System;

namespace Dayboi_Service.Admin
{
    public interface IBlogAdminService
    {
        Blog Create(Blog entity);
    }

    public class BlogAdminService : IBlogAdminService
    {
        private readonly IBlogRepository _blogRepository;

        private readonly IUnitOfWork _unitOfWork;

        public BlogAdminService(IBlogRepository blogRepository,
                                    IUnitOfWork unitOfWork)
        {
            _blogRepository = blogRepository;
            _unitOfWork = unitOfWork;
        }

        public Blog Create(Blog entity)
        {
            try
            {
                entity.CreatedOn = DateTime.Now;
                entity.IsDeleted = false;
                _blogRepository.Add(entity);
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