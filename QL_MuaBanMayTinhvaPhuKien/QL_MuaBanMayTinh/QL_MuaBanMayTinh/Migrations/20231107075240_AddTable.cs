using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QL_MuaBanMayTinh.Migrations
{
    public partial class AddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TenSanPham",
                table: "SanPham",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "DanhMucSanPham",
                columns: table => new
                {
                    MaDM = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucSanPham", x => x.MaDM);
                });

            migrationBuilder.CreateTable(
                name: "ThanhPhan",
                columns: table => new
                {
                    MaTP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenTP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SLTonKho = table.Column<int>(type: "int", nullable: false),
                    SoSeri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaTP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaDM = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhPhan", x => x.MaTP);
                    table.ForeignKey(
                        name: "FK_TP_DMSP",
                        column: x => x.MaDM,
                        principalTable: "DanhMucSanPham",
                        principalColumn: "MaDM");
                });

            migrationBuilder.CreateTable(
                name: "SanPhamThanhPhan",
                columns: table => new
                {
                    MaTP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamThanhPhan", x => new { x.MaSP, x.MaTP });
                    table.ForeignKey(
                        name: "FK_SPTP_SP",
                        column: x => x.MaSP,
                        principalTable: "SanPham",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SPTP_TP",
                        column: x => x.MaTP,
                        principalTable: "ThanhPhan",
                        principalColumn: "MaTP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamThanhPhan_MaTP",
                table: "SanPhamThanhPhan",
                column: "MaTP");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhPhan_MaDM",
                table: "ThanhPhan",
                column: "MaDM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SanPhamThanhPhan");

            migrationBuilder.DropTable(
                name: "ThanhPhan");

            migrationBuilder.DropTable(
                name: "DanhMucSanPham");

            migrationBuilder.AlterColumn<string>(
                name: "TenSanPham",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
