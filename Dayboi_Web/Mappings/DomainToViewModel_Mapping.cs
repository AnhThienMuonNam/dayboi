using AutoMapper;
using Dayboi_Infrastructure.Models;
using Dayboi_Web.Areas.Admin.Models;
using Dayboi_Web.ViewModels;
using System.Collections.Generic;
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

            base.CreateMap<Course, CourseModel>()
               .ForMember(s => s.Tags, t => t.MapFrom(src => src.CourseTags != null ? src.CourseTags.Select(x => x.Tag) : null));

            base.CreateMap<Course, CourseViewModel>()
               .ForMember(s => s.Tags, t => t.MapFrom(src => src.CourseTags != null ? src.CourseTags.Select(x => x.Tag) : null));

            base.CreateMap<Skill, SkillViewModel>()
               .ForMember(s => s.Tags, t => t.MapFrom(src => src.SkillTags != null ? src.SkillTags.Select(x => x.Tag) : null));

            base.CreateMap<Skill, SkillModel>()
              .ForMember(s => s.Tags, t => t.MapFrom(src => src.SkillTags != null ? src.SkillTags.Select(x => x.Tag) : null));

            base.CreateMap<Pool, PoolModel>()
              .ForMember(s => s.Tags, t => t.MapFrom(src => src.PoolTags != null ? src.PoolTags.Select(x => x.Tag) : null))
              .ForMember(s => s.PoolCategoryName, t => t.MapFrom(src => src.PoolCategory != null ? src.PoolCategory.Name : string.Empty));

            base.CreateMap<Pool, PoolViewModel>()
             .ForMember(s => s.Tags, t => t.MapFrom(src => src.PoolTags != null ? src.PoolTags.Select(x => x.Tag) : null))
             .ForMember(s => s.PoolCategoryName, t => t.MapFrom(src => src.PoolCategory != null ? src.PoolCategory.Name : "Hồ bơi"));

            base.CreateMap<Order, OrderAdminModel>()
             .ForMember(s => s.FullAddress, t => t.MapFrom(src => src.Address + ", " + src.WardName + ", " + src.DistrictName + ", " + src.ProvinceName))
              .ForMember(s => s.PaymentMethodName, t => t.MapFrom(src => src.PaymentMethod != null ? src.PaymentMethod.Name : string.Empty))
              .ForMember(s => s.OrderStatusName, t => t.MapFrom(src => src.OrderStatus != null ? src.OrderStatus.Name : string.Empty));

            base.CreateMap<OrderDetail, OrderDetailAdminModel>()
              .ForMember(s => s.CategoryName, t => t.MapFrom(src => src.Product.Category != null && src.Product != null ? src.Product.Category.Name : string.Empty));

            base.CreateMap<PoolCategory, PoolCategoryViewModel>()
            .ForMember(s => s.Pools, t => t.MapFrom(src => src.Pools != null ? src.Pools.Where(x => !x.IsDeleted && x.IsActive) : new List<Pool>()));

            base.CreateMap<EnrollmentCourse, EnrollmentCourseModel>()
                     .ForMember(s => s.CourseName, t => t.MapFrom(src => src.Course != null ? src.Course.Name : string.Empty))
                     .ForMember(s => s.EnrollmentCourseStatusName, t => t.MapFrom(src => src.EnrollmentCourseStatus != null ? src.EnrollmentCourseStatus.Name : string.Empty));

            base.CreateMap<PoolCategory, PoolCategoryModel>();

            base.CreateMap<ApplicationUser, AccountModel>();
                //.ForMember(s => s.Role, t => t.MapFrom(src => src.Roles != null ? src.Roles.First().RoleId.ToString() : string.Empty));
        }
    }
}