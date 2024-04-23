using MediatR;
using MindSwap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CommentFeature.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<int>
    {
        public string Content { get; set; } = string.Empty;
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
