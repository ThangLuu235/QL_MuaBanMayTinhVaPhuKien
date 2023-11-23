using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace QL_MuaBanMayTinh.Data
{
    
    public class ThongSoSanPham
    {
        public string? MaSP { get; set; }
        public string? MaThongSo { get; set; }
        public string? GiaTriThongSo { get; set; }
        public SanPham SanPham { get; set; }
        public ThongSoKyThuat ThongSoKyThuat { get; set; }
    }
}
