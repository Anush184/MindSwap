using FluentValidation;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Features.CategoryFeature.Shared;
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
        _categoryRepository = categoryRepository;
        Include(new BaseCategoryValidator(_categoryRepository));
    }
}
