using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using GymManagement.Models;

namespace GymManagement.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Define DbSets for your entities here
    // public DbSet<YourEntity> YourEntities { get; set; }
    public DbSet<HoiVien> HoiViens { get; set; }
    public DbSet<PhongTap> PhongTaps { get; set; }
    public DbSet<PhongTap> BaoCaos { get; set; }
    public DbSet<PhongTap> CaLamViecs { get; set; }
    public DbSet<PhongTap> GoiTaps { get; set; }
    public DbSet<PhongTap> HoaDon_ThanhLys { get; set; }
    public DbSet<PhongTap> HoaDon_ThanhToans { get; set; }
    public DbSet<PhongTap> PhanCongs { get; set; }

    public DbSet<PhongTap> LichTaps { get; set; }
    public DbSet<PhongTap> QuanLy_NhanViens { get; set; }
    public DbSet<PhongTap> Roles { get; set; }
    public DbSet<PhongTap> TheHoiViens { get; set; }
    public DbSet<PhongTap> ThietBis { get; set; }
    public DbSet<PhongTap> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Cấu hình mối quan hệ QuanLy_NhanVien
        modelBuilder.Entity<QuanLy_NhanVien>()
            .HasOne(q => q.AdminUser)
            .WithMany(u => u.QuanLy_NhanViensCreated)
            .HasForeignKey(q => q.ID_Admin)
            .OnDelete(DeleteBehavior.Restrict); // tránh loop khi xóa

        modelBuilder.Entity<QuanLy_NhanVien>()
            .HasOne(q => q.ManagedUser)
            .WithMany(u => u.QuanLy_NhanViensManaged)
            .HasForeignKey(q => q.ID_User)
            .OnDelete(DeleteBehavior.Restrict);

        // Nếu còn mối quan hệ nào từ User → nhiều navigation (ví dụ PhanCong) cũng cần rõ ràng như vậy:
        modelBuilder.Entity<PhanCong>()
            .HasOne(p => p.User)
            .WithMany(u => u.PhanCongsAssigned)
            .HasForeignKey(p => p.ID_User)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PhanCong>()
            .HasOne(p => p.AdminCreator)
            .WithMany(u => u.PhanCongsCreated)
            .HasForeignKey(p => p.createdByAdminID)
            .OnDelete(DeleteBehavior.Restrict);
    }

}

