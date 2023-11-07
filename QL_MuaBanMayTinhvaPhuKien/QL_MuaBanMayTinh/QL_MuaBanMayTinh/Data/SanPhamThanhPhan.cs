using System.ComponentModel.DataAnnotations.Schema;

namespace QL_MuaBanMayTinh.Data
{
    
    public class SanPhamThanhPhan
    {
        public string MaTP { get; set; }
        public string MaSP { get; set; }
        public int SoLuong { get; set; }
        
        public ThanhPhan ThanhPhan { get; set; }
        public SanPham SanPham { get; set; }    
    }
}
