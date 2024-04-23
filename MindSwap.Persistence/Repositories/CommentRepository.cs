using Microsoft.EntityFrameworkCore;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Domain;
using MindSwap.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Persistence.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(MSDatabaseContext context) : base(context)
        {
        }

        public async Task<List<Comment>> GetCommentsWithDetails()
        {
            var comments = await _context.Comments
                .Include(q => q.Post)
                .ToListAsync();
            return comments;
        }

        public async Task<Comment> GetCommentWithDetails(int postId)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(q => q.PostId == postId);
            return comment;
        }

        public async Task<bool> IsCommentUnique(string content)
        {
            return await _context.Comments.AnyAsync(q => q.Content == content);
        }
    }
}
