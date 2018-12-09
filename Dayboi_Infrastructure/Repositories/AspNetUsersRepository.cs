using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using Microsoft.AspNet.Identity.EntityFramework;

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

    public interface IApplicationRoleRepository : IRepository<ApplicationRole>
    {
    }

    public class ApplicationRoleRepository : RepositoryBase<ApplicationRole>, IApplicationRoleRepository
    {
        public ApplicationRoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }


    public interface IIdentityUserRoleRepository : IRepository<IdentityUserRole>
    {
    }

    public class IdentityUserRoleRepository : RepositoryBase<IdentityUserRole>, IIdentityUserRoleRepository
    {
        public IdentityUserRoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}