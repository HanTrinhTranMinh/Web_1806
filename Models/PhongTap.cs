// Models/PhongTap.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagement.Models;

public class PhongTap
{
        [Key]
        public int ID_PhongTap { get; set; }

        [Required]
        [MaxLength(255)]
        public string tenPhongTap { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string diaChiPhong { get; set; } = string.Empty;

        public int? sucChua { get; set; } // Thay đổi từ string sang int cho sức chứa

        public int? sucChuaThietBi { get; set; } // Thay đổi từ string sang int cho sức chứa thiết bị

        public int? ID_ThietBi { get; set; } // Có thể null nếu không phải phòng nào cũng có 1 thiết bị chính

        [ForeignKey("ID_ThietBi")]
        public virtual ThietBi? ThietBi { get; set; } // Thiết bị chính của phòng?

        // Navigation properties
        public virtual ICollection<PhanCong>? PhanCongs { get; set; }
}