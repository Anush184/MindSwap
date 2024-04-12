using AutoMapper;
using MediatR;
using MindSwap.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CategoryFeature.Queries.GetCategoryDetails
{
    public class GetCategoryDetailsQueryHandler : IRequestHandler<GetCategoryDetailsQuery, CategoryDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryDetailsQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            this._mapper = mapper;
            this._categoryRepository = categoryRepository;
        }
        public async Task<CategoryDetailsDto> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetByIdAsync(request.Id);

            var data = _mapper.Map<CategoryDetailsDto>(categories);

            return data;
        }
    }
}
