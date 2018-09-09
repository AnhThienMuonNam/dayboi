using System.Collections.Generic;

namespace Dayboi_Web.ViewModels
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string MetaKeyword { get; set; }

        public string Description { get; set; }

        public string Images { set; get; }

        public decimal? Price { set; get; }

        public bool IsPromotion { get; set; }

        public string Tags { set; get; }

        public int? DisplayOrder { get; set; }
        public bool IsActive { get; set; }

        //reference tables
        public int? CategoryId { get; set; }

        public string CategoryName { get; set; }

        public List<string> ImageList { get; set; }

    }
}