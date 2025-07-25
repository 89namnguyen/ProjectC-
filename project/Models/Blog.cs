using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace project.Models
{
    public class Blog
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string? Title { get; set; }

        public string? Image { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string? Content { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public int? View { get; set; } = 1;
        public DateTime? PostedDate { get; set; } = DateTime.Now;

        public int? CategoryId { get; set; }

        // Navigation Property
        public virtual Category? Category { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; } // dùng để upload
    }
}
