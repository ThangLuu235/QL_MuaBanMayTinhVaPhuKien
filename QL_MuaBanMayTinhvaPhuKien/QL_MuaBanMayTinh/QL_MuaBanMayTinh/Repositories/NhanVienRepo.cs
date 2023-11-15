using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QL_MuaBanMayTinh.Data;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Repositories
{
    public class NhanVienRepo : INhanVien
    {
        private readonly MayTinhContext _context;
        private readonly IMapper _mapper;
        public NhanVienRepo(MayTinhContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddNhanVien(NhanVienModel model)
        {
            var newSanPham = _mapper.Map<NhanVien>(model);
            _context.NhanViens!.Add(newSanPham);
            await _context.SaveChangesAsync();
            return newSanPham.MaNV;
        }

        public async Task DeleteNhanVien(string id)
        {
            var delete = _context.NhanViens!.SingleOrDefault(sp => sp.MaNV == id);
            if (delete != null)
            {
                _context.NhanViens!.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<NhanVienModel>> GetAllNhanVien()
        {
            var sanphams = await _context.NhanViens!.ToListAsync();
            return _mapper.Map<List<NhanVienModel>>(sanphams);
        }

        public async Task<NhanVienModel> GetNhanVien(string id)
        {
            var sanpham = await _context.NhanViens!.FindAsync(id);
            return _mapper.Map<NhanVienModel>(sanpham);
        }

        public async Task UpdateNhanVien(string id, NhanVienModel model)
        {
            if (id == model.MaNV)
            {
                var update = _mapper.Map<NhanVien>(model);
                _context.NhanViens!.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}
