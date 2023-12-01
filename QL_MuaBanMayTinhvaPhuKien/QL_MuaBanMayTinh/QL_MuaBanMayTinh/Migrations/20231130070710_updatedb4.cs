using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QL_MuaBanMayTinh.Migrations
{
    public partial class updatedb4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HD_KM",
                table: "HoaDon");

            migrationBuilder.DropTable(
                name: "KhuyenMai");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_MaKM",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "MaKM",
                table: "HoaDon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaKM",
                table: "HoaDon",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KhuyenMai",
                columns: table => new
                {
                    MaKhuyenMai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhanTramGiamGia = table.Column<int>(type: "int", nullable: false),
                    TenKhuyenMai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMai", x => x.MaKhuyenMai);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaKM",
                table: "HoaDon",
                column: "MaKM");

            migrationBuilder.AddForeignKey(
                name: "FK_HD_KM",
                table: "HoaDon",
                column: "MaKM",
                principalTable: "KhuyenMai",
                principalColumn: "MaKhuyenMai");
        }
    }
}
