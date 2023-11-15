using System.ComponentModel.DataAnnotations;

namespace QL_MuaBanMayTinh.Models
{
    public class HoaDonModel
    {
        public string? MaHD { get; set; }
        public DateTime NgayMua { get; set; }
        public DateTime NgayNhanHang { get; set; }
        [Range(0, int.MaxValue)]
        public int TongTien { get; set; }
        public string? HinhThucThanhToan { get; set; }
        public string? MaKH { get; set; }
    }
}
