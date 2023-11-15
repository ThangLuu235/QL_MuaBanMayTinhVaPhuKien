using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QL_MuaBanMayTinh.Data;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Repositories
{
    public class KhachHangRepo : IKhachHang
    {
        private readonly MayTinhContext _context;
        private readonly IMapper _mapper;
        public KhachHangRepo(MayTinhContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddKhachHang(KhachHangModel model)
        {
            var newSanPham = _mapper.Map<KhachHang>(model);
            _context.KhachHangs!.Add(newSanPham);
            await _context.SaveChangesAsync();
            return newSanPham.MaKH;
        }

        public async Task DeleteKhachHang(string id)
        {
            var delete = _context.KhachHangs!.SingleOrDefault(sp => sp.MaKH == id);
            if (delete != null)
            {
                _context.KhachHangs!.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<KhachHangModel>> GetAllKhachHang()
        {
            var sanphams = await _context.KhachHangs!.ToListAsync();
            return _mapper.Map<List<KhachHangModel>>(sanphams);
        }

        public async Task<KhachHangModel> GetKhachHang(string id)
        {
            var sanpham = await _context.KhachHangs!.FindAsync(id);
            return _mapper.Map<KhachHangModel>(sanpham);
        }

        public async Task UpdateKhachHang(string id, KhachHangModel model)
        {
            if (id == model.MaKH)
            {
                var update = _mapper.Map<KhachHang>(model);
                _context.KhachHangs!.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}
