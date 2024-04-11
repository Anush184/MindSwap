using MindSwap.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Domain
{
    public class Comment: IVotableEntity
    {

        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }

        public ICollection<Vote> Votes { get; set; }

    }
}
