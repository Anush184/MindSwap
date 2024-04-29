using AutoMapper;
using MediatR;
using MindSwap.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.PostFeature.Queries.GetAllPosts
{
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, List<PostDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostsQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            this._postRepository = postRepository;
            this._mapper = mapper;
        }
        public async Task<List<PostDto>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            //To Add Later
            // Get records for specific user
            // Get user posts
            // Get only voted posts

            var result = await _postRepository.GetPostsWithDetails();
            var posts = _mapper.Map<List<PostDto>>(result);
            return posts;  

        }
    }
}
