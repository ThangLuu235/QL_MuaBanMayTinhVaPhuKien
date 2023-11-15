using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_MuaBanMayTinh.Data
{
    [Table("ThongSoKyThuat")]
    public class ThongSoKyThuat
    {
        [Key]
        public string? MaThongSo { get; set; }
        public string? TenThongSo { get; set; }
        public ICollection<ThongSoSanPham> ThongSoSanPhams { get; set; }    
        public ThongSoKyThuat()
        {
            ThongSoSanPhams = new List<ThongSoSanPham>();
        }
    }
}
