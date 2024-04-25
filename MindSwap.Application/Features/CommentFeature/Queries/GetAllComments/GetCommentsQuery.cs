using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CommentFeature.Queries.GetAllComments
{
    public class GetCommentsQuery: IRequest<List<CommentDto>>
    {
    }
}
