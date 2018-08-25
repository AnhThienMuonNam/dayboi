using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dayboi_Infrastructure.Models
{
    [Table("ApplicationUserGroups")]
    public class ApplicationUserGroup
    {
        [StringLength(128)]
        [Key]
        [Column(Order = 1)]
        public string UserId { set; get; }

        [Key]
        [Column(Order = 2)]
        public int GroupId { set; get; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { set; get; }

        [ForeignKey("GroupId")]
        public ApplicationGroup ApplicationGroup { set; get; }
    }
}