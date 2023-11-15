using System.ComponentModel.DataAnnotations.Schema;

namespace QL_MuaBanMayTinh.Data
{
    [Table("KhuyenMai")]
    public class KhuyenMai
    {
        public string MaKhuyenMai { get; set; }
        public string TenKhuyenMai { get;set; }
        public int PhanTramGiamGia { get; set; }
        public DateTime NgayBD { get; set; }    
        public DateTime NgayKT { get; set; }
    }
}
