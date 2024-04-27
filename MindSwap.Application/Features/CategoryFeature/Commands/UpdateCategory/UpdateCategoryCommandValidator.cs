using FluentValidation;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Features.CategoryFeature.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CategoryFeature.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator: AbstractValidator<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            Include(new BaseCategoryValidator(_categoryRepository));

            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(CategoryMustExist);
        }

        private async Task<bool> CategoryMustExist(int id, CancellationToken arg2)
        {
           var category = await _categoryRepository.GetByIdAsync(id);
            return category != null;    
        }
    }
}
