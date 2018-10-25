using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dayboi_Infrastructure.Models
{
    [Table("PoolCategories")]
    public class PoolCategory
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

        [StringLength(500)]
        public string Image { set; get; }

        //default columns
        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public int? DisplayOrder { get; set; }
        public bool IsActive { get; set; }

        //references
        public ICollection<Pool> Pools { get; set; }
    }
}