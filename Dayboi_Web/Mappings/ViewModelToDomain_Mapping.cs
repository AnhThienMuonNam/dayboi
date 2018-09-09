using AutoMapper;
using Dayboi_Infrastructure.Models;
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

        }
    }
}