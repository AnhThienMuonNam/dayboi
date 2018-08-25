using AutoMapper;
using Dayboi_Infrastructure.Models;
using Dayboi_Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dayboi_Web.Mappings
{
    public class ViewModelToDomain_Mapping: Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMapping"; }
        }
        protected override void Configure()
        {
            base.CreateMap<CategoryModel, Category>();
        }
    }
}