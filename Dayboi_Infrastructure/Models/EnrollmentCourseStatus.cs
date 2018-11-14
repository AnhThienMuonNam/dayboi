using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dayboi_Infrastructure.Models
{
    [Table("EnrollmentCourseStatues")]
    public class EnrollmentCourseStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
        public int? DisplayOrder { get; set; }
        public bool IsActive { get; set; }

        public ICollection<EnrollmentCourse> EnrollmentCourses { get; set; }
    }
}
