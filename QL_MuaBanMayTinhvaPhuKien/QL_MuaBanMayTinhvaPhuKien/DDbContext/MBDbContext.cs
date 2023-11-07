using Microsoft.EntityFrameworkCore;
using QL_MuaBanMayTinhvaPhuKien.Model;

namespace QL_MuaBanMayTinhvaPhuKien.DDbContext
{
	public class MBDbContext : DbContext
	{
		public MBDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; }
		// Khai báo thêm DbSet cho các lớp model 
		public DbSet<ThongSoSanPham> ThongSoSanPhams { get; set; }
		public DbSet<NhaSanXuat> NhaSanXuats { get; set; }
		public DbSet<SanPham> SanPhams { get; set; }
		public DbSet<ChucVu> ChucVus { get; set; }
		public DbSet<NhanVien> NhanViens { get; set; }
		public DbSet<KhachHang> KhachHangs { get; set; }
		public DbSet<NhaCungCap> NhaCungCaps { get; set; }
		public DbSet<CungUng> CungUngs { get; set; }
		public DbSet<HoaDon> HoaDons { get; set; }
		public DbSet<DonHang> DonHangs { get; set; }
		public DbSet<ThanhPhan> ThanhPhans { get; set; }
        public DbSet<SanPhamThanhPhan> SanPhamThanhPhans { get; set; }
    }
}
