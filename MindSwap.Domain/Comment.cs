using MindSwap.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Domain
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; } = string.Empty;
        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}
