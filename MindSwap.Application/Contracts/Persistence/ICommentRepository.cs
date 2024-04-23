using MindSwap.Domain;

namespace MindSwap.Application.Contracts.Persistence
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<List<Comment>> GetCommentsWithDetails();
        Task<Comment> GetCommentWithDetails(int postId);
    }

}
