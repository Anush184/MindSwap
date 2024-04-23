using FluentValidation;
using MindSwap.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CategoryFeature.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator: AbstractValidator<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandValidator(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(CategoryMustExist);

            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

            RuleFor(p => p.Description)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(600).WithMessage("{PropertyName} must be fewer than 600 characters");

            RuleFor(q => q)
                .MustAsync(CategoryNameUnique)
                .WithMessage("Category already exists");
        }

        private async Task<bool> CategoryMustExist(int id, CancellationToken arg2)
        {
           var category = await _categoryRepository.GetByIdAsync(id);
            return category != null;    
        }

        private Task<bool> CategoryNameUnique(UpdateCategoryCommand command, CancellationToken token)
        {
            return _categoryRepository.IsCategoryUnique(command.Name);
        }
    }
}
