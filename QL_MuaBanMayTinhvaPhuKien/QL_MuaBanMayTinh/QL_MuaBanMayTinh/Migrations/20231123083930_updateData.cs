using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QL_MuaBanMayTinh.Migrations
{
    public partial class updateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonNhapHang_DonNhapHang_FK_CTDNH_DNH",
                table: "ChiTietDonNhapHang");

            migrationBuilder.DropForeignKey(
                name: "FK_CTDNH_TP",
                table: "ChiTietDonNhapHang");

            migrationBuilder.DropForeignKey(
                name: "FK_TP_DMSP",
                table: "ThanhPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_SP_TSSP",
                table: "ThongSoSanPham");

            migrationBuilder.DropIndex(
                name: "IX_ThanhPhan_MaDM",
                table: "ThanhPhan");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietDonNhapHang_FK_CTDNH_DNH",
                table: "ChiTietDonNhapHang");

            migrationBuilder.DropColumn(
                name: "DatHang",
                table: "TinhTrangThanhToan");

            migrationBuilder.DropColumn(
                name: "NgayThanhToan",
                table: "TinhTrangThanhToan");

            migrationBuilder.DropColumn(
                name: "ThanhToan",
                table: "TinhTrangThanhToan");

            migrationBuilder.DropColumn(
                name: "GiaTP",
                table: "ThanhPhan");

            migrationBuilder.DropColumn(
                name: "MaDM",
                table: "ThanhPhan");

            migrationBuilder.DropColumn(
                name: "SoSeri",
                table: "ThanhPhan");

            migrationBuilder.DropColumn(
                name: "NgayBD",
                table: "KhuyenMai");

            migrationBuilder.DropColumn(
                name: "NgayKT",
                table: "KhuyenMai");

            migrationBuilder.DropColumn(
                name: "Gia",
                table: "ChiTietHoaDon");

            migrationBuilder.DropColumn(
                name: "FK_CTDNH_DNH",
                table: "ChiTietDonNhapHang");

            migrationBuilder.RenameColumn(
                name: "MaTP",
                table: "ThongSoSanPham",
                newName: "MaSP");

            migrationBuilder.RenameIndex(
                name: "IX_ThongSoSanPham_MaTP",
                table: "ThongSoSanPham",
                newName: "IX_ThongSoSanPham_MaSP");

            migrationBuilder.RenameColumn(
                name: "MaTP",
                table: "ChiTietDonNhapHang",
                newName: "MaSP");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietDonNhapHang_MaTP",
                table: "ChiTietDonNhapHang",
                newName: "IX_ChiTietDonNhapHang_MaSP");

            migrationBuilder.AddColumn<string>(
                name: "MaDM",
                table: "SanPham",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoSeri",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MatKhau",
                table: "KhachHang",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaKM",
                table: "HoaDon",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayThanhToan",
                table: "HoaDon",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TienDatCoc",
                table: "HoaDon",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "MaNV",
                table: "DonNhapHang",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MaDM",
                table: "SanPham",
                column: "MaDM");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaKM",
                table: "HoaDon",
                column: "MaKM");

            migrationBuilder.CreateIndex(
                name: "IX_DonNhapHang_MaNV",
                table: "DonNhapHang",
                column: "MaNV");

            migrationBuilder.AddForeignKey(
                name: "FK_CTDNH_DNH",
                table: "ChiTietDonNhapHang",
                column: "MaDDH",
                principalTable: "DonNhapHang",
                principalColumn: "MaDNH",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CTDNH_TP",
                table: "ChiTietDonNhapHang",
                column: "MaSP",
                principalTable: "SanPham",
                principalColumn: "MaSP",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DNH_NV",
                table: "DonNhapHang",
                column: "MaNV",
                principalTable: "NhanVien",
                principalColumn: "MaNV");

            migrationBuilder.AddForeignKey(
                name: "FK_HD_KM",
                table: "HoaDon",
                column: "MaKM",
                principalTable: "KhuyenMai",
                principalColumn: "MaKhuyenMai");

            migrationBuilder.AddForeignKey(
                name: "FK_TP_DMSP",
                table: "SanPham",
                column: "MaDM",
                principalTable: "DanhMucSanPham",
                principalColumn: "MaDM");

            migrationBuilder.AddForeignKey(
                name: "FK_SP_TSSP",
                table: "ThongSoSanPham",
                column: "MaSP",
                principalTable: "SanPham",
                principalColumn: "MaSP",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CTDNH_DNH",
                table: "ChiTietDonNhapHang");

            migrationBuilder.DropForeignKey(
                name: "FK_CTDNH_TP",
                table: "ChiTietDonNhapHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DNH_NV",
                table: "DonNhapHang");

            migrationBuilder.DropForeignKey(
                name: "FK_HD_KM",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_TP_DMSP",
                table: "SanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_SP_TSSP",
                table: "ThongSoSanPham");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_MaDM",
                table: "SanPham");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_MaKM",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_DonNhapHang_MaNV",
                table: "DonNhapHang");

            migrationBuilder.DropColumn(
                name: "MaDM",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "SoSeri",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "MatKhau",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "MaKM",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "NgayThanhToan",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "TienDatCoc",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "MaNV",
                table: "DonNhapHang");

            migrationBuilder.RenameColumn(
                name: "MaSP",
                table: "ThongSoSanPham",
                newName: "MaTP");

            migrationBuilder.RenameIndex(
                name: "IX_ThongSoSanPham_MaSP",
                table: "ThongSoSanPham",
                newName: "IX_ThongSoSanPham_MaTP");

            migrationBuilder.RenameColumn(
                name: "MaSP",
                table: "ChiTietDonNhapHang",
                newName: "MaTP");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietDonNhapHang_MaSP",
                table: "ChiTietDonNhapHang",
                newName: "IX_ChiTietDonNhapHang_MaTP");

            migrationBuilder.AddColumn<string>(
                name: "DatHang",
                table: "TinhTrangThanhToan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayThanhToan",
                table: "TinhTrangThanhToan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ThanhToan",
                table: "TinhTrangThanhToan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GiaTP",
                table: "ThanhPhan",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "MaDM",
                table: "ThanhPhan",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoSeri",
                table: "ThanhPhan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayBD",
                table: "KhuyenMai",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayKT",
                table: "KhuyenMai",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Gia",
                table: "ChiTietHoaDon",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "FK_CTDNH_DNH",
                table: "ChiTietDonNhapHang",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThanhPhan_MaDM",
                table: "ThanhPhan",
                column: "MaDM");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonNhapHang_FK_CTDNH_DNH",
                table: "ChiTietDonNhapHang",
                column: "FK_CTDNH_DNH");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonNhapHang_DonNhapHang_FK_CTDNH_DNH",
                table: "ChiTietDonNhapHang",
                column: "FK_CTDNH_DNH",
                principalTable: "DonNhapHang",
                principalColumn: "MaDNH");

            migrationBuilder.AddForeignKey(
                name: "FK_CTDNH_TP",
                table: "ChiTietDonNhapHang",
                column: "MaTP",
                principalTable: "ThanhPhan",
                principalColumn: "MaTP",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TP_DMSP",
                table: "ThanhPhan",
                column: "MaDM",
                principalTable: "DanhMucSanPham",
                principalColumn: "MaDM");

            migrationBuilder.AddForeignKey(
                name: "FK_SP_TSSP",
                table: "ThongSoSanPham",
                column: "MaTP",
                principalTable: "ThanhPhan",
                principalColumn: "MaTP",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
