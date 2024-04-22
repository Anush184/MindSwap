using MindSwap.Domain;

namespace MindSwap.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<bool> IsCategoryUnique(string name);
        Task AddCategories(List<Category> categories);
        Task<bool> CategoryExists(string name);

        Task<IReadOnlyList<Category>> GetCategoriesWithDetails();
        Task<Category> GetCategoryWithDetails(string name);

        Task<IReadOnlyList<Post>> GetCategoryPosts(int id);
    }

}
