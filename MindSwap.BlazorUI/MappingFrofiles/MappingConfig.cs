using AutoMapper;
using MindSwap.BlazorUI.Models.Categories;
using MindSwap.BlazorUI.Services.Base;

namespace MindSwap.BlazorUI.MappingFrofiles
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<CategoryDto, CategoryVM>().ReverseMap();
            CreateMap<CreateCategoryCommand, CategoryVM>().ReverseMap();
            CreateMap<UpdateCategoryCommand, CategoryVM>().ReverseMap();
        }
    }
}
