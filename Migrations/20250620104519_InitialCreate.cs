using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymManagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID_Role = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    mota = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID_Role);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID_User = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    TenDangNhap = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ID_Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID_User);
                    table.ForeignKey(
                        name: "FK_Users_Roles_ID_Role",
                        column: x => x.ID_Role,
                        principalTable: "Roles",
                        principalColumn: "ID_Role",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaoCaos",
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
                    table.PrimaryKey("PK_BaoCaos", x => x.ID_BaoCao);
                    table.ForeignKey(
                        name: "FK_BaoCaos_Users_ID_User",
                        column: x => x.ID_User,
                        principalTable: "Users",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "CaLamViecs",
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
                    table.PrimaryKey("PK_CaLamViecs", x => x.ID_Ca);
                    table.ForeignKey(
                        name: "FK_CaLamViecs_Users_UserID_User",
                        column: x => x.UserID_User,
                        principalTable: "Users",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "GoiTaps",
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
                    table.PrimaryKey("PK_GoiTaps", x => x.ID_GoiTap);
                    table.ForeignKey(
                        name: "FK_GoiTaps_Users_ID_User",
                        column: x => x.ID_User,
                        principalTable: "Users",
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
                        name: "FK_HoiViens_Users_UserID_User",
                        column: x => x.UserID_User,
                        principalTable: "Users",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "QuanLy_NhanViens",
                columns: table => new
                {
                    ID_QuanLyNhanVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Admin = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    ID_User = table.Column<string>(type: "nvarchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanLy_NhanViens", x => x.ID_QuanLyNhanVien);
                    table.ForeignKey(
                        name: "FK_QuanLy_NhanViens_Users_ID_Admin",
                        column: x => x.ID_Admin,
                        principalTable: "Users",
                        principalColumn: "ID_User",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuanLy_NhanViens_Users_ID_User",
                        column: x => x.ID_User,
                        principalTable: "Users",
                        principalColumn: "ID_User",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThietBis",
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
                    table.PrimaryKey("PK_ThietBis", x => x.ID_ThietBi);
                    table.ForeignKey(
                        name: "FK_ThietBis_Users_ID_User",
                        column: x => x.ID_User,
                        principalTable: "Users",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "HoaDon_ThanhToans",
                columns: table => new
                {
                    ID_HoaDon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_GoiTap = table.Column<int>(type: "int", nullable: false),
                    soTien = table.Column<int>(type: "int", nullable: false),
                    ngayThu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_User = table.Column<string>(type: "nvarchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon_ThanhToans", x => x.ID_HoaDon);
                    table.ForeignKey(
                        name: "FK_HoaDon_ThanhToans_GoiTaps_ID_GoiTap",
                        column: x => x.ID_GoiTap,
                        principalTable: "GoiTaps",
                        principalColumn: "ID_GoiTap",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDon_ThanhToans_Users_ID_User",
                        column: x => x.ID_User,
                        principalTable: "Users",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "TheHoiViens",
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
                    table.PrimaryKey("PK_TheHoiViens", x => x.ID_TheHoiVien);
                    table.ForeignKey(
                        name: "FK_TheHoiViens_GoiTaps_ID_GoiTap",
                        column: x => x.ID_GoiTap,
                        principalTable: "GoiTaps",
                        principalColumn: "ID_GoiTap",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TheHoiViens_HoiViens_ID_HoiVien",
                        column: x => x.ID_HoiVien,
                        principalTable: "HoiViens",
                        principalColumn: "ID_HoiVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TheHoiViens_Users_ID_User",
                        column: x => x.ID_User,
                        principalTable: "Users",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "HoaDon_ThanhLys",
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
                    table.PrimaryKey("PK_HoaDon_ThanhLys", x => x.ID_ThanhLi);
                    table.ForeignKey(
                        name: "FK_HoaDon_ThanhLys_ThietBis_ID_ThietBi",
                        column: x => x.ID_ThietBi,
                        principalTable: "ThietBis",
                        principalColumn: "ID_ThietBi",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDon_ThanhLys_Users_ID_User",
                        column: x => x.ID_User,
                        principalTable: "Users",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "PhongTaps",
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
                    table.PrimaryKey("PK_PhongTaps", x => x.ID_PhongTap);
                    table.ForeignKey(
                        name: "FK_PhongTaps_ThietBis_ID_ThietBi",
                        column: x => x.ID_ThietBi,
                        principalTable: "ThietBis",
                        principalColumn: "ID_ThietBi");
                });

            migrationBuilder.CreateTable(
                name: "LichTaps",
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
                    table.PrimaryKey("PK_LichTaps", x => x.ID_LichTap);
                    table.ForeignKey(
                        name: "FK_LichTaps_PhongTaps_ID_PhongTap",
                        column: x => x.ID_PhongTap,
                        principalTable: "PhongTaps",
                        principalColumn: "ID_PhongTap",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichTaps_TheHoiViens_ID_TheHoiVien",
                        column: x => x.ID_TheHoiVien,
                        principalTable: "TheHoiViens",
                        principalColumn: "ID_TheHoiVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichTaps_Users_ID_User",
                        column: x => x.ID_User,
                        principalTable: "Users",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "PhanCongs",
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
                    table.PrimaryKey("PK_PhanCongs", x => x.ID_PhanCong);
                    table.ForeignKey(
                        name: "FK_PhanCongs_CaLamViecs_ID_CaLam",
                        column: x => x.ID_CaLam,
                        principalTable: "CaLamViecs",
                        principalColumn: "ID_Ca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanCongs_PhongTaps_ID_PhongTap",
                        column: x => x.ID_PhongTap,
                        principalTable: "PhongTaps",
                        principalColumn: "ID_PhongTap",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanCongs_Users_ID_User",
                        column: x => x.ID_User,
                        principalTable: "Users",
                        principalColumn: "ID_User",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhanCongs_Users_createdByAdminID",
                        column: x => x.createdByAdminID,
                        principalTable: "Users",
                        principalColumn: "ID_User",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID_Role", "mota", "tenRole" },
                values: new object[,]
                {
                    { 1, "Admin", "" },
                    { 2, "QuanLy", "" },
                    { 3, "HoiVien", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaos_ID_User",
                table: "BaoCaos",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_CaLamViecs_UserID_User",
                table: "CaLamViecs",
                column: "UserID_User");

            migrationBuilder.CreateIndex(
                name: "IX_GoiTaps_ID_User",
                table: "GoiTaps",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_ThanhLys_ID_ThietBi",
                table: "HoaDon_ThanhLys",
                column: "ID_ThietBi");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_ThanhLys_ID_User",
                table: "HoaDon_ThanhLys",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_ThanhToans_ID_GoiTap",
                table: "HoaDon_ThanhToans",
                column: "ID_GoiTap");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_ThanhToans_ID_User",
                table: "HoaDon_ThanhToans",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_HoiViens_UserID_User",
                table: "HoiViens",
                column: "UserID_User");

            migrationBuilder.CreateIndex(
                name: "IX_LichTaps_ID_PhongTap",
                table: "LichTaps",
                column: "ID_PhongTap");

            migrationBuilder.CreateIndex(
                name: "IX_LichTaps_ID_TheHoiVien",
                table: "LichTaps",
                column: "ID_TheHoiVien");

            migrationBuilder.CreateIndex(
                name: "IX_LichTaps_ID_User",
                table: "LichTaps",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_PhanCongs_createdByAdminID",
                table: "PhanCongs",
                column: "createdByAdminID");

            migrationBuilder.CreateIndex(
                name: "IX_PhanCongs_ID_CaLam",
                table: "PhanCongs",
                column: "ID_CaLam");

            migrationBuilder.CreateIndex(
                name: "IX_PhanCongs_ID_PhongTap",
                table: "PhanCongs",
                column: "ID_PhongTap");

            migrationBuilder.CreateIndex(
                name: "IX_PhanCongs_ID_User",
                table: "PhanCongs",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_PhongTaps_ID_ThietBi",
                table: "PhongTaps",
                column: "ID_ThietBi");

            migrationBuilder.CreateIndex(
                name: "IX_QuanLy_NhanViens_ID_Admin",
                table: "QuanLy_NhanViens",
                column: "ID_Admin");

            migrationBuilder.CreateIndex(
                name: "IX_QuanLy_NhanViens_ID_User",
                table: "QuanLy_NhanViens",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_TheHoiViens_ID_GoiTap",
                table: "TheHoiViens",
                column: "ID_GoiTap");

            migrationBuilder.CreateIndex(
                name: "IX_TheHoiViens_ID_HoiVien",
                table: "TheHoiViens",
                column: "ID_HoiVien");

            migrationBuilder.CreateIndex(
                name: "IX_TheHoiViens_ID_User",
                table: "TheHoiViens",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_ThietBis_ID_User",
                table: "ThietBis",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ID_Role",
                table: "Users",
                column: "ID_Role");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaoCaos");

            migrationBuilder.DropTable(
                name: "HoaDon_ThanhLys");

            migrationBuilder.DropTable(
                name: "HoaDon_ThanhToans");

            migrationBuilder.DropTable(
                name: "LichTaps");

            migrationBuilder.DropTable(
                name: "PhanCongs");

            migrationBuilder.DropTable(
                name: "QuanLy_NhanViens");

            migrationBuilder.DropTable(
                name: "TheHoiViens");

            migrationBuilder.DropTable(
                name: "CaLamViecs");

            migrationBuilder.DropTable(
                name: "PhongTaps");

            migrationBuilder.DropTable(
                name: "GoiTaps");

            migrationBuilder.DropTable(
                name: "HoiViens");

            migrationBuilder.DropTable(
                name: "ThietBis");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
