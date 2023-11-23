using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_MuaBanMayTinh.Data
{
    [Table("TinhTrangThanhToan")]
    public class TinhTrangThanhToan
    {
        [Key]
        public string? MaTTTT { get; set; }
        public string? XacNhanDonHang { get; set; }
        public string? TinhTrang { get; set; }
        public string? MaNV { get; set; }
        public string? MaHD { get; set; }
        public NhanVien NhanVien { get; set; }  
        public HoaDon HoaDon { get; set; }

    }
}
