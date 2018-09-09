using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dayboi_Web.ViewModels
{
    public class HeaderModel
    {
        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}