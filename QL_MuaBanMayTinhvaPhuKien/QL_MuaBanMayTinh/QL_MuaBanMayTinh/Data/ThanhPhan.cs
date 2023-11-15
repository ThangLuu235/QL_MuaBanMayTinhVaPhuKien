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
        public string SoSeri { get; set; }
        [Range(0, int.MaxValue)]
        public decimal GiaTP { get; set; }
        public string? MaDM { get; set; }
        public DanhMucSanPham DanhMucSanPham { get; set; }
        public ICollection<SanPhamThanhPhan> SanPhamThanhPhans { get; set; }
        public ICollection<ThongSoSanPham> ThongSoSanPhams { get; set; }
        public ICollection<ChiTietDonNhapHang> ChiTietDonNhapHangs { get; set; }
        public ThanhPhan()
        {
            SanPhamThanhPhans = new List<SanPhamThanhPhan>();
        }

    }
}
