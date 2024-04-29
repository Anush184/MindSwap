using Microsoft.EntityFrameworkCore;
using MindSwap.Domain;
using MindSwap.Persistence.DatabaseContext;
using Shouldly;

namespace MindSwap.Persistence.IntegrationTests
{
    public class MSDatabaseContextTests
    {
        private MSDatabaseContext _msDbContext;

        public MSDatabaseContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<MSDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _msDbContext = new MSDatabaseContext(dbOptions);
        }
        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            //arange
            var category = new Category
            {
                Id = 1,
                Name = "Test Business",
                Description = "Test Business Description",
            };

            //Act
            await _msDbContext.Categories.AddAsync(category);
            await _msDbContext.SaveChangesAsync();

            //Assert
            category.DateCreated.ShouldNotBeNull();
        }

        [Fact]
        public async void Save_SetDateModifiedValue()
        {
            //arange
            var category = new Category
            {
                Id = 1,
                Name = "Test Business",
                Description = "Test Business Description",
            };
            //Act

            await _msDbContext.Categories.AddAsync(category);
            await _msDbContext.SaveChangesAsync();

            //Assert
            category.DateModified.ShouldNotBeNull();
        }
    }
}