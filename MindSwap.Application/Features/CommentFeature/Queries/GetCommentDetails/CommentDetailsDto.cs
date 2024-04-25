using MindSwap.Application.Features.PostFeature.Queries.GetAllPosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CommentFeature.Queries.GetCommentDetails
{
    public class CommentDetailsDto
    {
        public string CommentedUserId { get; set; }
        public string Content { get; set; } = string.Empty;
        public int PostId { get; set; }
        public PostDto Post { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModifired { get; set; }
        public bool? Approved { get; set; }
        public bool Canceled { get; set;}
    }
}
