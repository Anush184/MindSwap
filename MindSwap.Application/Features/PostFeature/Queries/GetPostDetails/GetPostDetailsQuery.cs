using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.PostFeature.Queries.GetPostDetails
{
    public class GetPostDetailsQuery: IRequest<PostDetailsDto>
    {
        public int Id { get; set; }
    }
}
