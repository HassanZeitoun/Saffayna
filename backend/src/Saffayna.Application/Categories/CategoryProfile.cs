using AutoMapper;
using Saffayna.Domain.Entities;

namespace Saffayna.Application.Categories;

// All category mappings in one place. AddAutoMapper finds this class by scanning the assembly.
public sealed class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        // Read: entity -> response. Names match (Id, Name, ParentId), so no extra setup.
        CreateMap<Category, CategoryDto>();

        // Write: request -> entity.
        // We ignore members the client must not set. Ignoring them explicitly shows our intent,
        // and it lets the startup validation pass.
        CreateMap<CreateCategoryRequest, Category>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())      // the service generates the Guid
            .ForMember(dest => dest.Parent, opt => opt.Ignore()); // navigation; EF uses ParentId

        CreateMap<UpdateCategoryRequest, Category>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())      // never change an existing Id
            .ForMember(dest => dest.Parent, opt => opt.Ignore());
    }
}