// Models/HoiVien.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagement.Models;

public class HoiVien
{
    [Key] // Đánh dấu đây là khóa chính
    public int ID_HoiVien { get; set; }

    [Required] // Bắt buộc nhập
    [MaxLength(100)] // Độ dài tối đa 100 ký tự
    public string tenHoiVien { get; set; } = string.Empty;

    public DateTime? ngaySinh { get; set; }

    [MaxLength(10)] // Giới hạn độ dài cho giới tính
    [RegularExpression("^(Nam|Nữ|Khác)$", ErrorMessage = "Giới tính phải là 'Nam', 'Nữ' hoặc 'Khác'")]
    public string? gioiTinh { get; set; } // Giả sử giới tính là string, có thể là "Nam", "Nữ", "Khác"

    [MaxLength(200)]
    public string? diaChi { get; set; } // Dấu ? cho biết thuộc tính này có thể null

    [MaxLength(15)]
    public string? sdt { get; set; }

    [EmailAddress] // Kiểm tra định dạng email
    [MaxLength(100)]
    public string? email { get; set; }

    public DateTime ngayGiaNhap { get; set; }

    // Khóa ngoại tới bảng User (sẽ tạo sau)
    // Tên thuộc tính nên theo convention là Id của bảng tham chiếu
    [ForeignKey("User")]
    public string? ID_User { get; set; } // Giả sử ID_User từ Firebase là một string

    // Navigation property (Thuộc tính điều hướng)
    // public virtual User? User { get; set; }
}