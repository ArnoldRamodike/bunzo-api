using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BukyWebRazor.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Displa order must be between 1-100")]
        public int DispayOrder { get; set; }
    }
}