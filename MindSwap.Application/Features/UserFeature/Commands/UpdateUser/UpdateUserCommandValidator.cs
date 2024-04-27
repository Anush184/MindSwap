using FluentValidation;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Features.CategoryFeature.Commands.UpdateCategory;
using MindSwap.Application.Features.PostFeature.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.PostFeature.Commands.UpdatePost
{
    public class UpdateUserCommandValidator: AbstractValidator<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandValidator(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
            Include(new BaseUserValidator(_userRepository));

            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(UserMustExist)
                .WithMessage("{PropertyName} must be present");
                  
        }
        private async Task<bool> UserMustExist(int id, CancellationToken arg2)
        {
            var post = await _userRepository.GetByIdAsync(id);
            return post != null;
        }
    }
}
