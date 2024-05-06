using AutoMapper;
using MediatR;
using MindSwap.Application.Contracts.Email;
using MindSwap.Application.Contracts.Logging;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Exceptions;
using MindSwap.Application.Features.PostFeature.Commands.ChangePostApproval;
using MindSwap.Application.Models.Email;
using MindSwap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CommentFeature.Commands.ChangeCommentApproval
{
    public class ChangeCommentApprovalCommandHandler : IRequestHandler<ChangeCommentApprovalCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly ICommentRepository _commentRepository;
        private readonly IAppLogger<ChangePostApprovalCommandHandler> _appLogger;

        public ChangeCommentApprovalCommandHandler(IMapper mapper, IEmailSender emailSender,
            ICommentRepository commentRepository,
            IAppLogger<ChangePostApprovalCommandHandler> appLogger)
        {
            _mapper = mapper;
            _emailSender = emailSender;
            _commentRepository = commentRepository;
            _appLogger = appLogger;
        }
        public async Task<Unit> Handle(ChangeCommentApprovalCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(request.Id);
            if (comment == null)
            {
                throw new NotFoundException(nameof(Comment), request.Id);
            }
            comment.Approved = request.Approved;
            await _commentRepository.UpdateAsync(comment);

            // send confirmation mail
            try
            {
                var email = new EmailMessage
                {
                    To = string.Empty,/* Get email for User record */
                    Body = $"The approval status for your comment has been updated.",
                    Subject = "Comment Approval Status Updated"
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
