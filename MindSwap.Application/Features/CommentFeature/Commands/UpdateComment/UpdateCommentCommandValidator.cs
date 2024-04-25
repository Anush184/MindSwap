using FluentValidation;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Features.CategoryFeature.Commands.UpdateCategory;
using MindSwap.Application.Features.CommentFeature.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CommentFeature.Commands.UpdateComment
{
    public class UpdateCommentCommandValidator: AbstractValidator<UpdateCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;

        public UpdateCommentCommandValidator(ICommentRepository commentRepository, IPostRepository postRepository)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            Include(new BaseCommentValidator(_postRepository));

            RuleFor(c => c.Id)
                .NotNull()
                .MustAsync(CommentMustExist)
                .WithMessage("{PropertyName} must be present");
        }
        private async Task<bool> CommentMustExist(int id, CancellationToken arg2)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            return comment != null;
        }
       
    }
}
