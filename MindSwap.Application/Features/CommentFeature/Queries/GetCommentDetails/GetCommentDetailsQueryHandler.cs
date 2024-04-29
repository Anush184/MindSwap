using AutoMapper;
using MediatR;
using MindSwap.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CommentFeature.Queries.GetCommentDetails
{
    public class GetCommentDetailsQueryHandler : IRequestHandler<GetCommentDetailsQuery, CommentDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public GetCommentDetailsQueryHandler(IMapper mapper, ICommentRepository commentRepository)
        {
            this._mapper = mapper;
            this._commentRepository = commentRepository;
        }
        public async Task<CommentDetailsDto> Handle(GetCommentDetailsQuery request, CancellationToken cancellationToken)
        {
            var comment = _mapper.Map<CommentDetailsDto>(await
                _commentRepository.GetCommentWithDetails(request.Id));
            // Add user details if needed
            return comment;
        }
    }
}
