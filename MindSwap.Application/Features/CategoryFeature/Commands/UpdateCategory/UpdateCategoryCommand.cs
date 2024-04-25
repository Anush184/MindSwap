using MediatR;
using MindSwap.Application.Features.CategoryFeature.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CategoryFeature.Commands.UpdateCategory
{
    public class UpdateCategoryCommand: BaseCategory, IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
