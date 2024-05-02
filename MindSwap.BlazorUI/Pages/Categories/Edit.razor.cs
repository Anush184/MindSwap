using Microsoft.AspNetCore.Components;
using MindSwap.BlazorUI.Contracts;
using MindSwap.BlazorUI.Models.Categories;

namespace MindSwap.BlazorUI.Pages.Categories
{
    public partial class Edit
    {
        [Inject]
        ICategoryService _client { get; set; }

        [Inject]
        NavigationManager _navManager { get; set; }

        [Parameter]
        public int id { get; set; }
        public string Message { get; private set; }

        CategoryVM category = new CategoryVM();

        protected async override Task OnParametersSetAsync()
        {
            category = await _client.GetCategoryDetails(id);
        }

        async Task EditCategory()
        {
            var response = await _client.UpdateCategory(id, category);
            if (response.Success)
            {
                _navManager.NavigateTo("/categories/");
            }
            Message = response.Message;
        }
    }
}