using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.PostFeature.Commands.UpdatePost
{
    public class UpdatePostCommand: IRequest<Unit>
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
