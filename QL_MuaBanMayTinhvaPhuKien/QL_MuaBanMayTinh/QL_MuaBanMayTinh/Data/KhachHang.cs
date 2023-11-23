using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_MuaBanMayTinh.Data
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        public string? MaKH { get; set; }
        public string? TenKH { get; set; }
        public string? GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? DiaChi { get; set; }
        public string? DienThoai { get; set; }
        public string? Email { get; set; }
        public string? MatKhau { get; set; }
        public ICollection<HoaDon> HoaDons { get; set; }
        public KhachHang() { 
            HoaDons = new List<HoaDon>();
        }
    }
}
