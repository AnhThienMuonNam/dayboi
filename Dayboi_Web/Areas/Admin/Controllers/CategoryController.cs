using AutoMapper;
using Dayboi_Infrastructure.Models;
using Dayboi_Service;
using Dayboi_Service.Admin;
using Dayboi_Web.ViewModels;
using Microsoft.AspNet.Identity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Dayboi_Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ICommonService _commonService;

        public CategoryController(ICategoryService categoryService, ICommonService commonService)
        {
            _categoryService = categoryService;
            _commonService = commonService;
        }

        // GET: Admin/Category
        public ActionResult Index()
        {
            var categories = GetCategories();
            return View(categories);
        }

        public ActionResult Create()
        {
            _commonService.CheckIfFileDeleted();
            return View();
        }

        [HttpPost]
        public JsonResult CreateCategory(CategoryModel model)
        {
            var category = Mapper.Map<CategoryModel, Category>(model);
            var toReturn = _categoryService.Create(category);
            return Json(new
            {
                IsSuccess = true,
                Data = toReturn
            });
        }

        private IEnumerable<CategoryModel> GetCategories()
        {
            var categories = _categoryService.GetAll();

            var toReturn = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel>>(categories);
            return toReturn;
        }


        public ActionResult Edit(int id)
        {
            if (id > 0)
            {
                var category = _categoryService.GetById(id);
                if (category != null)
                {
                    var toReturn = Mapper.Map<Category, CategoryModel>(category);
                    return View(toReturn);
                }
                else
                    return null;
            }
            return null;
        }

        [HttpPost]
        public JsonResult UpdateCategory(CategoryModel model)
        {
            var category = _categoryService.GetById(model.Id);
            var toReturn = false;
            if (category != null)
            {
                category.Name = model.Name;
                category.Alias = model.Alias;
                category.MetaKeyword = model.MetaKeyword;
                category.Description = model.Description;
                category.Image = model.Image;
                category.IsActive = model.IsActive;
                if (User.Identity.IsAuthenticated)
                {
                    category.UpdatedBy = User.Identity.GetUserId();
                }
                toReturn = _categoryService.Update(category);
            }
            return Json(new
            {
                IsSuccess = toReturn
            });
        }
    }
}