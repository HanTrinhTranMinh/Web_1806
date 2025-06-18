// Models/HoiVien.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagement.Models;

public class User
{

    [Key]
    [MaxLength(128)] // Firebase UIDs thường có độ dài cố định, ví dụ 28 ký tự, nhưng MaxLength 128 là an toàn.
    public string ID_User { get; set; } = string.Empty; // Đây sẽ là Firebase UID

    [Required]
    [MaxLength(255)]
    public string TenDangNhap { get; set; } = string.Empty; // Hoặc dùng display name từ Firebase

    // Không nên lưu password ở đây nếu dùng Firebase Auth. 
    // Firebase sẽ quản lý mật khẩu. Bạn có thể bỏ trường này.
    // public string password { get; set; } = string.Empty; 

    [Required]
    [MaxLength(255)]
    [EmailAddress]
    public string email { get; set; } = string.Empty;

    public int ID_Role { get; set; } // Quyền hạn trong hệ thống của bạn

    [ForeignKey("ID_Role")]
    public virtual Role? Role { get; set; }

    // Navigation properties
    public virtual ICollection<HoaDon_ThanhToan>? HoaDon_ThanhToans { get; set; }
    public virtual ICollection<HoaDon_ThanhLy>? HoaDon_ThanhLies { get; set; }
    public virtual ICollection<BaoCao>? BaoCaos { get; set; }
    public virtual ICollection<QuanLy_NhanVien>? QuanLy_NhanViensCreated { get; set; } // Admin tạo
    public virtual ICollection<QuanLy_NhanVien>? QuanLy_NhanViensManaged { get; set; } // User được quản lý
    public virtual ICollection<ThietBi>? ThietBis { get; set; }
    public virtual ICollection<TheHoiVien>? TheHoiViens { get; set; }
    public virtual ICollection<GoiTap>? GoTaps { get; set; }
    public virtual ICollection<PhanCong>? PhanCongsAssigned { get; set; } // Người được phân công
    public virtual ICollection<PhanCong>? PhanCongsCreated { get; set; } // Admin tạo phân công
    public virtual ICollection<CaLamViec>? CaiLamViecs { get; set; } // Giả định có người tạo ca làm việc
    public virtual ICollection<LichTap>? LichTaps { get; set; }
    public virtual ICollection<HoiVien>? HoiViensCreated { get; set; } // User tạo hội viên
}