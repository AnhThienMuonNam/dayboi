using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayboi_Infrastructure.Repositories
{
   
    public interface ICategoryRepository : IRepository<Category>
    {
    }

    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public override Category Add(Category entity)
        {
            entity.CreatedOn = DateTime.Now;
            entity.IsDeleted = false;
            entity.IsActive = true;

            return base.Add(entity);
        }

        public override void Update(Category entity)
        {
            entity.UpdatedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
