using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyToChucAPI.Migrations.QuanLyToChuc
{
    /// <inheritdoc />
    public partial class AddAddressToToChuc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "ToChucs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TinhThanhPho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuanHuyen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhuongXa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoNhaDuongPho = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToChucs_AddressId",
                table: "ToChucs",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToChucs_Address_AddressId",
                table: "ToChucs",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToChucs_Address_AddressId",
                table: "ToChucs");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_ToChucs_AddressId",
                table: "ToChucs");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "ToChucs");
        }
    }
}
