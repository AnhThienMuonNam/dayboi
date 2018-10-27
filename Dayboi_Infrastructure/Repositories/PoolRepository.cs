using Dayboi_Infrastructure.Infrastructures;

namespace Dayboi_Infrastructure.Repositories
{
    public interface IPoolRepository : IRepository<Models.Pool>
    {
    }

    public class PoolRepository : RepositoryBase<Models.Pool>, IPoolRepository
    {
        public PoolRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    //
    public interface IPoolCategoryRepository : IRepository<Models.PoolCategory>
    {
    }

    public class PoolCategoryRepository : RepositoryBase<Models.PoolCategory>, IPoolCategoryRepository
    {
        public PoolCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    //
    public interface IPoolTagRepository : IRepository<Models.PoolTag>
    {
    }

    public class PoolTagRepository : RepositoryBase<Models.PoolTag>, IPoolTagRepository
    {
        public PoolTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}