using Microsoft.AspNetCore.Components;
using MindSwap.BlazorUI.Contracts;
using MindSwap.BlazorUI.Moduls.Categories;

namespace MindSwap.BlazorUI.Pages.Categories
{
    public partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public ICategoryService CategoryService { get; set; }
        public List<CategoryVM> Categories { get; private set; }
        public string Message { get; set; } = string.Empty;
        protected void CreateCategory()
        {
            NavigationManager.NavigateTo("/categories/create/");
        }
        protected void ChooseCategory(int id)
        {
            //
        }
        protected void EditCategory(int id)
        {
            NavigationManager.NavigateTo("/categories/edit/{id}");
        }
        protected void DetailsCategory(int id)
        {
            NavigationManager.NavigateTo("/categories/details/{id}");
        }
        protected async Task DeleteCategory(int id)
        {
            var response = await CategoryService.DeleteCategory(id);
            if (response.Success)
            {
                StateHasChanged();
            }
            else
            {
                Message = response.Message;
            }
        }
        protected override async Task OnInitializedAsync()
        {
            Categories = await CategoryService.GetCategories();
        }


    }
}