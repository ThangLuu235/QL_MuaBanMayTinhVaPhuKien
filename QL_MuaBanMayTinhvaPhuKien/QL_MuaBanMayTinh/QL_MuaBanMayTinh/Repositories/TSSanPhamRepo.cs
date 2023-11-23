using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QL_MuaBanMayTinh.Data;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Repositories
{
    public class TSSanPhamRepo : ITSSanPham
    {
        private readonly MayTinhContext _context;
        private readonly IMapper _mapper;

        public TSSanPhamRepo(MayTinhContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddTSSanPham(TSSanPhamModel model)
        {
            var newSanPham = _mapper.Map<ThongSoSanPham>(model);
            _context.ThongSoSanPhams!.Add(newSanPham);
            await _context.SaveChangesAsync();
            return newSanPham.MaSP + newSanPham.MaThongSo;
        }

        public async Task DeleteTSSanPham(string matp, string mats)
        {
            var delete = _context.ThongSoSanPhams!.SingleOrDefault(sp => sp.MaSP == matp && sp.MaThongSo == mats);
            if (delete != null)
            {
                _context.ThongSoSanPhams!.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TSSanPhamModel>> GetAllTSSanPham()
        {
            var sanphams = await _context.ThongSoSanPhams!.ToListAsync();
            return _mapper.Map<List<TSSanPhamModel>>(sanphams);
        }

        public async Task<TSSanPhamModel> GetTSSanPham(string matp, string mats)
        {
            var sanpham = await _context.ThongSoSanPhams!
            .Where(sp => sp.MaSP == matp && sp.MaThongSo == mats)
            .FirstOrDefaultAsync();
            return _mapper.Map<TSSanPhamModel>(sanpham);
        }

        public async Task UpdateTSSanPham(string matp, string mats, TSSanPhamModel model)
        {
            if (matp == model.MaTP && mats == model.MaThongSo)
            {
                var update = _mapper.Map<ThongSoSanPham>(model);
                _context.ThongSoSanPhams!.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}
