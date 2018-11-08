using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dayboi_Infrastructure.Models
{
    [Table("SkillTags")]
    public class SkillTag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(200)]
        public string Tag { get; set; }

        public int SkillId { get; set; }

        [ForeignKey("SkillId")]
        public Skill Skill { get; set; }
    }
}
