using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CommentFeature.Commands.CancelComment
{
    public class CancelCommentCommand: IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
