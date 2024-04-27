using System.Collections.Generic;
using System.Threading.Tasks;
using MindSwap.Domain;

namespace MindSwap.Application.Contracts.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetUser(int Id);
        Task<List<User>> GetUsers();
    }

}