using AutoMapper;
using Dayboi_Infrastructure.Models;
using Dayboi_Web.Areas.Admin.Models;
using Dayboi_Web.ViewModels;

namespace Dayboi_Web.Mappings
{
    public class ViewModelToDomain_Mapping : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMapping"; }
        }

        protected override void Configure()
        {
            base.CreateMap<CategoryModel, Category>();
            base.CreateMap<ProductModel, Product>();
            base.CreateMap<OrderModel, Order>();
            base.CreateMap<OrderDetailModel, OrderDetail>();
            base.CreateMap<CartModel, OrderDetail>();
            base.CreateMap<BlogModel, Blog>();
            base.CreateMap<CourseModel, Course>();
            base.CreateMap<PoolModel, Pool>();
            base.CreateMap<SkillModel, Skill>();
            base.CreateMap<EnrollmentCourseViewModel, EnrollmentCourse>();
        }
    }
}