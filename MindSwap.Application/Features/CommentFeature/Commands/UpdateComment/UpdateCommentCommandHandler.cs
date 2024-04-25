using AutoMapper;
using MediatR;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Exceptions;
using MindSwap.Application.Features.PostFeature.Commands.UpdatePost;
using MindSwap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CommentFeature.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;

        public UpdateCommentCommandHandler(IMapper mapper, IPostRepository postRepository, ICommentRepository commentRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }
        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCommentCommandValidator(_commentRepository, _postRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Comment", validationResult);
            }
            var comment = await _commentRepository.GetByIdAsync(request.Id);
            if (comment is null)
            {
                throw new NotFoundException(nameof(Comment), request.Id);
            }
            _mapper.Map(request, comment);
            await _commentRepository.UpdateAsync(comment);
            return Unit.Value;
        }
    }
}
