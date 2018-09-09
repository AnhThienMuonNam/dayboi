using System;
using System.Collections.Generic;

namespace Dayboi_Web.ViewModels
{
    public class CategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string MetaKeyword { get; set; }

        public string Description { get; set; }

        public string Image { set; get; }

        //default columns
        public int? DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public IEnumerable<ProductModel> Products { get; set; }
    }
}