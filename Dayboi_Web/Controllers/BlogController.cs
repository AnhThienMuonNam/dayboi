using AutoMapper;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using Dayboi_Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Dayboi_Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        // GET: Blog
        public ActionResult Index()
        {
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
                                                    Alias = x.Alias
                                                }).ToList();
            return blogs;
        }

        [HttpGet]
        public ActionResult BlogDetail(int blogId)
        {
            return View(GetBlogById(blogId));
        }

        private BlogViewModel GetBlogById(int blogId)
        {
            var blog = _blogRepository.GetMany(x => x.Id == blogId
                                                && !x.IsDeleted)
                                                .FirstOrDefault();

            var returnBlog = Mapper.Map<Blog, BlogViewModel>(blog);
            var aa = WebUtility.HtmlDecode(returnBlog.Content);
            var bb = HttpUtility.HtmlDecode(returnBlog.Content);
            return returnBlog;
        }
    }
}