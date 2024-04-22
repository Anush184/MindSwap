using FluentValidation;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Features.CategoryFeature.Commands.UpdateCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.PostFeature.Commands.UpdatePost
{
    public class UpdatePostCommandValidator: AbstractValidator<UpdatePostCommand>
    {
        private readonly IPostRepository _postRepository;

        public UpdatePostCommandValidator(IPostRepository postRepository)
        {
            this._postRepository = postRepository;
            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(PostMustExist);

            RuleFor(p => p.Content)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull();
                  
            RuleFor(p => p)
                .MustAsync(PostContentUnique)
                .WithMessage("Post already exists");
        }

        private async Task<bool> PostMustExist(int id, CancellationToken arg2)
        {
            var category = await _postRepository.GetByIdAsync(id);
            return category != null;
        }

        private Task<bool> PostContentUnique(UpdatePostCommand command, CancellationToken token)
        {
            return _postRepository.IsPostUnique(command.Content);
        }
    }
}
