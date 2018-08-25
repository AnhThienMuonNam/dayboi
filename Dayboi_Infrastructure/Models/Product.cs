using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayboi_Infrastructure.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Alias { get; set; }

        [StringLength(250)]
        public string MetaKeyword { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(1000)]
        public string Images { set; get; }

        public decimal? Price { set; get; }

        public bool IsPromotion { get; set; }

        [StringLength(250)]
        public string Tags { set; get; }


        //default columns
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public int? DisplayOrder { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("CreatedBy")]
        public ApplicationUser CreatedUser { get; set; }

        [ForeignKey("UpdatedBy")]
        public ApplicationUser UpdatedUser { get; set; }


        //reference tables
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

    }
}
