using System.Collections.Generic;

namespace Dayboi_Web.ViewModels
{
    public class HomeViewModel
    {
        public List<BlogViewModel> Blogs { get; set; }

        public List<CourseViewModel> Courses { get; set; }

        public List<PoolCategoryViewModel> PoolCategories { get; set; }
    }
}