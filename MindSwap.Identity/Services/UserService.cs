using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MindSwap.Application.Contracts.Identity;
using MindSwap.Application.Models.Identity;
using MindSwap.Identity.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            this._userManager = userManager;
            this._mapper = mapper;
        }
        public async Task<Participant> GetParticipant(string userId)
        {
            //var participant = await _userManager.FindByIdAsync(userId);
            //return new Participant
            //{
            //    Email = participant.Email,
            //    Id = participant.Id,
            //    FirstName = participant.FirstName,
            //    LastName = participant.LastName
            //};
            var participant = await _userManager.FindByIdAsync(userId);
            return _mapper.Map<Participant>(participant);
        }

        public async Task<List<Participant>> GetParticipants()
        {
            //var participants = await _userManager.GetUsersInRoleAsync("Participant");
            //return participants.Select(q => new Participant
            //{
            //    Id = q.Id,
            //    Email = q.Email,
            //    FirstName = q.FirstName,
            //    LastName = q.LastName,
            //}).ToList();
            var participants = await _userManager.GetUsersInRoleAsync("Participant");
            return _mapper.Map<List<Participant>>(participants);
        }
    }
}
