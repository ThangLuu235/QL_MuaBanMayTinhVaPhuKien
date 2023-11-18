using QL_MuaBanMayTinh.Data;
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
    public class CTSanPham
    {
        public string? MaSP { get; set; } // Khóa chính
        public string? TenSanPham { get; set; }

        public string? MoTa { get; set; }
        public decimal Gia { get; set; }
        public string? HinhAnh { get; set; }
        public List<ThanhPhanCT> ThanhPhanCT { get; set; }
        public List<SPTPCT> SPTPCT { get; set; }

    }
    public class SPTPCT
    {
        public string? MaSP { get; set; }
        public string? MaTP { get; set; }
        public int SoLuong { get; set; }
    }
    public class ThanhPhanCT
    {
        public ThanhPhanCT() { }
        public string? MaTP { get; set; }
        public string? TenTP { get; set; }
        public string? SoSeri { get; set; }
        public decimal GiaTP { get; set; }
    }
}
