using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;

namespace Dayboi_Infrastructure.Repositories
{
    public interface IAspNetUsersRepository : IRepository<AspNetUser>
    {
    }

    public class AspNetUsersRepository : RepositoryBase<AspNetUser>, IAspNetUsersRepository
    {
        public AspNetUsersRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}