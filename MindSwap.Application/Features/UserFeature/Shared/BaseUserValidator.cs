using FluentValidation;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Features.PostFeature.Commands.UpdatePost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MindSwap.Application.Features.UserFeature.Shared;

namespace MindSwap.Application.Features.PostFeature.Shared
{
    public class BaseUserValidator: AbstractValidator<BaseUser>
    {
        private readonly IUserRepository _userRepository;

        public BaseUserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        
            RuleFor(p => p.UserName)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();
            RuleFor(p => p.Password)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();
            RuleFor(p => p.Password.Length)
                .GreaterThan(8).WithMessage("Password Must have more than 8 latters")
               .NotNull();
            RuleFor(p => p.Email)
                .Must(EmailValidation).WithMessage("Please enter a correct Email")
                .NotNull();

        }

        private bool EmailValidation(string emailAddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailAddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
