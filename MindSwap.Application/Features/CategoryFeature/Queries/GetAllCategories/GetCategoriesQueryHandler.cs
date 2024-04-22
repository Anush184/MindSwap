using AutoMapper;
using MediatR;
using MindSwap.Application.Contracts.Logging;
using MindSwap.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CategoryFeature.Queries.GetAllCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAppLogger<GetCategoriesQueryHandler> _logger;

        public GetCategoriesQueryHandler(IMapper mapper, ICategoryRepository categoryRepository, 
            IAppLogger<GetCategoriesQueryHandler> logger)
        {
            this._mapper = _mapper;
            this._categoryRepository = categoryRepository;
            this._logger = logger;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAsync();
            var data =  _mapper.Map<List<CategoryDto>>(categories);
            _logger.LogInformation("Categories were retrieved successfully");
            return data;
        }
    }
}
