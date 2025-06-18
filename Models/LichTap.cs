// Models/HoiVien.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagement.Models;

public class LichTap
{

    [Key]
    public int ID_LichTap { get; set; }

    public int ID_TheHoiVien { get; set; } // Khóa ngoại tới TheHoiVien
    public int ID_PhongTap { get; set; } // Khóa ngoại tới PhongTap

    [Required]
    public DateTime ngayTap { get; set; }

    [Required]
    public TimeSpan gioBatDau { get; set; }

    [Required]
    public TimeSpan gioKetThuc { get; set; }

    [MaxLength(1000)]
    public string? noiDung { get; set; }

    public string? ID_User { get; set; } // Khóa ngoại Firebase ID của người tạo/cập nhật lịch tập

    [ForeignKey("ID_TheHoiVien")]
    public virtual TheHoiVien? TheHoiVien { get; set; }

    [ForeignKey("ID_PhongTap")]
    public virtual PhongTap? PhongTap { get; set; }

    [ForeignKey("ID_User")]
    public virtual User? User { get; set; }
}
