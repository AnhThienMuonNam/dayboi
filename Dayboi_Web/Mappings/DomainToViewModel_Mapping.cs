using AutoMapper;
using Dayboi_Infrastructure.Models;
using Dayboi_Web.Areas.Admin.Models;
using Dayboi_Web.ViewModels;
using System.Linq;

namespace Dayboi_Web.Mappings
{
    public class DomainToViewModel_Mapping : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMapping"; }
        }

        protected override void Configure()
        {
            base.CreateMap<Category, CategoryModel>()
                .ForMember(s => s.Products, t => t.MapFrom(src => src.Products != null ? src.Products.Where(x => !x.IsDeleted && x.IsActive).ToList() : null));

            base.CreateMap<Product, ProductModel>()
                .ForMember(s => s.CategoryName, t => t.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty))
                .ForMember(s => s.ImageList, t => t.MapFrom(src => string.IsNullOrEmpty(src.Images) ? null : src.Images.Split(',')))
                .ForMember(s => s.Tags, t => t.MapFrom(src => src.ProductTags != null ? src.ProductTags.Select(x => x.Tag) : null));

            base.CreateMap<Blog, BlogViewModel>();
            base.CreateMap<Blog, BlogModel>()
                .ForMember(s => s.Tags, t => t.MapFrom(src => src.BlogTags != null ? src.BlogTags.Select(x => x.Tag) : null));
        }
    }
}