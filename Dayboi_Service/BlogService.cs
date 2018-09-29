using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dayboi_Service
{
    public interface IBlogService
    {
        IEnumerable<Blog> GetAllBlogs();
        
    }

    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BlogService(IBlogRepository blogRepository,
                            IUnitOfWork unitOfWork)
        {
            _blogRepository = blogRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Blog> GetAllBlogs()
        {
            try
            {
                var blogs = _blogRepository.GetMany(x => x.IsActive &&
                                                    !x.IsDeleted).ToList();
                return blogs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}