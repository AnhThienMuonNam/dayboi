using System;

namespace Dayboi_Web.ViewModels
{
    public class EnrollmentCourseViewModel
    {
        public string FullName { get; set; }

        public string Phone { set; get; }

        public DateTime? StartDate { set; get; }

        public string Note { get; set; }

        public int CourseId { get; set; }

        public string UserId { get; set; }
    }
}