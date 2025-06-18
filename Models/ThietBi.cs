// Models/HoiVien.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagement.Models;

public class ThietBi
{
    [Key]
    public int ID_ThietBi { get; set; }

    [Required]
    [MaxLength(255)]
    public string tenThietBi { get; set; } = string.Empty;

    public int? soLuong { get; set; } // Có thể null nếu chưa có số lượng

    [Required]
    [MaxLength(255)]
    public string tinhTrang { get; set; } = string.Empty;

    public string? ID_User { get; set; } // Khóa ngoại Firebase ID của người nhập thiết bị

    [ForeignKey("ID_User")]
    public virtual User? User { get; set; }

    // Navigation property
    public virtual ICollection<HoaDon_ThanhLy>? HoaDon_ThanhLies { get; set; }
    public virtual ICollection<PhongTap>? PhongTaps { get; set; }
}
