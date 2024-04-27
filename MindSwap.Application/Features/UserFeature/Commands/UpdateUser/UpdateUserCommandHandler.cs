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
using MindSwap.Application.Features.PostFeature.Commands.UpdatePost;
using MindSwap.Application.Moduls.Email;
using MindSwap.Domain;

namespace MindSwap.Application.Features.UserFeature.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IEmailSender _emailSender;
        private readonly IAppLogger<UpdateUserCommandHandler> _appLogger;

        public UpdateUserCommandHandler(IMapper mapper, 
            IUserRepository userRepository, IEmailSender emailSender,
            IAppLogger<UpdateUserCommandHandler> appLogger)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _emailSender = emailSender;
            _appLogger = appLogger;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if(user is null)
            {
                throw new NotFoundException(nameof(Post), request.Id);
            }
            var validator = new UpdateUserCommandValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid User", validationResult);
            }
            _mapper.Map(request,user);
            await _userRepository.UpdateAsync(user);

            //Send confirmation mail
            try
            {
                var email = new EmailMessage
                {
                    To = user.Email,/* Get email for User record */
                    Body = $"Your User for {user.UserName} has been updated successfully.",
                    Subject = "Post Updated"
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
