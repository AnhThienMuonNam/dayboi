using AutoMapper;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using Dayboi_Service;
using Dayboi_Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Dayboi_Web.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public ShopController(IShopService shopService, ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _shopService = shopService;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        // GET: Shop
        public ActionResult Index(int categoryId)
        {
            if (categoryId > 0)
            {
                var category = _shopService.GetCategoryId(categoryId);
                var categoryModel = Mapper.Map<Category, CategoryModel>(category);

                var categories = _categoryRepository.GetMany(x => !x.IsDeleted && x.IsActive).ToList();
                ViewBag.Categories = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel>>(categories);

                var newestProducts = _productRepository.GetMany(x => !x.IsDeleted && x.IsActive)
                                                        .OrderByDescending(x => x.CreatedOn)
                                                        .Take(5)
                                                        .ToList();

                ViewBag.NewestProducts = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(newestProducts);
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