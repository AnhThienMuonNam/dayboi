using AutoMapper;

namespace Dayboi_Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModel_Mapping>();
                x.AddProfile<ViewModelToDomain_Mapping>();
            });
        }
    }
}