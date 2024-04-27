using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MindSwap.Domain.Common;

namespace MindSwap.Domain
{
    public class User:BaseEntity
    {
        [MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(50)]

        public string Password { get; set; }
        [MaxLength(50)]

        public string Email { get; set; } = string.Empty;

        private ICollection<Comment> Comments{ get; set; }
        private ICollection<Post> Posts{ get; set; }
    }
}