using System.Collections.Generic;

namespace Dayboi_Web.ViewModels
{
    public class OrderModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public string ProvinceName { set; get; }
        public string DistrictName { set; get; }
        public string WardName { set; get; }
        public int? ProvinceId { set; get; }
        public int? DistrictId { set; get; }
        public int? WardId { set; get; }
        public decimal TotalPrice { set; get; }
        public decimal? ShippingFee { set; get; }
        public int? PaymentMethodId { set; get; }
        public string PaymentMethodName { set; get; }

        public string Note { set; get; }


    }

    public class CheckoutModel
    {
        public OrderModel Order { set; get; }
        public IEnumerable<CartModel> Carts { set; get; }
    }
}