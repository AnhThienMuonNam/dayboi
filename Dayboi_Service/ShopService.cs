using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayboi_Service
{
    public interface IShopService
    {
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);
        Product GetProductById(int id);

        Category GetCategoryId(int categoryId);


    }
    public class ShopService : IShopService
    {
        private readonly IProductRepository _productReponsitory;
        private readonly ICategoryRepository _categoryReponsitory;

        private readonly IUnitOfWork _unitOfWork;
        public ShopService(IProductRepository productReponsitory, ICategoryRepository categoryReponsitory, IUnitOfWork unitOfWork)
        {
            _productReponsitory = productReponsitory;
            _categoryReponsitory = categoryReponsitory;
            _unitOfWork = unitOfWork;
        }

        public Category GetCategoryId(int categoryId)
        {
            var toReturn = _categoryReponsitory.GetMany(x => !x.IsDeleted && x.IsActive && x.Id == categoryId)
                                               .Include(x => x.Products)
                                               .FirstOrDefault();
            return toReturn;
        }

        public Product GetProductById(int id)
        {
            var toReturn = _productReponsitory.GetMany(x => !x.IsDeleted && x.IsActive && x.Id == id)
                                               .Include(x => x.Category)
                                               .Include(x => x.ProductTags)
                                               .FirstOrDefault();
            return toReturn;
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            var toReturn = _productReponsitory.GetMany(x => !x.IsDeleted && x.IsActive && x.CategoryId == categoryId)
                                               .Include(x => x.Category)
                                               .ToList();
            return toReturn;
        }
    }
}
