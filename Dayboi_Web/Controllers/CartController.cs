using Dayboi_Infrastructure.Repositories;
using Dayboi_Service;
using Dayboi_Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Dayboi_Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IProvinceRepository _provinceRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly IWardRepository _wardRepository;
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public CartController(IProvinceRepository provinceRepository,
                                IDistrictRepository districtRepository,
                                IWardRepository wardRepository,
                                IPaymentMethodRepository paymentMethodRepository)
        {
            _provinceRepository = provinceRepository;
            _districtRepository = districtRepository;
            _wardRepository = wardRepository;
            _paymentMethodRepository = paymentMethodRepository;
        }

        // GET: Cart
        public ActionResult Index()
        {
            var cart = (List<CartModel>)Session["MyCart"];
            if (cart == null)
            {
                cart = new List<CartModel>();
            }
            var provinces = _provinceRepository.GetMany(x => !x.IsDeleted)
                                                        .OrderBy(x => x.DisplayOrder)
                                                        .ToList();

            var paymentMethods = _paymentMethodRepository.GetMany(x => !x.IsDeleted && x.IsActive)
                                                            .OrderBy(x => x.DisplayOrder)
                                                            .ToList();

            ViewBag.Provinces = provinces;
            ViewBag.PaymentMethods = paymentMethods;

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
                newItem.Image = product.Images.Split(',').ToList<string>().FirstOrDefault();
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

        [HttpPost]
        public JsonResult PlusorMinusItem(int productId, bool isPlus)
        {
            var carts = (List<CartModel>)Session["MyCart"];

            var existingItem = carts.Where(x => x.ProductId == productId).FirstOrDefault();

            if (existingItem != null)
            {
                if (isPlus)
                {
                    existingItem.Quantity++;
                }
                else
                {
                    if (existingItem.Quantity > 1)
                    {
                        existingItem.Quantity--;
                    }
                    else
                    {
                        return Json(new
                        {
                            IsSuccess = false,
                        });
                    }
                }
                existingItem.SumPrice = existingItem.Quantity * existingItem.Price;
            }

            Session["MyCart"] = carts;

            return Json(new
            {
                IsSuccess = true,
            });
        }

        [HttpPost]
        public JsonResult RemoveProduct(int productId)
        {
            var carts = (List<CartModel>)Session["MyCart"];

            if (productId > 0)
            {
                var existingItem = carts.Where(x => x.ProductId == productId).FirstOrDefault();
                if (existingItem != null)
                {
                    carts.Remove(existingItem);
                }
            }

            Session["MyCart"] = carts;

            return Json(new
            {
                IsSuccess = true,
                CartLength = carts.Count()
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
        public JsonResult GetDistrictsByProvinceId(int provinceId)
        {
            var districts = _districtRepository.GetMany(x => !x.IsDeleted
                                                        && x.ProvinceId == provinceId)
                                                        .OrderBy(x => x.Name)
                                                        .ToList();
            return Json(new
            {
                IsSuccess = true,
                Districts = districts,
            });
        }

        [HttpPost]
        public JsonResult GetWardsByDistrictId(int districtId)
        {
            var wards = _wardRepository.GetMany(x => !x.IsDeleted
                                                        && x.DistrictId == districtId)
                                                        .OrderBy(x => x.Name)
                                                        .ToList();
            return Json(new
            {
                IsSuccess = true,
                Wards = wards,
            });
        }

<<<<<<< HEAD
            //send mail
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Template/order_detail.html"));
            content = content.Replace("{{orderId}}", orderCreated.Id.ToString());
            content = content.Replace("{{customerName}}", orderCreated.Name);
            content = content.Replace("{{customerAddress}}", orderCreated.Address);
            content = content.Replace("{{customerPhone}}", orderCreated.Phone);

            //content = content.Replace("{{createdDate}}", orderCreated.CreatedOn.ToString());
            //content = content.Replace("{{totalMoney}}", orderCreated.TotalPrice.ToString());
=======
        [HttpPost]
        public JsonResult AddCartOrderToSession(OrderModel orderModel)
        {
            TempData["MyCart_Order"] = orderModel;
>>>>>>> 364b8195e95d0bc896e17a280a4987df381043dd

            //Session["MyCart_Order"] = orderModel;

            return Json(new
            {
                IsSuccess = true,
            });
        }
    }
}