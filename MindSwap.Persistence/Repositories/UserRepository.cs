using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Domain;
using MindSwap.Persistence.DatabaseContext;

namespace MindSwap.Persistence.Repositories
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(MSDatabaseContext context) : base(context)
        {
        }
        public async Task<User?> GetUser(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users
                .ToListAsync();
        }

    }
}