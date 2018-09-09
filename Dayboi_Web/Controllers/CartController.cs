using AutoMapper;
using Dayboi_Infrastructure.Models;
using Dayboi_Service;
using Dayboi_Web.Helper;
using Dayboi_Web.ViewModels;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace Dayboi_Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IOrderService _orderService;

        public CartController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: Cart
        public ActionResult Index()
        {
            var cart = (List<CartModel>)Session["MyCart"];
            if (cart == null)
            {
                cart = new List<CartModel>();
            }
            return View(cart);
        }

        [HttpPost]
        public JsonResult AddToCart(ProductModel product)
        {
            var cart = (List<CartModel>)Session["MyCart"];

            if (cart == null)
            {
                cart = new List<CartModel>();
            }
            var existingItem = cart.Where(x => x.ProductId == product.Id).FirstOrDefault();

            if (existingItem != null)
            {
                existingItem.Quantity++;
                existingItem.SumPrice = existingItem.Quantity * existingItem.Price;
            }
            else
            {
                CartModel newItem = new CartModel();
                newItem.ProductId = product.Id;
                newItem.ProductName = product.Name;
                newItem.Alias = product.Alias;
                newItem.Image = product.Images;
                newItem.Quantity = 1;
                newItem.Price = product.Price.Value;
                newItem.SumPrice = product.Price.Value;
                cart.Add(newItem);
            }

            Session["MyCart"] = cart;

            return Json(new
            {
                IsSuccess = true,
                CartLength = cart.Count()
            });
        }

        [HttpGet]
        public JsonResult GetCartLength()
        {
            var cart = (List<CartModel>)Session["MyCart"];
            if (cart == null)
            {
                cart = new List<CartModel>();
            }
            var toReturn = cart.Count();
            return Json(new
            {
                IsSuccess = true,
                CartLength = toReturn
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateOrder(OrderModel orderModel)
        {
            var order = Mapper.Map<OrderModel, Order>(orderModel);

            var cart = (List<CartModel>)Session["MyCart"];
            if (cart == null)
            {
                cart = new List<CartModel>();
            }

            var orderDetails = Mapper.Map<IEnumerable<CartModel>, IEnumerable<OrderDetail>>(cart);
            order.TotalPrice = orderDetails.Select(x => x.SumPrice).Sum();
            order.OrderDetails = orderDetails.ToList();

            var orderCreated = _orderService.Add(order);

            //send mail
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Template/order_info.html"));
            content = content.Replace("{{orderId}}", orderCreated.Id.ToString());
            content = content.Replace("{{customerName}}", orderCreated.Name);
            content = content.Replace("{{createdDate}}", orderCreated.CreatedOn.ToString());
            content = content.Replace("{{totalMoney}}", orderCreated.TotalPrice.ToString());

            MailHelper.SendMail(orderCreated.Email, "Đặt hàng thành công", content);

            return Json(new
            {
                IsSuccess = true,
            }, JsonRequestBehavior.AllowGet);
        }
    }
}