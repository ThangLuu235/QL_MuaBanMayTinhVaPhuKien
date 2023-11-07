using System.ComponentModel.DataAnnotations;

namespace QL_MuaBanMayTinh.Models
{
    public class SanPhamModel
    {
        public string? MaSP { get; set; } // Khóa chính
        [MaxLength(300)]
        public string? TenSanPham { get; set; }

        public string? MoTa { get; set; }
        [Range(0, int.MaxValue)]
        public decimal Gia { get; set; }
        public string? HinhAnh { get; set; }
    }
}
