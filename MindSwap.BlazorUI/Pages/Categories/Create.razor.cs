using Microsoft.AspNetCore.Components;
using MindSwap.BlazorUI.Contracts;
using MindSwap.BlazorUI.Models.Categories;

namespace MindSwap.BlazorUI.Pages.Categories
{
    public partial class Create
    {
        [Inject]
        NavigationManager _navManager { get; set; }
        [Inject]
        ICategoryService _client { get; set; }
        public string Message { get; private set; }

        CategoryVM category = new CategoryVM();
        async Task CreateCategory()
        {
            var response = await _client.CreateCategory(category);
            if (response.Success)
            {
                _navManager.NavigateTo("/categories/");
            }
            Message = response.Message;
        }
    }
}