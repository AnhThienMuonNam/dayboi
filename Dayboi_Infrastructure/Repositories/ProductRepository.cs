using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using System;

namespace Dayboi_Infrastructure.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public override Product Add(Product entity)
        {
            entity.CreatedOn = DateTime.Now;
            entity.IsDeleted = false;
            entity.IsActive = true;

            return base.Add(entity);
        }

        public override void Update(Product entity)
        {
            entity.UpdatedOn = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IProductTagRepository : IRepository<ProductTag>
    {
    }

    public class ProductTagRepository : RepositoryBase<ProductTag>, IProductTagRepository
    {
        public ProductTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}