using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CategoryFeature.Commands.DeleteCategory
{
    public class DeleteCategoryCommand: IRequest<Unit>
    {
        public int CategoryId { get; set; }
    }
}
