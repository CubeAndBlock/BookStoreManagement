using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreManagement.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonHangs",
                columns: table => new
                {
                    MaDonHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaThanhToan = table.Column<bool>(type: "bit", nullable: false),
                    NgayGiao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrangDH = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHangs", x => x.MaDonHang);
                });

            migrationBuilder.CreateTable(
                name: "Sachs",
                columns: table => new
                {
                    MaSach = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnhBia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaBan = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sachs", x => x.MaSach);
                });

            migrationBuilder.CreateTable(
                name: "TacGias",
                columns: table => new
                {
                    MaTacGia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTacGia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DienThoai = table.Column<int>(type: "int", nullable: false),
                    TieuSu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TacGias", x => x.MaTacGia);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    MaKH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DienThoai = table.Column<int>(type: "int", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonHangMaDonHang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.MaKH);
                    table.ForeignKey(
                        name: "FK_KhachHangs_DonHangs_DonHangMaDonHang",
                        column: x => x.DonHangMaDonHang,
                        principalTable: "DonHangs",
                        principalColumn: "MaDonHang",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChuDes",
                columns: table => new
                {
                    MaChuDe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SachMaSach = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuDes", x => x.MaChuDe);
                    table.ForeignKey(
                        name: "FK_ChuDes_Sachs_SachMaSach",
                        column: x => x.SachMaSach,
                        principalTable: "Sachs",
                        principalColumn: "MaSach",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonHangSach",
                columns: table => new
                {
                    MaDonHang = table.Column<int>(type: "int", nullable: false),
                    MaSach = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHangSach", x => new { x.MaDonHang, x.MaSach });
                    table.ForeignKey(
                        name: "FK_DonHangSach_DonHangs_MaDonHang",
                        column: x => x.MaDonHang,
                        principalTable: "DonHangs",
                        principalColumn: "MaDonHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonHangSach_Sachs_MaSach",
                        column: x => x.MaSach,
                        principalTable: "Sachs",
                        principalColumn: "MaSach",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhaXuatBans",
                columns: table => new
                {
                    MaNXB = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNXB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DienThoai = table.Column<int>(type: "int", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SachMaSach = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaXuatBans", x => x.MaNXB);
                    table.ForeignKey(
                        name: "FK_NhaXuatBans_Sachs_SachMaSach",
                        column: x => x.SachMaSach,
                        principalTable: "Sachs",
                        principalColumn: "MaSach",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TacGiaSach",
                columns: table => new
                {
                    MaTacGia = table.Column<int>(type: "int", nullable: false),
                    MacSach = table.Column<int>(type: "int", nullable: false),
                    VaiTro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViTri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TacGiaSach", x => new { x.MaTacGia, x.MacSach });
                    table.ForeignKey(
                        name: "FK_TacGiaSach_Sachs_MacSach",
                        column: x => x.MacSach,
                        principalTable: "Sachs",
                        principalColumn: "MaSach",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TacGiaSach_TacGias_MaTacGia",
                        column: x => x.MaTacGia,
                        principalTable: "TacGias",
                        principalColumn: "MaTacGia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChuDes_SachMaSach",
                table: "ChuDes",
                column: "SachMaSach");

            migrationBuilder.CreateIndex(
                name: "IX_DonHangSach_MaSach",
                table: "DonHangSach",
                column: "MaSach");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangs_DonHangMaDonHang",
                table: "KhachHangs",
                column: "DonHangMaDonHang");

            migrationBuilder.CreateIndex(
                name: "IX_NhaXuatBans_SachMaSach",
                table: "NhaXuatBans",
                column: "SachMaSach");

            migrationBuilder.CreateIndex(
                name: "IX_TacGiaSach_MacSach",
                table: "TacGiaSach",
                column: "MacSach");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChuDes");

            migrationBuilder.DropTable(
                name: "DonHangSach");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "NhaXuatBans");

            migrationBuilder.DropTable(
                name: "TacGiaSach");

            migrationBuilder.DropTable(
                name: "DonHangs");

            migrationBuilder.DropTable(
                name: "Sachs");

            migrationBuilder.DropTable(
                name: "TacGias");
        }
    }
}
