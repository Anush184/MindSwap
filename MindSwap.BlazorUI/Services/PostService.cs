using Blazored.LocalStorage;
using MindSwap.BlazorUI.Contracts;
using MindSwap.BlazorUI.Services.Base;

namespace MindSwap.BlazorUI.Services
{
    public class PostService : BaseHttpService, IPostService
    {
        public PostService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }
    }
}
