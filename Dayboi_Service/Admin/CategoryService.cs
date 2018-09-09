using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Dayboi_Service.Admin
{
    public interface ICategoryService
    {
        Category Create(Category entity);

        Category GetById(int id);

        IEnumerable<Category> GetAll();

        bool Update(Category entity);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryReponsitory;

        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryReponsitory, IUnitOfWork unitOfWork)
        {
            _categoryReponsitory = categoryReponsitory;
            _unitOfWork = unitOfWork;
        }

        public Category Create(Category category)
        {
            try
            {
                _categoryReponsitory.Add(category);
                _unitOfWork.Commit();
                return category;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Category> GetAll()
        {
            try
            {
                var toReturn = _categoryReponsitory.GetMany(x => !x.IsDeleted).ToList();
                return toReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Category GetById(int id)
        {
            try
            {
                var toReturn = _categoryReponsitory.GetMany(x => x.Id == id && !x.IsDeleted)
                                                .Include(x => x.Products)
                                                .FirstOrDefault();

                return toReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Category entity)
        {
            try
            {
                _categoryReponsitory.Update(entity);
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