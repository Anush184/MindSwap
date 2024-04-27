using FluentValidation;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Features.PostFeature.Shared;

namespace MindSwap.Application.Features.UserFeature.Commands.CreateUser
{
    public class CreateUserCommandValidator:
         AbstractValidator<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandValidator( IUserRepository userRepository)
        {
            _userRepository = userRepository;
            Include(new BaseUserValidator( _userRepository));
        }
    }
}
