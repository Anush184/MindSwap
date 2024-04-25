using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CommentFeature.Commands.ChangeCommentApproval
{
    public class ChangeCommentApprovalCommand: IRequest<Unit>
    {
        public int Id { get; set; }
        public bool Approved { get; set; }
    }
}
