using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MindSwap.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string? Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DateRegistered { get; set; }

        // Navigation property for posts authored by this user
        public ICollection<Post>? AuthoredPosts { get; set; }

        // Navigation property for comments authored by this user
        public ICollection<Comment>? AuthoredComments { get; set; }

        // Navigation property for votes cast by this user
        public ICollection<Vote>? Votes { get; set; }
    }

}
