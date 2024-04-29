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
using System.Threading.Tasks;

namespace MindSwap.Application.Features.PostFeature.Commands.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPostRepository _postRepository;
        private readonly IEmailSender _emailSender;
        private readonly IAppLogger<UpdatePostCommandHandler> _appLogger;

        public UpdatePostCommandHandler(IMapper mapper, ICategoryRepository categoryRepository, 
            IPostRepository postRepository, IEmailSender emailSender,
            IAppLogger<UpdatePostCommandHandler> appLogger)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _postRepository = postRepository;
            _emailSender = emailSender;
            _appLogger = appLogger;
        }
        public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.Id);
            if(post is null)
            {
                throw new NotFoundException(nameof(Post), request.Id);
            }
            var validator = new UpdatePostCommandValidator(_categoryRepository, _postRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Post", validationResult);
            }
            _mapper.Map(request,post);
            await _postRepository.UpdateAsync(post);

            //Send confirmation mail
            try
            {
                var email = new EmailMessage
                {
                    To = string.Empty,/* Get email for User record */
                    Body = $"Your post for {post.Category.Name} has been updated successfully.",
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
