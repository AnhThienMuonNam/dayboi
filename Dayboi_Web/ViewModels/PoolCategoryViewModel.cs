using System.Collections.Generic;

namespace Dayboi_Web.ViewModels
{
    public class PoolCategoryViewModel
    {
        public PoolCategoryViewModel()
        {
            //Pools = new List<PoolViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public string Alias { get; set; }
        public string Image { get; set; }

        public IEnumerable<PoolViewModel> Pools { get; set; }
    }
}