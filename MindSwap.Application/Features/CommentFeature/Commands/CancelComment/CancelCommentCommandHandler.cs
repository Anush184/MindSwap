using MediatR;
using MindSwap.Application.Contracts.Email;
using MindSwap.Application.Contracts.Logging;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Exceptions;
using MindSwap.Application.Features.PostFeature.Commands.CancelPost;
using MindSwap.Application.Models.Email;
using MindSwap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CommentFeature.Commands.CancelComment
{
    public class CancelCommentCommandHandler: IRequestHandler<CancelCommentCommand, Unit>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IEmailSender _emailSender;
        private readonly IAppLogger<CancelCommentCommandHandler> _appLogger;

        public CancelCommentCommandHandler(ICommentRepository commentRepository, IEmailSender emailSender,
            IAppLogger<CancelCommentCommandHandler> appLogger)
        {
            _commentRepository = commentRepository;
            _emailSender = emailSender;
            _appLogger = appLogger;
        }
        public async Task<Unit> Handle(CancelCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(request.Id);
            if (comment == null)
            {
                throw new NotFoundException(nameof(Post), request.Id);
            }
            comment.Cancelled = true;
            try
            {
                var email = new EmailMessage
                {
                    To = string.Empty,/* Get email for User record */
                    Body = $"Your comment has been cancelled successfully.",
                    Subject = "Comment Cancelled"
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
