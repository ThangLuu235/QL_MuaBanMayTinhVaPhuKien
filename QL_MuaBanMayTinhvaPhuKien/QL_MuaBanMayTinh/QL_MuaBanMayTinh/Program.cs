using Microsoft.EntityFrameworkCore;
using QL_MuaBanMayTinh.Data;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddDbContext<MayTinhContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QL_MayTinh"));
});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<ISanPhamRepositories,SanPhamRepositories>();
builder.Services.AddScoped<IChucVu, ChucVuRepo>();
builder.Services.AddScoped<IDanhMucSPRepo, DanhMucSPRepo>();
builder.Services.AddScoped<IDonNhapHang, DonNhapHangRepo>();
builder.Services.AddScoped<IHoaDon, HoaDonRepo>();
builder.Services.AddScoped<IKhachHang, KhachHangRepo>();
builder.Services.AddScoped<IKhuyenMai, KhuyenMaiRepo>();
builder.Services.AddScoped<INhaCC, NhaCCRepo>();
builder.Services.AddScoped<INhanVien, NhanVienRepo>();
builder.Services.AddScoped<ISanPhamTPRepo, SanPhamTPRepo>();
builder.Services.AddScoped<IThanhPhanRepo, ThanhPhanRepo>();
builder.Services.AddScoped<ITSKyThuat, TSKyThuatRepo>();
builder.Services.AddScoped<ITSSanPham, TSSanPhamRepo>();
builder.Services.AddScoped<ITTThanhToan, TTThanhToanRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
