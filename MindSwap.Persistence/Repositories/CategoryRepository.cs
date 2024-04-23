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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MSDatabaseContext context) : base(context)
        {
        }

        public async Task AddCategories(List<Category> categories)
        {
            await _context.AddRangeAsync(categories);
            await _context.SaveChangesAsync();
        }

        public async  Task<bool> CategoryExists(string name)
        {
            return await _context.Categories.AnyAsync(q => q.Name == name);
        }

        public async Task<IReadOnlyList<Category>> GetCategoriesWithDetails()
        {
            var categories = await _context.Categories
                .Include(q => q.Posts)
                .ToListAsync();
            return categories;
        }

        public async Task<IReadOnlyList<Post>> GetCategoryPosts(int id)
        {
            var posts = await _context.Categories
                .Where(q => q.Id == id)
                .SelectMany(q => q.Posts)
                .ToListAsync();

            return posts;
        }

        public async Task<Category> GetCategoryWithDetails(string name)
        {
            var category = await _context.Categories
                    .Include(q => q.Posts)
                    .FirstOrDefaultAsync(q => q.Name == name);

            return category;
        }

        public async Task<bool> IsCategoryUnique(string name)
        {
            return await _context.Categories.AnyAsync(q => q.Name == name);
        }
    }
}
