using AutoMapper;
using FluentValidation;
using MediatR;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Exceptions;
using MindSwap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CategoryFeature.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            this._mapper = mapper;
            this._categoryRepository = categoryRepository;
        }
        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new CreateCategoryCommandValidator(_categoryRepository);
            var validationResult = await validator.ValidateAsync(request);
            if(validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Category", validationResult);
            }

            //Convert to domain entity object
            var categoryToCreate = _mapper.Map<Category>(request);
            //add to database
            await _categoryRepository.CreateAsync(categoryToCreate);
            // return record id
            return categoryToCreate.Id;
        }
    }
}
