using System.ComponentModel.DataAnnotations;

namespace MindSwap.BlazorUI.Models.Categories
{
    public class CategoryVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
