using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace QL_MuaBanMayTinh.Data
{
    
    public class ThongSoSanPham
    {
        public string? MaTP { get; set; }
        public string? MaThongSo { get; set; }
        public string? GiaTriThongSo { get; set; }
        public ThanhPhan ThanhPhan { get; set; }
        public ThongSoKyThuat ThongSoKyThuat { get; set; }
    }
}
