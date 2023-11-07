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
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMucSanPham>(e =>
            {
                e.ToTable("DanhMucSanPham");
                e.HasKey(dm => dm.MaDM);
            });

            modelBuilder.Entity<ThanhPhan>(e =>
            {
                e.ToTable("ThanhPhan");
                e.HasKey(tp => tp.MaTP);

                e.HasOne(d => d.DanhMucSanPham)
                .WithMany(d => d.ThanhPhans)
                .HasForeignKey(d => d.MaDM)
                .HasConstraintName("FK_TP_DMSP");
                
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
        }
    }

}
