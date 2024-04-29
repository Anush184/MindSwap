using MindSwap.Application.Contracts.Persistence;
using MindSwap.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.UnitTests.Mocks
{
    public class MockCategoryRepository
    {
        public static Mock<ICategoryRepository> GetMockCategoryRepository()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Test Business",
                    Description = "Test Business Description",
                },
                new Category
                {
                    Id = 2,
                     Name = "Test Sport",
                    Description = "Test Sport Description",
                },
                new Category
                {
                    Id = 3,
                    Name = "Test Science",
                    Description = "Test Science Description",
                }
            };

            var mockRepo = new Mock<ICategoryRepository>();
            mockRepo.Setup(r => r.GetCategoriesWithDetails()).ReturnsAsync(categories);
            mockRepo.Setup(r => r.CreateAsync(It.IsAny<Category>()))
                .Returns((Category category) =>
                {
                    categories.Add(category);
                    return Task.CompletedTask;
                });

            return mockRepo;
        }
    }
}
