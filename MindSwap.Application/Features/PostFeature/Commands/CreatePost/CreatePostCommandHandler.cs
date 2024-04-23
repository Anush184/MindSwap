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

namespace MindSwap.Application.Features.PostFeature.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public CreatePostCommandHandler(IMapper mapper, IPostRepository postRepository)
        {
            this._mapper = mapper;
            this._postRepository = postRepository;
        }
        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePostCommandValidator(_postRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Post", validationResult);
            }

            var postToCreate = _mapper.Map<Post>(request);
            await _postRepository.CreateAsync(postToCreate);

            return postToCreate.Id;
        }
    }
}
