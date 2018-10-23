using System.Collections.Generic;

namespace Dayboi_Web.ViewModels
{
    public class HeaderViewModel
    {
        public IEnumerable<CategoryModel> Categories { get; set; }
        public List<CourseViewModel> Courses { get; set; }
    }
}