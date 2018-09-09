using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dayboi_Web.ViewModels
{
    public class OrderModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public decimal TotalPrice { set; get; }
    }
}