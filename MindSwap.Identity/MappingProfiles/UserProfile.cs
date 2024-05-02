using AutoMapper;
using MindSwap.Application.Models.Identity;
using MindSwap.Identity.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Identity.MappingProfiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<Participant, ApplicationUser>().ReverseMap();
        }
    }
}
