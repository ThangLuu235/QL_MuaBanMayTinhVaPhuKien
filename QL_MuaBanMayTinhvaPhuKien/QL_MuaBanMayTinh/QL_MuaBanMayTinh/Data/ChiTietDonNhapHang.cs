namespace QL_MuaBanMayTinh.Data
{
    public class ChiTietDonNhapHang
    {
        public string? MaDDH { get; set; }
        public string? MaSP { get; set; }
        public int SoLuong { get; set; }
        public int Gia { get; set; }
        public SanPham SanPham { get; set; }
        public DonNhapHang DonNhapHang { get; set; }
    }
}
