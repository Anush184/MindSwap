using FluentValidation;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Features.CategoryFeature.Commands.CreateCategory;
using MindSwap.Application.Features.CommentFeature.Shared;
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
        private readonly IPostRepository _postRepository;

        public CreateCommentCommandValidator(IPostRepository postRepository)
        {
            _postRepository = postRepository;
            Include(new BaseCommentValidator(_postRepository));
        }
    }
}
