using AutoMapper;
using MindSwap.Application.Features.CategoryFeature.Queries.GetAllCategories;
using MindSwap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}
