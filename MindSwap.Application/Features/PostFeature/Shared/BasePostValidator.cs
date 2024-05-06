using FluentValidation;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Features.PostFeature.Commands.UpdatePost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.PostFeature.Shared
{
    public class BasePostValidator: AbstractValidator<BasePost>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPostRepository _postRepository;

        public BasePostValidator(ICategoryRepository categoryRepository, IPostRepository postRepository)
        {
            _categoryRepository = categoryRepository;
            _postRepository = postRepository;
            RuleFor(p => p.CategoryId)
               .GreaterThan(0)
               .MustAsync(CategoryMustExist)
               .WithMessage("{PropertyName} does not exist.");

            RuleFor(p => p.Content)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();

            RuleFor(p => p.Title)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();

            RuleFor(p => p)
                .MustAsync(PostContentUnique)
                .WithMessage("Post already exists");
        }
        private async Task<bool> CategoryMustExist(int id, CancellationToken token)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return category != null;
        }
        private Task<bool> PostContentUnique(BasePost command, CancellationToken token)
        {
            return _postRepository.IsPostUnique(command.Content);
        }
    }
}
