using AutoMapper;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using Dayboi_Service.Admin;
using Dayboi_Web.Areas.Admin.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace Dayboi_Web.Areas.Admin.Controllers
{
    public class BlogAdminController : Controller
    {
        private readonly IBlogCategoryRepository _blogCategoryRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly IBlogAdminService _blogAdminService;

        public BlogAdminController(IBlogCategoryRepository blogCategoryRepository,
                                    IBlogRepository blogRepository,
                                    IBlogAdminService blogAdminService)
        {
            _blogCategoryRepository = blogCategoryRepository;
            _blogRepository = blogRepository;
            _blogAdminService = blogAdminService;
        }

        // GET: Admin/Blog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var blogCategories = _blogCategoryRepository.GetMany(x => !x.IsDeleted).ToList();
            ViewBag.BlogCategories = blogCategories;

            return View();
        }

        [HttpPost]
        public JsonResult CreateBlog(BlogModel model)
        {
            var blog = Mapper.Map<BlogModel, Blog>(model);
            if (User.Identity.GetUserId() != null)
            {
                blog.CreatedBy = User.Identity.GetUserId();
            }
            var toReturn = _blogAdminService.Create(blog);
            return Json(new
            {
                IsSuccess = true,
                Data = toReturn
            });
        }
    }
}