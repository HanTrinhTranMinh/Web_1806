// Models/HoiVien.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagement.Models;

public class CaLamViec
{
    [Key]
    public int ID_Ca { get; set; }

    [Required]
    [MaxLength(255)]
    public string tenCa { get; set; } = string.Empty;

    [Required]
    [MaxLength(500)]
    public string moTa { get; set; } = string.Empty;

    // Navigation property
    public virtual ICollection<PhanCong>? PhanCongs { get; set; }

}
