using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CommentFeature.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest
    {
        public int Id { get; set; }
    }
}
