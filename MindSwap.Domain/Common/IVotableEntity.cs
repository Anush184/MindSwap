using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Domain.Common
{
    public interface IVotableEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        // Foreign key for the author of the post
        public int AuthorId { get; set; }

        // Navigation property for the author of the post
        public User Author { get; set; }
        public ICollection<Vote>? Votes { get; set; }
    }
}
