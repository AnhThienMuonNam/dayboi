using System;
using System.Collections.Generic;

namespace Dayboi_Web.ViewModels
{
    public class PoolViewModel
    {
        public PoolViewModel()
        {
            Tags = new List<string>();
            OtherPools = new List<PoolViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string MetaKeyword { get; set; }

        public string Address { get; set; }

        public string Image { get; set; }

        public string Content { get; set; }

        public string PoolCategoryName { get; set; }

        public int PoolCategoryId { get; set; }

        public DateTime CreatedOn { get; set; }

        public List<string> Tags { get; set; }

        public int? OpeningHour { get; set; }
        public int? ClosedHour { get; set; }
        public decimal? Fare { get; set; }
        public string OpeningDay { get; set; }

        public List<PoolViewModel> OtherPools { get; set; }
    }
}