using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayboi_Infrastructure.Models
{
    [Table("BlogTags")]
    public class BlogTag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(200)]
        public string Tag { get; set; }

        public int BlogId { get; set; }

        [ForeignKey("BlogId")]
        public Blog Blog { get; set; }
    }
}
