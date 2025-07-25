using System.ComponentModel.DataAnnotations;
namespace project.Models
{
    public class Order
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public int? UserId { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string? Phone { get; set; }

        public DateTime? Date { get; set; } = DateTime.Now;

        public byte? Status { get; set; } = 0;

        // Navigation Properties
        public virtual User? User { get; set; }

    }
} 
