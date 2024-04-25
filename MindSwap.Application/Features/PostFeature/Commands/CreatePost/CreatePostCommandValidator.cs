using FluentValidation;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Features.CategoryFeature.Commands.CreateCategory;
using MindSwap.Application.Features.PostFeature.Commands.UpdatePost;
using MindSwap.Application.Features.PostFeature.Shared;
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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPostRepository _postRepository;

        public CreatePostCommandValidator(ICategoryRepository categoryRepository, IPostRepository postRepository)
        {
            _categoryRepository = categoryRepository;
            _postRepository = postRepository;
            Include(new BasePostValidator(_categoryRepository, _postRepository));
        }
    }
}
