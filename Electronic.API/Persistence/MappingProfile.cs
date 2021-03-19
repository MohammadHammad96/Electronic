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
            CreateMap<Category, CategoryResource>();

            // Resource to Domain
            CreateMap<CategoryResource, Category>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}
