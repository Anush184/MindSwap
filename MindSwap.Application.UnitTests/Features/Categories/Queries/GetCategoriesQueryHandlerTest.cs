using AutoMapper;
using MindSwap.Application.Contracts.Logging;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Features.CategoryFeature.Queries.GetAllCategories;
using MindSwap.Application.MappingProfiles;
using MindSwap.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.UnitTests.Features.Categories.Queries
{
    public class GetCategoriesQueryHandlerTest
    {
        private readonly Mock<ICategoryRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetCategoriesQueryHandler>> _mockAppLoger;

        public GetCategoriesQueryHandlerTest()
        {
            _mockRepo = MockCategoryRepository.GetMockCategoryRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<CategoryProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _mockAppLoger = new Mock<IAppLogger<GetCategoriesQueryHandler>>();
        }
        [Fact]
        public async Task GetCategoriesTest()
        {
            var handler = new GetCategoriesQueryHandler(_mapper, _mockRepo.Object, 
                _mockAppLoger.Object);
            var result = await handler.Handle(new GetCategoriesQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<CategoryDto>>();
            result.Count.ShouldBe(3);
        }
    }
}
