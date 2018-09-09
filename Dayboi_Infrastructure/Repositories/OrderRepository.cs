using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using System;

namespace Dayboi_Infrastructure.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
    }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public override Order Add(Order entity)
        {
            entity.CreatedOn = DateTime.Now;
            entity.IsDeleted = false;
        
            return base.Add(entity);
        }
    }
}