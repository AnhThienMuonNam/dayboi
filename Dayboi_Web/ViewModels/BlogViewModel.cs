using System;

namespace Dayboi_Web.ViewModels
{
    public class BlogViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Alias { get; set; }

        public string MetaKeyword { get; set; }

        public string SortDescription { get; set; }

        public string Image { get; set; }
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}