using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using MindSwap.BlazorUI.Contracts;
using MindSwap.BlazorUI.Models;

namespace MindSwap.BlazorUI.Pages
{
    public partial class Register
    {
        public RegisterVM Model { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }    
        public string Message { get; set; }
        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        protected override void OnInitialized()
        {
           Model = new RegisterVM();
        }

        protected async Task HandleRegister()
        {
            var result = await AuthenticationService.RegisterAsync(Model.FirstName,
                Model.LastName, Model.Email, Model.UserName, Model.Password);
            if(result)
            {
                NavigationManager.NavigateTo("/");
            }
            Message = "Something went wrong, please try again."; 
        }

    }
}