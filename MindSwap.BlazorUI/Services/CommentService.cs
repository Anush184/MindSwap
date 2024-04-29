using MindSwap.BlazorUI.Contracts;
using MindSwap.BlazorUI.Services.Base;

namespace MindSwap.BlazorUI.Services
{
    public class CommentService : BaseHttpService, ICommentService
    {
        public CommentService(IClient client) : base(client)
        {
        }
    }
}
