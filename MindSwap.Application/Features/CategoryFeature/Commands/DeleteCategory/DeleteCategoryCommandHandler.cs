using AutoMapper;
using MediatR;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Exceptions;
using MindSwap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CategoryFeature.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)=>
            _categoryRepository = categoryRepository;
        
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            //retrieve domain entity object
            var categoryToDelete = await _categoryRepository.GetByIdAsync(request.Id)??
                      throw new NotFoundException(nameof(Category), request.Id);
            
            //remove from database
            await _categoryRepository.DeleteAsync(categoryToDelete);
            return Unit.Value;
        }
    }
}
