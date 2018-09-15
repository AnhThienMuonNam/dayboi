using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dayboi_Infrastructure.Models
{
    [Table("Districts")]
    public class District
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Type { get; set; }

        [StringLength(100)]
        public string LatiLongTude { get; set; }

        public bool IsDeleted { get; set; }
        public int? DisplayOrder { get; set; }
        public bool IsPublished { get; set; }

        public int ProvinceId { get; set; }

        [ForeignKey("ProvinceId")]
        public Province Province { get; set; }

        public ICollection<Ward> Wards { get; set; }
    }
}