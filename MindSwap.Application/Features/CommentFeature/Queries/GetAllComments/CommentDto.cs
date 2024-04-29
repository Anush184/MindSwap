using MindSwap.Application.Features.PostFeature.Queries.GetAllPosts;
using MindSwap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CommentFeature.Queries.GetAllComments
{
    public class CommentDto
    {
        public string CommentedUserId {  get; set; }
        public string Content { get; set; } = string.Empty;
        public int PostId { get; set; }
        public PostDto Post { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
