using MindSwap.Domain;

namespace MindSwap.Application.Contracts.Persistence
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<List<Post>> GetPostsWithDetails();
        
        Task<bool> IsPostUnique(string content);
    }

}
