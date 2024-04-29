using FluentValidation;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Features.CategoryFeature.Commands.UpdateCategory;
using MindSwap.Application.Features.PostFeature.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.PostFeature.Commands.UpdatePost
{
    public class UpdatePostCommandValidator: AbstractValidator<UpdatePostCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPostRepository _postRepository;

        public UpdatePostCommandValidator(ICategoryRepository categoryRepository, IPostRepository postRepository)
        {
            this._categoryRepository = categoryRepository;
            this._postRepository = postRepository;
            Include(new BasePostValidator(_categoryRepository, _postRepository));

            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(PostMustExist)
                .WithMessage("{PropertyName} must be present");
                  
        }
        private async Task<bool> PostMustExist(int id, CancellationToken arg2)
        {
            var post = await _postRepository.GetByIdAsync(id);
            return post != null;
        }
    }
}
