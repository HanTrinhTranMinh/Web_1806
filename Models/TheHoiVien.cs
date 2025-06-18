// Models/HoiVien.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagement.Models;

public class TheHoiVien
{

    [Key]
    public int ID_TheHoiVien { get; set; }

    public int ID_HoiVien { get; set; }
    public int ID_GoiTap { get; set; }

    [Required]
    public DateTime ngayDangKy { get; set; }

    [Required]
    public DateTime ngayHetHan { get; set; }

    [Required]
    [MaxLength(50)] // Ví dụ: "Hoạt động", "Hết hạn", "Tạm dừng"
    public string tinhTrangThe { get; set; } = string.Empty;

    public string? ID_User { get; set; } // Khóa ngoại Firebase ID của người tạo thẻ

    [ForeignKey("ID_HoiVien")]
    public virtual HoiVien? HoiVien { get; set; }

    [ForeignKey("ID_GoiTap")]
    public virtual GoiTap? GoiTap { get; set; }

    [ForeignKey("ID_User")]
    public virtual User? User { get; set; }
}