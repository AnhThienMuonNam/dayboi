using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dayboi_Infrastructure.Models
{
    [Table("Wards")]
    public class Ward
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

        public int DistrictId { get; set; }

        [ForeignKey("DistrictId")]
        public District District { get; set; }
    }
}