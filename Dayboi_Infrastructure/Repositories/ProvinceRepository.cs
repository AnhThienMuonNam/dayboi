using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;

namespace Dayboi_Infrastructure.Repositories
{
    public interface IProvinceRepository : IRepository<Province>
    {
    }

    public class ProvinceRepository : RepositoryBase<Province>, IProvinceRepository
    {
        public ProvinceRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}