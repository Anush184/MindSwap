using MediatR;
using MindSwap.Application.Features.PostFeature.Shared;
using MindSwap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.PostFeature.Commands.CreatePost
{
    public class CreatePostCommand: BasePost, IRequest<Unit>
    {
  
    }
}
