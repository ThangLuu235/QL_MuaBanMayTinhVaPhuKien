using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QL_MuaBanMayTinh.Data
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        public string? MaSP { get; set; } // Khóa chính
        [MaxLength(300)]
        public string? TenSanPham { get; set; }
        
        public string? MoTa { get; set; }
        [Range(0, int.MaxValue)]
        public decimal Gia { get; set; }
        public string? HinhAnh { get; set; }

        public ICollection<SanPhamThanhPhan> SanPhamThanhPhans { get; set; }
        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }  
        public SanPham()
        {
            SanPhamThanhPhans = new List<SanPhamThanhPhan>();
        }

    }
}
