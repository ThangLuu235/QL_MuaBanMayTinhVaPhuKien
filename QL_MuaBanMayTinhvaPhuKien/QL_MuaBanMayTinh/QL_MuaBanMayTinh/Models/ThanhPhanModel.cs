using System.ComponentModel.DataAnnotations;

namespace QL_MuaBanMayTinh.Models
{
    public class ThanhPhanModel
    {
        public string? MaTP { get; set; }
        
        public string? TenTP { get; set; }
        
        public int SLTonKho { get; set; }
        public string? SoSeri { get; set; }
        
        public decimal GiaTP { get; set; }
        public string? MaDM { get; set; }
    }
}
