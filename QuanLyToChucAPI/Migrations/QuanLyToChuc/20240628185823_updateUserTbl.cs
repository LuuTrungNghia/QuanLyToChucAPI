using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyToChucAPI.Migrations.QuanLyToChuc
{
    /// <inheritdoc />
    public partial class updateUserTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DienThoai",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "HoTen",
                table: "AspNetUsers",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "DonViCongTac",
                table: "AspNetUsers",
                newName: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetRoles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.CreateTable(
                name: "ToChucs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenToChuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToChucs", x => x.Id);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        principalColumn: "Id",
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
                        principalColumn: "Id",
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
                name: "ToChucs");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AspNetUsers",
                newName: "HoTen");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "AspNetUsers",
                newName: "DonViCongTac");

            migrationBuilder.AddColumn<string>(
                name: "DienThoai",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetRoles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);
        }
    }
}
