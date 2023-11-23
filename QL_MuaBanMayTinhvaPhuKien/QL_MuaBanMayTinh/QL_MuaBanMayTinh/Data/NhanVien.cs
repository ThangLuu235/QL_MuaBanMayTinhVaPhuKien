using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_MuaBanMayTinh.Data
{
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        public string? MaNV { get; set; }
        public string? Hoten { get; set; }
        public string? DiaChi { get; set; }
        public string? DienThoai { get; set; }
        public string? Email { get; set; }
        public string? MatKhau { get; set; }
        public string? MaChucVu { get; set; }
        public ChucVu ChucVu { get; set; }
        public ICollection<TinhTrangThanhToan> TinhTrangThanhToans { get; set; }
        public ICollection<DonNhapHang> DonNhapHangs { get; set; }
        public NhanVien()
        {
            TinhTrangThanhToans = new List<TinhTrangThanhToan>();
            DonNhapHangs= new List<DonNhapHang>();
        }
    }
}
