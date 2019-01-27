using AutoMapper;
using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using Dayboi_Web.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Dayboi_Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BlogController(IBlogRepository blogRepository,
                                IUnitOfWork unitOfWork)
        {
            _blogRepository = blogRepository;
            _unitOfWork = unitOfWork;
        }

        // GET: Blog
        public ActionResult Index()
        {
            var blogs = GetBlogs();
            ViewBag.TopBlogs = blogs.OrderByDescending(x => x.ViewCount).Take(5);
            return View(GetBlogs());
        }

        private IEnumerable<BlogViewModel> GetBlogs()
        {
            var blogs = _blogRepository.GetMany(x => x.IsActive &&
                                                !x.IsDeleted)
                                                .Select(x => new BlogViewModel
                                                {
                                                    Id = x.Id,
                                                    Title = x.Title,
                                                    Image = x.Image,
                                                    CreatedOn = x.CreatedOn,
                                                    SortDescription = x.SortDescription,
                                                    Alias = x.Alias,
                                                    ViewCount = x.ViewCount
                                                }).ToList();
            return blogs;
        }

        private IEnumerable<BlogViewModel> GetTopBlogs()
        {
            var blogs = _blogRepository.GetMany(x => x.IsActive &&
                                                !x.IsDeleted)
                                                .Select(x => new BlogViewModel
                                                {
                                                    Id = x.Id,
                                                    Title = x.Title,
                                                    Image = x.Image,
                                                    CreatedOn = x.CreatedOn,
                                                    SortDescription = x.SortDescription,
                                                    Alias = x.Alias,
                                                    ViewCount = x.ViewCount
                                                }).OrderByDescending(x => x.ViewCount).Take(5);
            return blogs;
        }

        [HttpGet]
        public ActionResult BlogDetail(int blogId)
        {
            ViewBag.TopBlogs = GetTopBlogs();

            return View(GetBlogById(blogId));
        }

        private BlogViewModel GetBlogById(int blogId)
        {
            var blog = _blogRepository.GetMany(x => x.Id == blogId
                                                && !x.IsDeleted)
                                                .Include(x => x.BlogTags)
                                                .FirstOrDefault();

            var returnBlog = Mapper.Map<Blog, BlogViewModel>(blog);
            if (blog.ViewCount == null)
            {
                blog.ViewCount = 1;
            }
            else
            {
                blog.ViewCount++;
            }
            _unitOfWork.Commit();

            return returnBlog;
        }
    }
}