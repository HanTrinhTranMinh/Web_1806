using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID_Role = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mota = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID_Role);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID_User = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    TenDangNhap = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ID_Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID_User);
                    table.ForeignKey(
                        name: "FK_User_Role_ID_Role",
                        column: x => x.ID_Role,
                        principalTable: "Role",
                        principalColumn: "ID_Role",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaoCao",
                columns: table => new
                {
                    ID_BaoCao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenBaoCao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ngayBaoCao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    noiDung = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ID_User = table.Column<string>(type: "nvarchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoCao", x => x.ID_BaoCao);
                    table.ForeignKey(
                        name: "FK_BaoCao_User_ID_User",
                        column: x => x.ID_User,
                        principalTable: "User",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "CaLamViec",
                columns: table => new
                {
                    ID_Ca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenCa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    moTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UserID_User = table.Column<string>(type: "nvarchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaLamViec", x => x.ID_Ca);
                    table.ForeignKey(
                        name: "FK_CaLamViec_User_UserID_User",
                        column: x => x.UserID_User,
                        principalTable: "User",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "GoiTap",
                columns: table => new
                {
                    ID_GoiTap = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenGoi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    soTien = table.Column<int>(type: "int", nullable: false),
                    moTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ngayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    soBuoi = table.Column<int>(type: "int", nullable: true),
                    ID_User = table.Column<string>(type: "nvarchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoiTap", x => x.ID_GoiTap);
                    table.ForeignKey(
                        name: "FK_GoiTap_User_ID_User",
                        column: x => x.ID_User,
                        principalTable: "User",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "HoiViens",
                columns: table => new
                {
                    ID_HoiVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenHoiVien = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ngaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    gioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    diaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    sdt = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ngayGiaNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID_User = table.Column<string>(type: "nvarchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoiViens", x => x.ID_HoiVien);
                    table.ForeignKey(
                        name: "FK_HoiViens_User_UserID_User",
                        column: x => x.UserID_User,
                        principalTable: "User",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "QuanLy_NhanVien",
                columns: table => new
                {
                    ID_QuanLyNhanVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Admin = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    ID_User = table.Column<string>(type: "nvarchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanLy_NhanVien", x => x.ID_QuanLyNhanVien);
                    table.ForeignKey(
                        name: "FK_QuanLy_NhanVien_User_ID_Admin",
                        column: x => x.ID_Admin,
                        principalTable: "User",
                        principalColumn: "ID_User",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuanLy_NhanVien_User_ID_User",
                        column: x => x.ID_User,
                        principalTable: "User",
                        principalColumn: "ID_User",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThietBi",
                columns: table => new
                {
                    ID_ThietBi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenThietBi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    soLuong = table.Column<int>(type: "int", nullable: true),
                    tinhTrang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ID_User = table.Column<string>(type: "nvarchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThietBi", x => x.ID_ThietBi);
                    table.ForeignKey(
                        name: "FK_ThietBi_User_ID_User",
                        column: x => x.ID_User,
                        principalTable: "User",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "HoaDon_ThanhToan",
                columns: table => new
                {
                    ID_HieuDon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_GoiTap = table.Column<int>(type: "int", nullable: false),
                    soTien = table.Column<int>(type: "int", nullable: false),
                    ngayThu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_User = table.Column<string>(type: "nvarchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon_ThanhToan", x => x.ID_HieuDon);
                    table.ForeignKey(
                        name: "FK_HoaDon_ThanhToan_GoiTap_ID_GoiTap",
                        column: x => x.ID_GoiTap,
                        principalTable: "GoiTap",
                        principalColumn: "ID_GoiTap",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDon_ThanhToan_User_ID_User",
                        column: x => x.ID_User,
                        principalTable: "User",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "TheHoiVien",
                columns: table => new
                {
                    ID_TheHoiVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_HoiVien = table.Column<int>(type: "int", nullable: false),
                    ID_GoiTap = table.Column<int>(type: "int", nullable: false),
                    ngayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngayHetHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tinhTrangThe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ID_User = table.Column<string>(type: "nvarchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheHoiVien", x => x.ID_TheHoiVien);
                    table.ForeignKey(
                        name: "FK_TheHoiVien_GoiTap_ID_GoiTap",
                        column: x => x.ID_GoiTap,
                        principalTable: "GoiTap",
                        principalColumn: "ID_GoiTap",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TheHoiVien_HoiViens_ID_HoiVien",
                        column: x => x.ID_HoiVien,
                        principalTable: "HoiViens",
                        principalColumn: "ID_HoiVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TheHoiVien_User_ID_User",
                        column: x => x.ID_User,
                        principalTable: "User",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "HoaDon_ThanhLy",
                columns: table => new
                {
                    ID_ThanhLi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_ThietBi = table.Column<int>(type: "int", nullable: false),
                    soTien = table.Column<int>(type: "int", nullable: false),
                    ngayThanhLy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_User = table.Column<string>(type: "nvarchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon_ThanhLy", x => x.ID_ThanhLi);
                    table.ForeignKey(
                        name: "FK_HoaDon_ThanhLy_ThietBi_ID_ThietBi",
                        column: x => x.ID_ThietBi,
                        principalTable: "ThietBi",
                        principalColumn: "ID_ThietBi",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDon_ThanhLy_User_ID_User",
                        column: x => x.ID_User,
                        principalTable: "User",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "PhongTap",
                columns: table => new
                {
                    ID_PhongTap = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenPhongTap = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    diaChiPhong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    sucChua = table.Column<int>(type: "int", nullable: true),
                    sucChuaThietBi = table.Column<int>(type: "int", nullable: true),
                    ID_ThietBi = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongTap", x => x.ID_PhongTap);
                    table.ForeignKey(
                        name: "FK_PhongTap_ThietBi_ID_ThietBi",
                        column: x => x.ID_ThietBi,
                        principalTable: "ThietBi",
                        principalColumn: "ID_ThietBi");
                });

            migrationBuilder.CreateTable(
                name: "LichTap",
                columns: table => new
                {
                    ID_LichTap = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_TheHoiVien = table.Column<int>(type: "int", nullable: false),
                    ID_PhongTap = table.Column<int>(type: "int", nullable: false),
                    ngayTap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gioBatDau = table.Column<TimeSpan>(type: "time", nullable: false),
                    gioKetThuc = table.Column<TimeSpan>(type: "time", nullable: false),
                    noiDung = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ID_User = table.Column<string>(type: "nvarchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichTap", x => x.ID_LichTap);
                    table.ForeignKey(
                        name: "FK_LichTap_PhongTap_ID_PhongTap",
                        column: x => x.ID_PhongTap,
                        principalTable: "PhongTap",
                        principalColumn: "ID_PhongTap",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichTap_TheHoiVien_ID_TheHoiVien",
                        column: x => x.ID_TheHoiVien,
                        principalTable: "TheHoiVien",
                        principalColumn: "ID_TheHoiVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichTap_User_ID_User",
                        column: x => x.ID_User,
                        principalTable: "User",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "PhanCong",
                columns: table => new
                {
                    ID_PhanCong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_PhongTap = table.Column<int>(type: "int", nullable: false),
                    ID_CaLam = table.Column<int>(type: "int", nullable: false),
                    ID_User = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    ngayPhanCong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdByAdminID = table.Column<string>(type: "nvarchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanCong", x => x.ID_PhanCong);
                    table.ForeignKey(
                        name: "FK_PhanCong_CaLamViec_ID_CaLam",
                        column: x => x.ID_CaLam,
                        principalTable: "CaLamViec",
                        principalColumn: "ID_Ca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanCong_PhongTap_ID_PhongTap",
                        column: x => x.ID_PhongTap,
                        principalTable: "PhongTap",
                        principalColumn: "ID_PhongTap",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanCong_User_ID_User",
                        column: x => x.ID_User,
                        principalTable: "User",
                        principalColumn: "ID_User",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhanCong_User_createdByAdminID",
                        column: x => x.createdByAdminID,
                        principalTable: "User",
                        principalColumn: "ID_User",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaoCao_ID_User",
                table: "BaoCao",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_CaLamViec_UserID_User",
                table: "CaLamViec",
                column: "UserID_User");

            migrationBuilder.CreateIndex(
                name: "IX_GoiTap_ID_User",
                table: "GoiTap",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_ThanhLy_ID_ThietBi",
                table: "HoaDon_ThanhLy",
                column: "ID_ThietBi");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_ThanhLy_ID_User",
                table: "HoaDon_ThanhLy",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_ThanhToan_ID_GoiTap",
                table: "HoaDon_ThanhToan",
                column: "ID_GoiTap");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_ThanhToan_ID_User",
                table: "HoaDon_ThanhToan",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_HoiViens_UserID_User",
                table: "HoiViens",
                column: "UserID_User");

            migrationBuilder.CreateIndex(
                name: "IX_LichTap_ID_PhongTap",
                table: "LichTap",
                column: "ID_PhongTap");

            migrationBuilder.CreateIndex(
                name: "IX_LichTap_ID_TheHoiVien",
                table: "LichTap",
                column: "ID_TheHoiVien");

            migrationBuilder.CreateIndex(
                name: "IX_LichTap_ID_User",
                table: "LichTap",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_PhanCong_createdByAdminID",
                table: "PhanCong",
                column: "createdByAdminID");

            migrationBuilder.CreateIndex(
                name: "IX_PhanCong_ID_CaLam",
                table: "PhanCong",
                column: "ID_CaLam");

            migrationBuilder.CreateIndex(
                name: "IX_PhanCong_ID_PhongTap",
                table: "PhanCong",
                column: "ID_PhongTap");

            migrationBuilder.CreateIndex(
                name: "IX_PhanCong_ID_User",
                table: "PhanCong",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_PhongTap_ID_ThietBi",
                table: "PhongTap",
                column: "ID_ThietBi");

            migrationBuilder.CreateIndex(
                name: "IX_QuanLy_NhanVien_ID_Admin",
                table: "QuanLy_NhanVien",
                column: "ID_Admin");

            migrationBuilder.CreateIndex(
                name: "IX_QuanLy_NhanVien_ID_User",
                table: "QuanLy_NhanVien",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_TheHoiVien_ID_GoiTap",
                table: "TheHoiVien",
                column: "ID_GoiTap");

            migrationBuilder.CreateIndex(
                name: "IX_TheHoiVien_ID_HoiVien",
                table: "TheHoiVien",
                column: "ID_HoiVien");

            migrationBuilder.CreateIndex(
                name: "IX_TheHoiVien_ID_User",
                table: "TheHoiVien",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_ThietBi_ID_User",
                table: "ThietBi",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_User_ID_Role",
                table: "User",
                column: "ID_Role");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaoCao");

            migrationBuilder.DropTable(
                name: "HoaDon_ThanhLy");

            migrationBuilder.DropTable(
                name: "HoaDon_ThanhToan");

            migrationBuilder.DropTable(
                name: "LichTap");

            migrationBuilder.DropTable(
                name: "PhanCong");

            migrationBuilder.DropTable(
                name: "QuanLy_NhanVien");

            migrationBuilder.DropTable(
                name: "TheHoiVien");

            migrationBuilder.DropTable(
                name: "CaLamViec");

            migrationBuilder.DropTable(
                name: "PhongTap");

            migrationBuilder.DropTable(
                name: "GoiTap");

            migrationBuilder.DropTable(
                name: "HoiViens");

            migrationBuilder.DropTable(
                name: "ThietBi");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
