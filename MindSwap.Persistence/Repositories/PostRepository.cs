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
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(MSDatabaseContext context) : base(context)
        {
        }

        public async Task<List<Post>> GetPostsWithDetails()
        {
            var posts = await _context.Posts
                .Include(q => q.Category)
                .Include(q => q.Comments)
                .ToListAsync();
            return posts;
        }

        public async Task<Post> GetPostWithDetails(int id)
        {
            var post = await _context.Posts
               .Include(p => p.Category)
               .Include(p => p.Comments)
               .FirstOrDefaultAsync(p => p.Id == id);

            return post;
        }

        public async Task<bool> IsPostUnique(string content)
        {
            return await _context.Posts.AnyAsync(q => q.Content == content);
        }
    }
}
