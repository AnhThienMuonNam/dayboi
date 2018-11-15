using System;

namespace Dayboi_Web.Areas.Admin.Models
{
    public class EnrollmentCourseModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string CourseName { get; set; }

        public int CourseId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int EnrollmentCourseStatusId { set; get; }

        public string EnrollmentCourseStatusName { get; set; }

        public string Note { get; set; }
    }
}