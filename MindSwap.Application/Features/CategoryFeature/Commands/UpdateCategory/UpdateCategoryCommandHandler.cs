using AutoMapper;
using MediatR;
using MindSwap.Application.Contracts.Logging;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Exceptions;
using MindSwap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CategoryFeature.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAppLogger<UpdateCategoryCommandHandler> _logger;

        public UpdateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository, IAppLogger<UpdateCategoryCommandHandler> logger)
        {
            this._mapper = mapper;
            this._categoryRepository = categoryRepository;
            this._logger = logger;
        }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCategoryCommandValidator(_categoryRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Category), request.Id);
                throw new BadRequestException("Invalid Category", validationResult);
            }
            
            var categoryToUpdate = _mapper.Map<Category>(request);
            await _categoryRepository.UpdateAsync(categoryToUpdate);
            return Unit.Value;
        }
    }
}
