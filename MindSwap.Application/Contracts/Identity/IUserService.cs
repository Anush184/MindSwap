using MindSwap.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<Participant>> GetParticipants();
        Task<Participant> GetParticipant(string userId);
    }
}
