// Models/HoiVien.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagement.Models;

public class PhanCong
{

    [Key]
    public int ID_PhanCong { get; set; }

    public int ID_PhongTap { get; set; }
    public int ID_CaLam { get; set; }
    public string? ID_User { get; set; } // Khóa ngoại Firebase ID của người được phân công

    [Required]
    public DateTime ngayPhanCong { get; set; }

    public string? createdByAdminID { get; set; } // Khóa ngoại Firebase ID của admin tạo phân công

    [ForeignKey("ID_PhongTap")]
    public virtual PhongTap? PhongTap { get; set; }

    [ForeignKey("ID_CaLam")]
    public virtual CaLamViec? CaLamViec { get; set; }

    [ForeignKey("ID_User")]
    public virtual User? User { get; set; } // Người được phân công

    [ForeignKey("createdByAdminID")]
    public virtual User? AdminCreator { get; set; } // Admin tạo phân công

}
