using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;

namespace Dayboi_Infrastructure.Repositories
{
    public interface IBlogRepository : IRepository<Blog>
    {
    }

    public class BlogRepository : RepositoryBase<Blog>, IBlogRepository
    {
        public BlogRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IBlogTagRepository : IRepository<BlogTag>
    {
    }

    public class BlogTagRepository : RepositoryBase<BlogTag>, IBlogTagRepository
    {
        public BlogTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}