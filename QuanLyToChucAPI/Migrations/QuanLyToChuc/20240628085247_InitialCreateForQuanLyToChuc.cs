using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyToChucAPI.Migrations.QuanLyToChuc
{
    /// <inheritdoc />
    public partial class InitialCreateForQuanLyToChuc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToChucs",
                columns: table => new
                {
                    ToChucID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenKhac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnhUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinhVucChuyenMon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrucThuoc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToChucs", x => x.ToChucID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonViCongTac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NguoiLienHes",
                columns: table => new
                {
                    NguoiLienHeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToChucID = table.Column<int>(type: "int", nullable: false),
                    Ho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenDemVaTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChucDanh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiLienHe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TuNgay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DenNgay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiLienHes", x => x.NguoiLienHeID);
                    table.ForeignKey(
                        name: "FK_NguoiLienHes_ToChucs_ToChucID",
                        column: x => x.ToChucID,
                        principalTable: "ToChucs",
                        principalColumn: "ToChucID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhuongThucLienLacs",
                columns: table => new
                {
                    PhuongThucLienLacID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToChucID = table.Column<int>(type: "int", nullable: false),
                    LoaiLienLac = table.Column<int>(type: "int", nullable: false),
                    LoaiNguoiLienLac = table.Column<int>(type: "int", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhuongThucLienLacs", x => x.PhuongThucLienLacID);
                    table.ForeignKey(
                        name: "FK_PhuongThucLienLacs_ToChucs_ToChucID",
                        column: x => x.ToChucID,
                        principalTable: "ToChucs",
                        principalColumn: "ToChucID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinDinhDanhs",
                columns: table => new
                {
                    ThongTinDinhDanhID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToChucID = table.Column<int>(type: "int", nullable: false),
                    MaSoThue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiCap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TuNgay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DenNgay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTinDinhDanhs", x => x.ThongTinDinhDanhID);
                    table.ForeignKey(
                        name: "FK_ThongTinDinhDanhs_ToChucs_ToChucID",
                        column: x => x.ToChucID,
                        principalTable: "ToChucs",
                        principalColumn: "ToChucID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NguoiLienHes_ToChucID",
                table: "NguoiLienHes",
                column: "ToChucID");

            migrationBuilder.CreateIndex(
                name: "IX_PhuongThucLienLacs_ToChucID",
                table: "PhuongThucLienLacs",
                column: "ToChucID");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinDinhDanhs_ToChucID",
                table: "ThongTinDinhDanhs",
                column: "ToChucID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NguoiLienHes");

            migrationBuilder.DropTable(
                name: "PhuongThucLienLacs");

            migrationBuilder.DropTable(
                name: "ThongTinDinhDanhs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ToChucs");
        }
    }
}
