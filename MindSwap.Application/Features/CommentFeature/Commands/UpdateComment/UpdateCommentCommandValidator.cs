using FluentValidation;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Features.CategoryFeature.Commands.UpdateCategory;
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

        public UpdateCommentCommandValidator(ICommentRepository commentRepository)
        {
            this._commentRepository = commentRepository;
            RuleFor(c => c.Id)
                .NotNull()
                .MustAsync(CommentMustExist);

            RuleFor(c => c.Content)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull();
                        
        }

        private async Task<bool> CommentMustExist(int id, CancellationToken arg2)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            return comment != null;
        }
       
    }
}
