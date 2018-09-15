using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using System;

namespace Dayboi_Service
{
    public interface IOrderService
    {
        Order Add(Order order);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public Order Add(Order order)
        {
            try
            {
                order.OrderStatusId = 1;
                _orderRepository.Add(order);
                _unitOfWork.Commit();
                return order;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}