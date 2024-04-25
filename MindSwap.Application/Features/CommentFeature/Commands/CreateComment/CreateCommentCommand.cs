using MediatR;
using MindSwap.Application.Features.CommentFeature.Shared;
using MindSwap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CommentFeature.Commands.CreateComment
{
    public class CreateCommentCommand : BaseComment, IRequest
    {

    }
}
