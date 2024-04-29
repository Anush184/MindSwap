using AutoMapper;
using MediatR;
using MindSwap.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CommentFeature.Queries.GetAllComments;

public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, List<CommentDto>>
{
    private readonly IMapper _mapper;
    private readonly ICommentRepository _commentRepository;

    public GetCommentsQueryHandler(IMapper mapper, ICommentRepository commentRepository)
    {
        this._mapper = mapper;
        this._commentRepository = commentRepository;
    }
    public async Task<List<CommentDto>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
    {
        // Check if it is logged in user 
        var comments = await _commentRepository.GetCommentsWithDetails();
        var data = _mapper.Map<List<CommentDto>>(comments);
        //Fill comments with user information
        return data;
    }
}
