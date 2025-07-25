using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace project.Models
{
    public class Tour
    {
        [Key]
        public int? Id { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        public string? Name { get; set; }
        public string? Image { get; set; }
        [Required(ErrorMessage = "Vị trí không được để trống")]
        public string? Location { get; set; }
        [Required(ErrorMessage = "Loại hình du lịch không được để trống")]
        public string? Duration { get; set; }
        [Required(ErrorMessage = "Giá Không được để trống")]
        public double? Price { get; set; }
        [Required(ErrorMessage = "Số người không được để trống")]
        public int? People { get; set; }
        public int? View { get; set; } = 1;
        [Required(ErrorMessage = "Mô tả không được để trống")]
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public int? CategoryId { get; set; }

        // Navigation Property
        public virtual Category? Category { get; set; }

        // Navigation Properties
        public virtual ICollection<History>? Histories { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; } // dùng để upload
    }
}
