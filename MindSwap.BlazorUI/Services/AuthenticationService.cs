using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MindSwap.BlazorUI.Contracts;
using MindSwap.BlazorUI.Providers;
using MindSwap.BlazorUI.Services.Base;

namespace MindSwap.BlazorUI.Services
{
    public class AuthenticationService : BaseHttpService, IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationService(IClient client, ILocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            try
            {
                AuthRequest authenticationRrequest = new AuthRequest()
                {
                    Email = email,
                    Password = password
                };
                var authenticationResponse = await _client.LoginAsync(authenticationRrequest);
                if (authenticationResponse.Token != string.Empty)
                {
                    await _localStorage.SetItemAsync("token", authenticationResponse.Token);
                    //Set claims in blazor and login state
                    await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn(); 
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task Logout()
        {
            //remove claims in Blazor and invalidate state
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
        }

        public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
        {
            RegistrationRequest registrationRequest = new RegistrationRequest() { FirstName = firstName, LastName = lastName,
           UserName = userName, Email = email, Password = password };
            var response = await _client.RegisterAsync(registrationRequest);
            if(!string.IsNullOrEmpty(response.UserId))
            {
                return true;
            }
            return false;
        }
    }
}
