using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;

namespace Dayboi_Infrastructure.Repositories
{
    public interface IOrderStatusRepository : IRepository<OrderStatus>
    {
    }

    public class OrderStatusRepository : RepositoryBase<OrderStatus>, IOrderStatusRepository
    {
        public OrderStatusRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}