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
    public interface ICategoryService
    {
        Category Create(Category category);

        IEnumerable<Category> GetCategories();

        Category GetById(int categoryId);


    }
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryReponsitory;

        private readonly IUnitOfWork unitOfWork;
        public CategoryService(ICategoryRepository _categoryReponsitory, IUnitOfWork _unitOfWork)
        {
            categoryReponsitory = _categoryReponsitory;
            unitOfWork = _unitOfWork;
        }
        public Category Create(Category category)
        {
            try
            {
                categoryReponsitory.Add(category);
                unitOfWork.Commit();
                return category;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Category GetById(int categoryId)
        {
            var toReturn = categoryReponsitory.GetMany(x => x.Id == categoryId && !x.IsDeleted)
                                                .Include(x => x.Products)
                                                .FirstOrDefault();

            return toReturn;
        }

        public IEnumerable<Category> GetCategories()
        {
            return categoryReponsitory.GetMulti(x => !x.IsDeleted);
        }
    }
}
