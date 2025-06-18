// Models/HoiVien.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagement.Models;

public class HoaDon_ThanhLy
{
    [Key]
    public int ID_ThanhLi { get; set; }

    public int ID_ThietBi { get; set; }
    public int soTien { get; set; }

    [Required]
    public DateTime ngayThanhLy { get; set; }

    public string? ID_User { get; set; } // Khóa ngoại Firebase ID

    [ForeignKey("ID_ThietBi")]
    public virtual ThietBi? ThietBi { get; set; }

    [ForeignKey("ID_User")]
    public virtual User? User { get; set; }
}
