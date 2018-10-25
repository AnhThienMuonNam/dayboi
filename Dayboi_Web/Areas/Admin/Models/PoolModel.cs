using System.Collections.Generic;

namespace Dayboi_Web.Areas.Admin.Models
{
    public class PoolModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string MetaKeyword { get; set; }

        public string Address { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        //default columns
        public int? DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public List<string> Tags { get; set; }

        public int PoolCategoryId { get; set; }
    }
}