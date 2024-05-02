using Microsoft.AspNetCore.Components;
using MindSwap.BlazorUI.Contracts;
using MindSwap.BlazorUI.Models.Categories;

namespace MindSwap.BlazorUI.Pages.Categories
{
    public partial class Details
    {
        [Inject]
        ICategoryService _client { get; set; }

        [Parameter]
        public int id { get; set; }

        CategoryVM category = new CategoryVM();

        protected async override Task OnParametersSetAsync()
        {
            category = await _client.GetCategoryDetails(id);
        }

    }
}