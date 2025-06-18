// Models/HoiVien.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagement.Models;

public class QuanLy_NhanVien
{
    [Key]
    public int ID_QuanLyNhanVien { get; set; } // Thêm một khóa chính riêng cho bảng này nếu nó là bảng liên kết

    public string? ID_Admin { get; set; } // Khóa ngoại Firebase ID của Admin
    public string? ID_User { get; set; } // Khóa ngoại Firebase ID của User được quản lý

    [ForeignKey("ID_Admin")]
    public virtual User? AdminUser { get; set; }

    [ForeignKey("ID_User")]
    public virtual User? ManagedUser { get; set; }
}