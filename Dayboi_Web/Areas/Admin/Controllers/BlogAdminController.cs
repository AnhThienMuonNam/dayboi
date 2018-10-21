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
    public class BlogAdminController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IBlogAdminService _blogAdminService;
        private readonly IBlogTagRepository _blogTagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BlogAdminController(IBlogRepository blogRepository,
                                    IBlogAdminService blogAdminService,
                                    IBlogTagRepository blogTagRepository,
                                    IUnitOfWork unitOfWork)
        {
            _blogRepository = blogRepository;
            _blogTagRepository = blogTagRepository;
            _blogAdminService = blogAdminService;
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Blog
        public ActionResult Index()
        {
            var blogs = GetBlogs();
            return View(blogs);
        }

        private IEnumerable<BlogModel> GetBlogs()
        {
            var blogs = _blogRepository.GetMany(x => !x.IsDeleted).ToList();

            var toReturn = Mapper.Map<IEnumerable<Blog>, IEnumerable<BlogModel>>(blogs);
            return toReturn;
        }

        public ActionResult Create()
        {
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

        public ActionResult Edit(int id)
        {
            if (id > 0)
            {
                var blog = _blogRepository.GetMany(x => !x.IsDeleted &&
                                                        x.Id == id)
                                                        .Include(x => x.BlogTags)
                                                        .FirstOrDefault();
                if (blog != null)
                {
                    var toReturn = Mapper.Map<Blog, BlogModel>(blog);
                    return View(toReturn);
                }
                else
                    return null;
            }
            return null;
        }

        [HttpPost]
        public JsonResult UpdateBlog(BlogModel model)
        {
            try
            {
                var entity = _blogRepository.GetMany(x => x.Id == model.Id && !x.IsDeleted)
                                                .Include(x => x.BlogTags)
                                                .FirstOrDefault();
                if (entity != null)
                {
                    entity.Title = model.Title;
                    entity.Alias = model.Alias;
                    entity.MetaKeyword = model.MetaKeyword;
                    entity.SortDescription = model.SortDescription;
                    entity.Image = model.Image;
                    entity.IsActive = model.IsActive;
                    entity.Content = model.Content;

                    AddBlogTag(entity, model.Tags);
                    if (User.Identity.IsAuthenticated)
                    {
                        entity.UpdatedBy = User.Identity.GetUserId();
                    }
                    _blogRepository.Update(entity);
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

        private void AddBlogTag(Blog blog, List<string> tags)
        {
            if (blog.Id > 0)
            {
                _blogTagRepository.DeleteMulti(x => x.BlogId == blog.Id);
            }
            else
            {
                blog.BlogTags = new List<BlogTag>();
            }
            if (tags.Count() > 0)
            {
                foreach (var newTag in tags)
                {
                    var tag = new BlogTag();
                    tag.Tag = newTag;
                    blog.BlogTags.Add(tag);
                }
            }
        }
    }
}