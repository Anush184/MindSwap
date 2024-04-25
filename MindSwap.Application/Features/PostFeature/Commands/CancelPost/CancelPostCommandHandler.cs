using MediatR;
using MindSwap.Application.Contracts.Email;
using MindSwap.Application.Contracts.Logging;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Exceptions;
using MindSwap.Application.Moduls.Email;
using MindSwap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.PostFeature.Commands.CancelPost
{
    public class CancelPostCommandHandler : IRequestHandler<CancelPostCommand>
    {
        private readonly IPostRepository _postRepository;
        private readonly IEmailSender _emailSender;
        private readonly IAppLogger<CancelPostCommandHandler> _appLogger;

        public CancelPostCommandHandler(IPostRepository postRepository, IEmailSender emailSender,
            IAppLogger<CancelPostCommandHandler> appLogger)
        {
            _postRepository = postRepository;
            _emailSender = emailSender;
            _appLogger = appLogger;
        }
        public async Task<Unit> Handle(CancelPostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.Id);
            if (post == null)
            {
                throw new NotFoundException(nameof(Post), request.Id);
            }
            post.Cancelled = true;
            try
            {
                var email = new EmailMessage
                {
                    To = string.Empty,/* Get email for User record */
                    Body = $"Your post for {post.Category.Name} has been cancelled successfully.",
                    Subject = "Post Cancelled"
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
