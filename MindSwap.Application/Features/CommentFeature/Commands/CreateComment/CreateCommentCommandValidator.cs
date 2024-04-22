using FluentValidation;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Features.CategoryFeature.Commands.CreateCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CommentFeature.Commands.CreateComment
{
    public class CreateCommentCommandValidator:
         AbstractValidator<CreateCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;

        public CreateCommentCommandValidator(ICommentRepository commentRepository)
        {
            this._commentRepository = commentRepository;

            RuleFor(c => c.Content)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            RuleFor(c => c.Post)
                .NotNull();

        }

    }
}
