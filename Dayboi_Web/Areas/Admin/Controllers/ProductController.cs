using AutoMapper;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using Dayboi_Service;
using Dayboi_Service.Admin;
using Dayboi_Web.Controllers.Models;
using Dayboi_Web.ViewModels;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Dayboi_Web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly ICommonService _commonService;
        private readonly IProductTagRepository _productTagRepository;

        public ProductController(ICategoryService categoryService, ICommonService commonService,
            IProductService productService,
            IProductTagRepository productTagRepository)
        {
            _categoryService = categoryService;
            _commonService = commonService;
            _productService = productService;
            _productTagRepository = productTagRepository;
        }

        // GET: Admin/Product
        public ActionResult Index()
        {
            var products = GetProducts();
            return View(products);
        }

        public ActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetAll().Select(x => new SelectItemModel { Text = x.Name, Value = x.Id });
            return View();
        }

        public ActionResult Edit(int id)
        {
            if (id > 0)
            {
                var product = _productService.GetById(id);
                if (product != null)
                {
                    ViewBag.Categories = _categoryService.GetAll().Select(x => new SelectItemModel { Text = x.Name, Value = x.Id });

                    var toReturn = Mapper.Map<Product, ProductModel>(product);
                    return View(toReturn);
                }
                else
                    return null;
            }
            return null;
        }

        [HttpPost]
        public JsonResult CreateProduct(ProductModel model)
        {
            var product = Mapper.Map<ProductModel, Product>(model);
            AddProductTag(product, model.Tags);
            var toReturn = _productService.Create(product);
            return Json(new
            {
                IsSuccess = true,
                Data = toReturn
            });
        }

        [HttpPost]
        public JsonResult UpdateProduct(ProductModel model)
        {
            var product = _productService.GetById(model.Id);
            var toReturn = false;
            if (product != null)
            {
                product.Name = model.Name;
                product.Alias = model.Alias;
                product.MetaKeyword = model.MetaKeyword;
                product.Description = model.Description;
                product.Images = model.Images;
                product.IsActive = model.IsActive;
                product.CategoryId = model.CategoryId;
                product.Price = model.Price;
                product.OtherPrice = model.OtherPrice;
                AddProductTag(product, model.Tags);
                if (User.Identity.IsAuthenticated)
                {
                    product.UpdatedBy = User.Identity.GetUserId();
                }
                toReturn = _productService.Update(product);
            }
            return Json(new
            {
                IsSuccess = toReturn
            });
        }

        private void AddProductTag(Product product, List<string> tags)
        {
            if (product.Id > 0)
            {
                _productTagRepository.DeleteMulti(x => x.ProductId == product.Id);
            }
            else
            {
                product.ProductTags = new List<ProductTag>();
            }
            if (tags.Count() > 0)
            {
                foreach (var newTag in tags)
                {
                    var tag = new ProductTag();
                    tag.Tag = newTag;
                    product.ProductTags.Add(tag);
                }
            }
        }

        private IEnumerable<ProductModel> GetProducts()
        {
            var products = _productService.GetAll();

            var toReturn = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(products);
            return toReturn;
        }
    }
}