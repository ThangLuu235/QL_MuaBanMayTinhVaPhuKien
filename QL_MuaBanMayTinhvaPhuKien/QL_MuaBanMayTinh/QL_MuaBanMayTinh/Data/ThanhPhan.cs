using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_MuaBanMayTinh.Data
{
    [Table("ThanhPhan")]
    public class ThanhPhan
    {
        [Key]
        public string MaTP { get; set; }
        [Required]
        public string TenTP { get; set; }
        [Range(0, int.MaxValue)]
        public int SLTonKho { get; set; }

        
        public ICollection<SanPhamThanhPhan> SanPhamThanhPhans { get; set; }
        
        public ThanhPhan()
        {
            SanPhamThanhPhans = new List<SanPhamThanhPhan>();
        }

    }
}
