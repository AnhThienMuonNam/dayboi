using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;

namespace Dayboi_Infrastructure.Repositories
{
    public interface IAspNetUsersRepository : IRepository<ApplicationUser>
    {
    }

    public class AspNetUsersRepository : RepositoryBase<ApplicationUser>, IAspNetUsersRepository
    {
        public AspNetUsersRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}