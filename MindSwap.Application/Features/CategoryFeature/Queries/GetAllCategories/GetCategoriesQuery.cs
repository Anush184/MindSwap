using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CategoryFeature.Queries.GetAllCategories
{
   public record GetCategoriesQuery : IRequest<List<CategoryDto>>;
    
}
