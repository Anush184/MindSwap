using AutoMapper;
using MediatR;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Exceptions;
using MindSwap.Application.Features.CategoryFeature.Commands.CreateCategory;
using MindSwap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CommentFeature.Commands.CreateComment
{
    public class CreateCommentCommandHandler: IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;

        public CreateCommentCommandHandler(IMapper mapper, ICommentRepository commentRepository,
            IPostRepository postRepository)
        {
            this._mapper = mapper;
            this._commentRepository = commentRepository;
            this._postRepository = postRepository;
        }
        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCommentCommandValidator(_postRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Comment", validationResult);
            }

            var commentToCreate = _mapper.Map<Comment>(request);
            await _commentRepository.CreateAsync(commentToCreate);
           
            return Unit.Value;
        }
    }
}
