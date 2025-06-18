
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagement.Models;


public class BaoCao
{
    [Key]
    public int ID_BaoCao { get; set; }

    [Required]
    [MaxLength(255)]
    public string tenBaoCao { get; set; } = string.Empty;

    [Required]
    public DateTime ngayBaoCao { get; set; }

    [MaxLength(4000)] // Có thể lớn hơn nếu nội dung dài
    public string? noiDung { get; set; }

    public string? ID_User { get; set; } // Khóa ngoại Firebase ID

    [ForeignKey("ID_User")]
    public virtual User? User { get; set; }
}
