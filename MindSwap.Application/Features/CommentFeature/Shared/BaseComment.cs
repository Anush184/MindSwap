using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.CommentFeature.Shared
{
    public abstract class BaseComment
    {
        public string Content { get; set; } = string.Empty;
        public int PostId { get; set; }
    }
}
