using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.PostFeature.Commands.DeletePost
{
    public class DeletePostCommand : IRequest
    {
        public int Id { get; set; }
    }
}
