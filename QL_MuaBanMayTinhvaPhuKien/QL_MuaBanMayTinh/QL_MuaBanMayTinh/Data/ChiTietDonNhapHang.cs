namespace QL_MuaBanMayTinh.Data
{
    public class ChiTietDonNhapHang
    {
        public string? MaDDH { get; set; }
        public string? MaTP { get; set; }
        public int SoLuong { get; set; }
        public int Gia { get; set; }
        public ThanhPhan ThanhPhan { get; set; }
        public DonNhapHang DonNhapHang { get; set; }
    }
}
