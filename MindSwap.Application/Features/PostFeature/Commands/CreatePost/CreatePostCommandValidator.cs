using FluentValidation;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Features.CategoryFeature.Commands.CreateCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.PostFeature.Commands.CreatePost
{
    public class CreatePostCommandValidator:
         AbstractValidator<CreatePostCommand>
    {
        private readonly IPostRepository _postRepository;

        public CreatePostCommandValidator(IPostRepository postRepository)
        {
            this._postRepository = postRepository;

            RuleFor(p => p.Content)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p)
                .MustAsync(PostContentUnique)
                .WithMessage("Post already exists");
            RuleFor(p => p.CategoryId)
                 .NotNull();

        }

        private Task<bool> PostContentUnique(CreatePostCommand command, CancellationToken arg2)
        {
            return _postRepository.IsPostUnique(command.Content);
        }

    }
}
