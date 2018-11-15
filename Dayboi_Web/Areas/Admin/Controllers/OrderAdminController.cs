using AutoMapper;
using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using Dayboi_Web.Areas.Admin.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Dayboi_Web.Areas.Admin.Controllers
{
    public class OrderAdminController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderAdminController(IOrderRepository orderRepository,
                                    IOrderStatusRepository orderStatusRepository,
                                    IPaymentMethodRepository paymentMethodRepository,
                                    IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _orderStatusRepository = orderStatusRepository;
            _paymentMethodRepository = paymentMethodRepository;
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/OrderAdmin
        public ActionResult Index()
        {
            var orders = GetOrders();
            return View(orders);
        }

        public ActionResult Edit(int id)
        {
            if (id > 0)
            {
                var order = _orderRepository.GetMany(x => !x.IsDeleted && x.Id == id)
                                                        .Include(x => x.OrderDetails.Select(c => c.Product.Category))
                                                        .FirstOrDefault();
                if (order != null)
                {
                    var toReturn = Mapper.Map<Order, OrderAdminModel>(order);

                    var orderstatues = _orderStatusRepository.GetMany(x => !x.IsDeleted).Select(x => new { Id = x.Id, Name = x.Name }).ToList();
                    var paymentMethods = _paymentMethodRepository.GetMany(x => !x.IsDeleted).Select(x => new { Id = x.Id, Name = x.Name }).ToList();

                    ViewBag.Orderstatues = orderstatues;
                    ViewBag.PaymentMethods = paymentMethods;

                    return View(toReturn);
                }
                else
                    return null;
            }
            return null;
        }

        [HttpPost]
        public JsonResult UpdateOrder(int orderId, int orderStatusId)
        {
            try
            {
                var entity = _orderRepository.GetMany(x => x.Id == orderId && !x.IsDeleted)
                                                .FirstOrDefault();
                if (entity != null)
                {
                    entity.OrderStatusId = orderStatusId;
                    if (User.Identity.IsAuthenticated)
                    {
                        entity.UpdatedBy = User.Identity.GetUserId();
                    }
                    _orderRepository.Update(entity);
                    _unitOfWork.Commit();
                }
                return Json(new
                {
                    IsSuccess = true
                });
            }
            catch
            {
                return Json(new
                {
                    IsSuccess = false
                });
            }
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