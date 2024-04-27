using AutoMapper;
using MediatR;
using MindSwap.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.PostFeature.Queries.GetPostDetails
{
    public class GetPostDetailsQueryHandler : IRequestHandler<GetPostDetailsQuery, PostDetailsDto>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostDetailsQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            this._postRepository = postRepository;
            this._mapper = mapper;
        }
        public async Task<PostDetailsDto> Handle(GetPostDetailsQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetPostWithDetails(request.Id);
            return _mapper.Map<PostDetailsDto>(post);
        }
    }
}
