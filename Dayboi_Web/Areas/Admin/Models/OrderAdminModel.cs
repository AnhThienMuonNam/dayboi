using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dayboi_Web.Areas.Admin.Models
{
    public class OrderAdminModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string FullAddress { get; set; }

        //public string ProvinceName { get; set; }

        //public string DistrictName { get; set; }

        //public string WardName { get; set; }

        public string Note { get; set; }

        public decimal TotalPrice { set; get; }
        public string OrderStatusName { get; set; }

        public string PaymentMethodName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}