using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dayboi_Infrastructure.Models
{
    [Table("Pools")]
    public class Pool
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Alias { get; set; }

        [StringLength(250)]
        public string MetaKeyword { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        public string Content { get; set; }

        public int? ViewCount { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        public int PoolCategoryId { get; set; }
        [ForeignKey("PoolCategoryId")]
        public PoolCategory PoolCategory { get; set; }

        //default columns
        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public int? DisplayOrder { get; set; }
        public bool IsActive { get; set; }

        public int? OpeningHour{ get; set; }
        public int? ClosedHour { get; set; }
        public string OpeningDay { get; set; }
        public decimal? Fare { get; set; }

        public ICollection<PoolTag> PoolTags { get; set; }
    }
}