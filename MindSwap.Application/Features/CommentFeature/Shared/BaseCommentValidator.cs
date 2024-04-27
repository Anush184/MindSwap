using FluentValidation;
using MindSwap.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CommentFeature.Shared
{
    public class BaseCommentValidator: AbstractValidator<BaseComment>
    {
        private readonly IPostRepository _postRepository;

        public BaseCommentValidator(IPostRepository postRepository)
        {
            _postRepository = postRepository;

            RuleFor(p => p.PostId)
               .GreaterThan(0)
               .MustAsync(PostMustExist)
               .WithMessage("{PropertyName} does not exist.");

            RuleFor(c => c.Content)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
        private async Task<bool> PostMustExist(int id, CancellationToken token)
        {
            var post = await _postRepository.GetByIdAsync(id);
            return post != null;
        }
    }
}
