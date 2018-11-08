using AutoMapper;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using Dayboi_Web.Areas.Admin.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Dayboi_Web.Areas.Admin.Controllers
{
    public class OrderAdminController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderAdminController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: Admin/OrderAdmin
        public ActionResult Index()
        {
            var orders = GetOrders();
            return View(orders);
        }

        private IEnumerable<OrderAdminModel> GetOrders()
        {
            var orders = _orderRepository.GetMany(x => !x.IsDeleted)
                                        .Include(x => x.PaymentMethod)
                                        .Include(x => x.OrderStatus)
                                        .ToList();

            var toReturn = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderAdminModel>>(orders);
            return toReturn;
        }

    }
}