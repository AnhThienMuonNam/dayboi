using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dayboi_Web.ViewModels
{
    public class CartModel
    {
        public int ProductId { set; get; }
        public string Alias { set; get; }
        public string ProductName { set; get; }
        public string Image { set; get; }
        public decimal Price { set; get; }
        public decimal SumPrice { set; get; }
        public int Quantity { set; get; }
    }
}