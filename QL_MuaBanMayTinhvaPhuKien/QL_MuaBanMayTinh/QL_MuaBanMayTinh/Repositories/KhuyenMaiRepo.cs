using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QL_MuaBanMayTinh.Data;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Repositories
{
    public class KhuyenMaiRepo : IKhuyenMai
    {
        private readonly MayTinhContext _context;
        private readonly IMapper _mapper;
        public KhuyenMaiRepo(MayTinhContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddKhuyenMai(KhuyenMaiModel model)
        {
            var newSanPham = _mapper.Map<KhuyenMai>(model);
            _context.KhuyenMais!.Add(newSanPham);
            await _context.SaveChangesAsync();
            return newSanPham.MaKhuyenMai;
        }

        public async Task DeleteKhuyenMai(string id)
        {
            var delete = _context.KhuyenMais!.SingleOrDefault(sp => sp.MaKhuyenMai == id);
            if (delete != null)
            {
                _context.KhuyenMais!.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<KhuyenMaiModel>> GetAllKhuyenMai()
        {
            var sanphams = await _context.KhuyenMais!.ToListAsync();
            return _mapper.Map<List<KhuyenMaiModel>>(sanphams);
        }

        public async Task<KhuyenMaiModel> GetKhuyenMai(string id)
        {
            var sanpham = await _context.KhuyenMais!.FindAsync(id);
            return _mapper.Map<KhuyenMaiModel>(sanpham);
        }

        public async Task UpdateKhuyenMai(string id, KhuyenMaiModel model)
        {
            if (id == model.MaKhuyenMai)
            {
                var update = _mapper.Map<KhuyenMai>(model);
                _context.KhuyenMais!.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}
