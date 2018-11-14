using System;
using System.Collections.Generic;

namespace Dayboi_Web.Areas.Admin.Models
{
    public class OrderAdminModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string FullAddress { get; set; }

        public string Note { get; set; }

        public decimal TotalPrice { set; get; }

        public int OrderStatusId { get; set; }

        public int PaymentMethodId { get; set; }

        public string OrderStatusName { get; set; }

        public string PaymentMethodName { get; set; }

        public DateTime CreatedOn { get; set; }

        public List<OrderDetailAdminModel> OrderDetails { get; set; }
    }

    public class OrderDetailAdminModel
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public decimal SumPrice { get; set; }

        public int Quantity { get; set; }

        public int ProductId { set; get; }

        public string CategoryName { set; get; }
    }
}