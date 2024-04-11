using MindSwap.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Domain
{
    public class Vote
    {
        public int VoteId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int EntityId { get; set; }

        public IVotableEntity VotableEntity { get; set; }

        public bool IsUpvote { get; set; }
    }
}
