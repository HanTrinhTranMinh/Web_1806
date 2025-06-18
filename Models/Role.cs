// Models/HoiVien.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagement.Models;

public class Role
{

    [Key]
    public int ID_Role { get; set; }

    [Required]
    [MaxLength(255)] // Giả định độ dài NVARCHAR(255)
    public string mota { get; set; } = string.Empty;

    // Navigation property
    public virtual ICollection<User>? Users { get; set; }
}
