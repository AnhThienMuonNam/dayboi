using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;

namespace Dayboi_Infrastructure.Repositories
{
    public interface IBlogCategoryRepository : IRepository<BlogCategory>
    {
    }

    public class BlogCategoryRepository : RepositoryBase<BlogCategory>, IBlogCategoryRepository
    {
        public BlogCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}