using FluentValidation;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Features.CategoryFeature.Commands.UpdateCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CategoryFeature.Shared
{
    public class BaseCategoryValidator: AbstractValidator<BaseCategory>
    {
        private readonly ICategoryRepository _categoryRepository;

        public BaseCategoryValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(c => c.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");

            RuleFor(c => c.Description)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .NotNull()
              .MaximumLength(3000).WithMessage("{PropertyName} must be fewer than 3000 characters");

            RuleFor(c => c)
                .MustAsync(CategoryNameUnique)
                .WithMessage("Category already exists");
        }
        private Task<bool> CategoryNameUnique(BaseCategory command, CancellationToken token)
        {
            return _categoryRepository.IsCategoryUnique(command.Name);
        }
    }
}
