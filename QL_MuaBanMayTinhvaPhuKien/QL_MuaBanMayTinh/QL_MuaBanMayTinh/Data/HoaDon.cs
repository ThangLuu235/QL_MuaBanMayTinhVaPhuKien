using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_MuaBanMayTinh.Data
{
    [Table("HoaDon")]
    public class HoaDon
    {
        [Key]
        public string? MaHD { get; set; }
        public DateTime NgayMua { get; set; }
        public DateTime NgayNhanHang { get; set; }
        [Range(0, int.MaxValue)]
        public int TongTien { get; set; }
        public string? HinhThucThanhToan { get; set; }
        public string? MaKH { get; set; }
        public decimal TienDatCoc { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public string? MaKM { get; set; }
        public KhuyenMai KhuyenMai { get; set; }
        public KhachHang KhachHang { get; set; }
        public ICollection<TinhTrangThanhToan> TinhTrangThanhToans { get; set; }

        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public HoaDon()
        {
            ChiTietHoaDons = new List<ChiTietHoaDon>();
            TinhTrangThanhToans = new List<TinhTrangThanhToan>();
        }
    }
}
