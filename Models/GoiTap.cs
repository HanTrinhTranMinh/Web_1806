// Models/HoiVien.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagement.Models;

public class GoiTap
{

    [Key]
    public int ID_GoiTap { get; set; }

    [Required]
    [MaxLength(255)]
    public string tenGoi { get; set; } = string.Empty;

    public int soTien { get; set; } // Đổi tên từ giaTien thành soTien cho đồng bộ với sơ đồ

    [Required]
    [MaxLength(500)]
    public string moTa { get; set; } = string.Empty;

    [Required]
    public DateTime ngayBatDau { get; set; }

    [Required]
    public DateTime ngayKetThuc { get; set; }

    public int? soBuoi { get; set; } // Có thể null

    public string? ID_User { get; set; } // Khóa ngoại Firebase ID của người tạo gói tập

    [ForeignKey("ID_User")]
    public virtual User? User { get; set; }

    // Navigation properties
    public virtual ICollection<HoaDon_ThanhToan>? HoaDon_ThanhToans { get; set; }
    public virtual ICollection<TheHoiVien>? TheHoiViens { get; set; }
}
