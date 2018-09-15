using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dayboi_Infrastructure.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(50)]
        public string ProvinceName { get; set; }

        [StringLength(50)]
        public string DistrictName { get; set; }

        [StringLength(50)]
        public string WardName { get; set; }

        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? WardId { get; set; }
        public decimal? ShippingFee { set; get; }

        [StringLength(200)]
        public string Note { get; set; }

        public decimal TotalPrice { set; get; }
        public int OrderStatusId { get; set; }

        [ForeignKey("OrderStatusId")]
        public OrderStatus OrderStatus { get; set; }

        public int? PaymentMethodId { get; set; }

        [ForeignKey("PaymentMethodId")]
        public PaymentMethod PaymentMethod { get; set; }

        //default columns
        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("CreatedBy")]
        public ApplicationUser CreatedUser { get; set; }

        [ForeignKey("UpdatedBy")]
        public ApplicationUser UpdatedUser { get; set; }

        //references
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}