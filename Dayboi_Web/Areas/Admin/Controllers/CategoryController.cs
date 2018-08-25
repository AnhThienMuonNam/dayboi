using AutoMapper;
using Dayboi_Infrastructure.Models;
using Dayboi_Service;
using Dayboi_Service.Admin;
using Dayboi_Web.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Dayboi_Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ICommonService commonService;

        public CategoryController(ICategoryService _categoryService, ICommonService _commonService)
        {
            categoryService = _categoryService;
            commonService = _commonService;
        }

        // GET: Admin/Category
        public ActionResult Index()
        {
            var categories = GetCategories();
            return View(categories);
        }

        public ActionResult Create()
        {
            commonService.CheckIfFileDeleted();
            return View();
        }

        [HttpPost]
        public JsonResult CreateCategory(CategoryModel model)
        {
            var category = Mapper.Map<CategoryModel, Category>(model);
            var toReturn = categoryService.Create(category);
            return Json(new
            {
                data = toReturn
            });
        }

        private IEnumerable<CategoryModel> GetCategories()
        {
            var categories = categoryService.GetCategories();

            var toReturn = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel>>(categories);
            return toReturn;
        }


        public ActionResult Edit(int id)
        {
            if (id > 0)
            {
                var category = categoryService.GetById(id);

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
    }
}