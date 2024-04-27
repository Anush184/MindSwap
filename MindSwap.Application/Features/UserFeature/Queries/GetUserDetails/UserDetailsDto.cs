using MindSwap.Application.Features.CategoryFeature.Queries.GetAllCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MindSwap.Domain;

namespace MindSwap.Application.Features.PostFeature.Queries.GetPostDetails
{
    public class UserDetailsDto
    { 
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; } = string.Empty;

        private ICollection<Comment> Comments{ get; set; }
        private ICollection<Post> Posts{ get; set; }
    }
}
