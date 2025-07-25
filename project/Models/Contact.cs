using System.ComponentModel.DataAnnotations;
namespace project.Models
{
    public class Contact
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string? Email { get; set; }
        public DateTime? PostedDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Không được để trống")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string? Content { get; set; }

    }
} 
