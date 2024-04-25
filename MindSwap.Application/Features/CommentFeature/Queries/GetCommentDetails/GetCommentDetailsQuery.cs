using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CommentFeature.Queries.GetCommentDetails
{
    public class GetCommentDetailsQuery: IRequest<CommentDetailsDto>
    {
        public int Id { get; set; }
    }
}
