using MindSwap.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MindSwap.Domain
{
    public class Post : BaseEntity
    {
        public string Content { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment>? Comments { get; set; }
       
    }
}
