using MediatR;
using MindSwap.Application.Features.CommentFeature.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CommentFeature.Commands.UpdateComment
{
    public class UpdateCommentCommand: BaseComment, IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
