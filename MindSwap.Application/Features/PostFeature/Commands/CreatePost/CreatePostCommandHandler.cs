using AutoMapper;
using MediatR;
using MindSwap.Application.Contracts.Email;
using MindSwap.Application.Contracts.Logging;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Exceptions;
using MindSwap.Application.Features.CategoryFeature.Commands.CreateCategory;
using MindSwap.Application.Moduls.Email;
using MindSwap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.PostFeature.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IEmailSender _emailSender;
        private readonly IAppLogger<CreatePostCommandHandler> _appLogger;

        public CreatePostCommandHandler(IMapper mapper, IPostRepository postRepository, 
            ICategoryRepository categoryRepository, IEmailSender emailSender, 
            IAppLogger<CreatePostCommandHandler> appLogger)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            _emailSender = emailSender;
            _appLogger = appLogger;
        }
        public async Task<Unit> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePostCommandValidator(_categoryRepository, _postRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Post", validationResult);
            }
            //Get category for posts
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
            //Get post user
            // Get post comments

            //Assign post
            var postToCreate = _mapper.Map<Post>(request);
            await _postRepository.CreateAsync(postToCreate);
            //Send confirmation email
            try
            {
                var email = new EmailMessage
                {
                    To = string.Empty,/* Get email for User record */
                    Body = $"Your post for {postToCreate.Category.Name} has been submitted successfully.",
                    Subject = "Post Submitted"
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
