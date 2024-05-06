using MindSwap.BlazorUI.Models.Categories;
using MindSwap.BlazorUI.Services.Base;

namespace MindSwap.BlazorUI.Contracts
{
    public interface ICategoryService
    {
        Task<List<CategoryVM>> GetCategories();
        Task<CategoryVM> GetCategoryDetails(int id);
        Task<Response<Guid>> CreateCategory(CategoryVM category);
        Task<Response<Guid>> UpdateCategory(int id, CategoryVM category);
        Task<Response<Guid>> DeleteCategory(int id);

    }
}
