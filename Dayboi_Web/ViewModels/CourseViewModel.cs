using System;
using System.Collections.Generic;

namespace Dayboi_Web.ViewModels
{
    public class CourseViewModel
    {
        public CourseViewModel()
        {
            Tags = new List<string>();
            OtherCourses = new List<CourseViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string MetaKeyword { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public List<string> Tags { get; set; }

        public List<CourseViewModel> OtherCourses { get; set; }
    }
}