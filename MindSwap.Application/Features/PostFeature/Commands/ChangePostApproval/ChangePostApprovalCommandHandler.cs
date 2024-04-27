using AutoMapper;
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
using System.Threading;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.PostFeature.Commands.ChangePostApproval
{
    public class ChangePostApprovalCommandHandler : IRequestHandler<ChangePostApprovalCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IPostRepository _postRepository;
        private readonly IAppLogger<ChangePostApprovalCommandHandler> _appLogger;

        public ChangePostApprovalCommandHandler(IMapper mapper, IEmailSender emailSender,
            IPostRepository postRepository, 
            IAppLogger<ChangePostApprovalCommandHandler> appLogger)
        {
            _mapper = mapper;
            _emailSender = emailSender;
            _postRepository = postRepository;
            _appLogger = appLogger;
        }
        public async Task<Unit> Handle(ChangePostApprovalCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.Id);
            if (post == null)
            {
                throw new NotFoundException(nameof(Post), request.Id);
            }
                post.Approved = request.Approved;
                await _postRepository.UpdateAsync(post);
               
                // send confirmation mail
                try
                {
                    var email = new EmailMessage
                    {
                        To = string.Empty,/* Get email for User record */
                        Body = $"The approval status for your post for {post.Category.Name} has been updated.",
                        Subject = "Post Approval Status Updated"
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

