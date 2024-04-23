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
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CommentFeature.Commands.CreateComment
{
    public class CreateCommentCommandHandler: IRequestHandler<CreateCommentCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public CreateCommentCommandHandler(IMapper mapper, ICommentRepository commentRepository)
        {
            this._mapper = mapper;
            this._commentRepository = commentRepository;
        }
        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCommentCommandValidator(_commentRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Comment", validationResult);
            }

            var commentToCreate = _mapper.Map<Comment>(request);
            await _commentRepository.CreateAsync(commentToCreate);
           
            return commentToCreate.Id;
        }
    }
}
