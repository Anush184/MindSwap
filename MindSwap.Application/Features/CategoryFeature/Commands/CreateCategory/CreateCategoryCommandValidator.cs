using FluentValidation;
using MindSwap.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CategoryFeature.Commands.CreateCategory;

public class CreateCategoryCommandValidator: 
    AbstractValidator<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryCommandValidator(ICategoryRepository categoryRepository)
    {
        this._categoryRepository = categoryRepository;

        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(c => c.Description)
            .MaximumLength(800).WithMessage("{PropertyName} must be fewer than 800 characters");
        RuleFor(c => c)
            .MustAsync(CategoryNameUnique)
            .WithMessage("Category already exists");
        
    }

    private Task<bool> CategoryNameUnique(CreateCategoryCommand command, CancellationToken token)
    {
        return _categoryRepository.IsCategoryUnique(command.Name);
    }
}
