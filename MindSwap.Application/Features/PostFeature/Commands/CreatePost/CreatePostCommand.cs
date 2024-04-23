using MediatR;
using MindSwap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.PostFeature.Commands.CreatePost
{
    public class CreatePostCommand: IRequest<int>
    {
        public string Content { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
