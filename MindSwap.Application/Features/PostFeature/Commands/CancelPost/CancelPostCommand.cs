using MediatR;
using MindSwap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.PostFeature.Commands.CancelPost
{
    public class CancelPostCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
