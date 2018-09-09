using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayboi_Service.Admin
{
    public interface IProductService
    {
        Product Create(Product entity);

        Product GetById(int id);

        IEnumerable<Product> GetAll();

        bool Update(Product entity);
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productReponsitory;

        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository productReponsitory, IUnitOfWork unitOfWork)
        {
            _productReponsitory = productReponsitory;
            _unitOfWork = unitOfWork;
        }
        public Product Create(Product entity)
        {
            try
            {
                var product = _productReponsitory.Add(entity);
                _unitOfWork.Commit();
                return product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            var toReturn = _productReponsitory.GetMany(x => !x.IsDeleted)
                                                .Include(x => x.Category)
                                                .ToList();
            return toReturn;
        }

        public Product GetById(int id)
        {
            var toReturn = _productReponsitory.GetMany(x => x.Id == id && !x.IsDeleted)
                                                .Include(x => x.Category)
                                                .FirstOrDefault();

            return toReturn;
        }

        public bool Update(Product entity)
        {
            try
            {
                _productReponsitory.Update(entity);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
