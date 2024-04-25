using MindSwap.Application.Features.CategoryFeature.Queries.GetAllCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.PostFeature.Queries.GetPostDetails
{
    public class PostDetailsDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
