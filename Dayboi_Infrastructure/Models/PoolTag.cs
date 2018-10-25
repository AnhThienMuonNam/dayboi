using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dayboi_Infrastructure.Models
{
    [Table("PoolTags")]
    public class PoolTag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(200)]
        public string Tag { get; set; }

        public int PoolId { get; set; }

        [ForeignKey("PoolId")]
        public Pool Pool { get; set; }
    }
}