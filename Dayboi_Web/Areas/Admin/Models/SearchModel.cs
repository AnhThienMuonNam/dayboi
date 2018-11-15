namespace Dayboi_Web.Areas.Admin.Models
{
    public class SearchModel
    {
        public int? Id { get; set; }
        public int? CategoryId { get; set; }
        public string KeyWord { get; set; }
        public bool IsActive { get; set; }
    }
}