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


    //Order details
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
    }

    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    //order statues
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