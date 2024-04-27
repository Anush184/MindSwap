using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MindSwap.Application.Contracts.Email;
using MindSwap.Application.Contracts.Logging;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Exceptions;
using MindSwap.Application.Features.PostFeature.Commands.CreatePost;
using MindSwap.Application.Moduls.Email;
using MindSwap.Domain;

namespace MindSwap.Application.Features.UserFeature.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IEmailSender _emailSender;
        private readonly IAppLogger<CreatePostCommandHandler> _appLogger;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository, 
            IEmailSender emailSender, 
            IAppLogger<CreatePostCommandHandler> appLogger)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _emailSender = emailSender;
            _appLogger = appLogger;
        }
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserCommandValidator( _userRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid User", validationResult);
            }

            var userToCreate = _mapper.Map<User>(request);
            await _userRepository.CreateAsync(userToCreate);
            try
            {
                var email = new EmailMessage
                {
                    To = userToCreate.Email,
                    Body = $"Your User by username {userToCreate.UserName} has been created successfully.",
                    Subject = "User Created"
                };
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
                _appLogger.LogWarning(ex.Message);
            }

            return Unit.Value;
        }
    }
}
