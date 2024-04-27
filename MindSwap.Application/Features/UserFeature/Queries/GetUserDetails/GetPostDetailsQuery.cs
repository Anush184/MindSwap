using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.PostFeature.Queries.GetPostDetails
{
    public class GetUserDetailsQuery: IRequest<UserDetailsDto>
    {
        public int Id { get; set; }
    }
}
