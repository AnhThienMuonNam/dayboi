using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dayboi_Infrastructure.Models
{
    [Table("Provinces")]
    public class Province
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(20)]
        public string ZipCode { get; set; }

        public int CountryId { get; set; }

        [StringLength(5)]
        public string CountryCode { get; set; }

        public int TelephoneCode { get; set; }
        public bool IsDeleted { get; set; }
        public int? DisplayOrder { get; set; }
        public bool IsPublished { get; set; }

        public ICollection<District> Districts { get; set; }
    }
}