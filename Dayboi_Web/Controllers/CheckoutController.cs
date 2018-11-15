using AutoMapper;
using Dayboi_Infrastructure.Models;
using Dayboi_Service;
using Dayboi_Web.Helper;
using Dayboi_Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Dayboi_Web.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IOrderService _orderService;

        public CheckoutController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: Checkout
        public ActionResult Index()
        {
            CheckoutModel checkoutModel = new CheckoutModel();
            var orderModel = TempData["MyCart_Order"];

            var cart = (List<CartModel>)Session["MyCart"];
            if (cart != null && orderModel != null)
            {
                checkoutModel.Order = (OrderModel)orderModel;
                checkoutModel.Carts = cart;
                TempData["Checkout_cart"] = checkoutModel;
            }
            return View(checkoutModel);
        }

        [HttpPost]
        public JsonResult CreateOrder()
        {
            var tempCheckout = TempData["Checkout_cart"];
            var checkoutModel = (CheckoutModel)tempCheckout;
            var order = Mapper.Map<OrderModel, Order>(checkoutModel.Order);

            var orderDetails = Mapper.Map<IEnumerable<CartModel>, IEnumerable<OrderDetail>>(checkoutModel.Carts);
            order.TotalPrice = orderDetails.Select(x => x.SumPrice).Sum();
            order.OrderDetails = orderDetails.ToList();

            var orderCreated = _orderService.Add(order);

            //send mail
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Template/order_detail.html"));
            content = content.Replace("{{orderId}}", orderCreated.Id.ToString());
            content = content.Replace("{{customerName}}", orderCreated.Name);
            content = content.Replace("{{createdDate}}", orderCreated.CreatedOn.ToString());
            content = content.Replace("{{totalMoney}}", orderCreated.TotalPrice.ToString());
            content = content.Replace("{{customerAddress}}", orderCreated.Address + ", " + orderCreated.WardName + ", " + orderCreated.DistrictName + ", " + orderCreated.ProvinceName);
            content = content.Replace("{{customerPhone}}", orderCreated.Phone);
            content = content.Replace("{{paymentMethod}}", checkoutModel.Order.PaymentMethodName);

            var orderDetailAsStringToSendMailTemplate = string.Empty;
            foreach (var item in orderCreated.OrderDetails)
            {
                orderDetailAsStringToSendMailTemplate += CreateOrderDetailTemplate(item.ProductName, item.Quantity, item.SumPrice);
            }

            content = content.Replace("{{orderDetails}}", orderDetailAsStringToSendMailTemplate);

            MailHelper.SendMail(orderCreated.Email, "Thông tin xác nhận đặt hàng từ KidSwim", content);

            return Json(new
            {
                IsSuccess = true,
            });
        }

        private string CreateOrderDetailTemplate(string productName, int quantity, decimal totalMoney)
        {
            var toReturn = $"<tr><td>{productName}</td><td>{quantity.ToString()}</td><td>{totalMoney.ToString()}</td></tr>";

            return toReturn;
        }
    }
}