using AutoMapper;
using Electronic.API.Controllers.Resources;
using Electronic.API.Core.Models;

namespace Electronic.API.Persistence
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Category, KeyValuePairResource>();
            CreateMap<SubCategory, KeyValuePairResource>();

            // Resource to Domain
            CreateMap<KeyValuePairResource, Category>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<KeyValuePairResource, SubCategory>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}
