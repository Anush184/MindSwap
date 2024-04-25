using MediatR;
using MindSwap.Application.Features.CategoryFeature.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CategoryFeature.Commands.CreateCategory
{
    public class CreateCategoryCommand: BaseCategory, IRequest<int>
    {

    }
}
