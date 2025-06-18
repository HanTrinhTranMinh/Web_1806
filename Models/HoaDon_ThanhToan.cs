// Models/HoiVien.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagement.Models;

public class HoaDon_ThanhToan
{
    [Key]
    public int ID_HieuDon { get; set; }

    public int ID_GoiTap { get; set; }
    public int soTien { get; set; }

    [Required]
    public DateTime ngayThu { get; set; }

    public string? ID_User { get; set; } // Khóa ngoại Firebase ID

    [ForeignKey("ID_GoiTap")]
    public virtual GoiTap? GoiTap { get; set; }

    [ForeignKey("ID_User")]
    public virtual User? User { get; set; }
}