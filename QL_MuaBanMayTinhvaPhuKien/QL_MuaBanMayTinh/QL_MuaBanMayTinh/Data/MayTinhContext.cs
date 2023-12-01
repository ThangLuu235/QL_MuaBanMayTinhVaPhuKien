using Microsoft.EntityFrameworkCore;


namespace QL_MuaBanMayTinh.Data
{
    public class MayTinhContext : DbContext
    {
        public MayTinhContext(DbContextOptions<MayTinhContext> opt) : base(opt) { }
        #region DbSet
        public DbSet<SanPham>? SanPhams { get; set; }
        public DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; }
        public DbSet<ThanhPhan> ThanhPhans { get; set; }
        public DbSet<SanPhamThanhPhan> SanPhamThanhPhans { get; set; }
        public DbSet<ThongSoKyThuat> ThongSoKyThuats { get; set; }
        public DbSet<ThongSoSanPham> ThongSoSanPhams { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<TinhTrangThanhToan> TinhTrangThanhToans { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<DonNhapHang> DonNhapHangs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietDonNhapHang> ChiTietDonNhapHangs { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMucSanPham>(e =>
            {
                e.ToTable("DanhMucSanPham");
                e.HasKey(dm => dm.MaDM);
            });
            modelBuilder.Entity<SanPham>(e =>
            {
                e.ToTable("SanPham");
                e.HasKey(sp => sp.MaSP);

                 e.HasOne(d => d.DanhMucSanPham)
                .WithMany(d => d.SanPhams)
                .HasForeignKey(d => d.MaDM)
                .HasConstraintName("FK_TP_DMSP");
            });
            modelBuilder.Entity<ChucVu>(e =>
            {
                e.ToTable("ChucVu");
                e.HasKey(cv => cv.MaChucVu);
            });

            modelBuilder.Entity<NhanVien>(e =>
            {
                e.ToTable("NhanVien");
                e.HasKey(nv => nv.MaNV);

                e.HasOne(c=>c.ChucVu)
                .WithMany(c=>c.NhanViens)
                .HasForeignKey(c=>c.MaChucVu)
                .HasConstraintName("FK_NV_CV");
            });
            modelBuilder.Entity<HoaDon>(e =>
            {
                e.ToTable("HoaDon");
                e.HasKey(hd => hd.MaHD);

                e.HasOne(kh => kh.KhachHang)
                .WithMany(kh => kh.HoaDons)
                .HasForeignKey(kh => kh.MaKH)
                .HasConstraintName("FK_HD_KH");



            });
            modelBuilder.Entity<TinhTrangThanhToan>(e => {
                e.ToTable("TinhTrangThanhToan");
                e.HasKey(tt => tt.MaTTTT);

                e.HasOne(nv => nv.NhanVien)
                .WithMany(nv => nv.TinhTrangThanhToans)
                .HasForeignKey(nv => nv.MaNV)
                .HasConstraintName("FK_TTTT_NV");

                e.HasOne(hd => hd.HoaDon)
                .WithMany(hd => hd.TinhTrangThanhToans)
                .HasForeignKey(hd => hd.MaHD)
                .HasConstraintName("FK_TTTT_HD");
            });
           
            modelBuilder.Entity<KhachHang>(e =>
            {
                e.ToTable("KhachHang");
                e.HasKey(kh => kh.MaKH);

               
            });
            modelBuilder.Entity<NhaCungCap>(e =>
            {
                e.ToTable("NhaCungCap");
                e.HasKey(ncc => ncc.MaNCC);
            });
            modelBuilder.Entity<DonNhapHang>(e =>
            {
                e.ToTable("DonNhapHang");
                e.HasKey(dnh => dnh.MaDNH);

                e.HasOne(ncc => ncc.NhaCungCap)
                .WithMany(ncc => ncc.DonNhapHangs)
                .HasForeignKey(ncc => ncc.MaNCC)
                .HasConstraintName("FK_DNC_NCC");

                e.HasOne(kh => kh.NhanVien)
                .WithMany(kh => kh.DonNhapHangs)
                .HasForeignKey(kh => kh.MaNV)
                .HasConstraintName("FK_DNH_NV");
            });
            modelBuilder.Entity<ChiTietDonNhapHang>(e =>
            {
                e.ToTable("ChiTietDonNhapHang");
                e.HasKey(ct => new { ct.MaDDH, ct.MaSP });

                e.HasOne(dnh => dnh.DonNhapHang)
                .WithMany(dnh => dnh.ChiTietDonNhapHangs)
                .HasForeignKey(dnh => dnh.MaDDH)
                .HasConstraintName("FK_CTDNH_DNH");

                e.HasOne(tp => tp.SanPham)
                .WithMany(tp => tp.ChiTietDonNhapHangs)
                .HasForeignKey(tp => tp.MaSP)
                .HasConstraintName("FK_CTDNH_TP");
            });
            
            modelBuilder.Entity<ThanhPhan>(e =>
            {
                e.ToTable("ThanhPhan");
                e.HasKey(tp => tp.MaTP);
                
            });
            modelBuilder.Entity<ChiTietHoaDon>(e =>
            {
                e.ToTable("ChiTietHoaDon");
                e.HasKey(ct => new { ct.MaHD, ct.MaSP });

                e.HasOne(sp => sp.SanPham)
                .WithMany(sp => sp.ChiTietHoaDons)
                .HasForeignKey(sp => sp.MaSP)
                .HasConstraintName("FK_CTHD_SP");

                e.HasOne(hd => hd.HoaDon)
                .WithMany(hd => hd.ChiTietHoaDons)
                .HasForeignKey(hd => hd.MaHD)
                .HasConstraintName("FK_CTHD_HD");
            });
            modelBuilder.Entity<SanPhamThanhPhan>(e=>{
                e.ToTable("SanPhamThanhPhan");
                e.HasKey(e => new { e.MaSP, e.MaTP });

                e.HasOne(e => e.SanPham)
                .WithMany(e => e.SanPhamThanhPhans)
                .HasForeignKey(e => e.MaSP)
                .HasConstraintName("FK_SPTP_SP");

                e.HasOne(e => e.ThanhPhan)
                .WithMany(e => e.SanPhamThanhPhans)
                .HasForeignKey(e => e.MaTP)
                .HasConstraintName("FK_SPTP_TP");
            });
            modelBuilder.Entity<ThongSoKyThuat>(e =>
            {
                e.ToTable("ThongSoKyThuat");
                e.HasKey(kt => kt.MaThongSo);
            });
            modelBuilder.Entity<ThongSoSanPham>(e => {
                e.ToTable("ThongSoSanPham");
                e.HasKey(e=> new {e.MaThongSo, e.MaSP});

                e.HasOne(e => e.SanPham)
                .WithMany(e => e.ThongSoSanPhams)
                .HasForeignKey(e => e.MaSP)
                .HasConstraintName("FK_SP_TSSP");

                e.HasOne(e => e.ThongSoKyThuat)
                .WithMany(e => e.ThongSoSanPhams)
                .HasForeignKey(e => e.MaThongSo)
                .HasConstraintName("FK_TSKY_TSSP");
            });
        }
    }

}
