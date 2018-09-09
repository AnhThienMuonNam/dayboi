using AutoMapper;
using Dayboi_Infrastructure.Models;
using Dayboi_Service;
using Dayboi_Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Dayboi_Web.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        // GET: Shop
        public ActionResult Index(int categoryId)
        {
            if (categoryId > 0)
            {
                var category = _shopService.GetCategoryId(categoryId);
                var categoryModel = Mapper.Map<Category, CategoryModel>(category);
                return View(categoryModel);
            }
            return null;
        }

        private IEnumerable<ProductModel> GetProductsByCategoryId(int categoryId)
        {
            var products = _shopService.GetProductsByCategoryId(categoryId);
            var productModels = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(products);
            return productModels;
        }

        public ActionResult Product(int productId)
        {
            if (productId > 0)
            {
                var product = _shopService.GetProductById(productId);
                var productModel = Mapper.Map<Product, ProductModel>(product);

                return View(productModel);
            }
            return null;
        }
    }
}