using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QL_MuaBanMayTinh.Data;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Repositories
{
    public class ChucVuRepo : IChucVu
    {
        private readonly MayTinhContext _context;
        private readonly IMapper _mapper;
        public ChucVuRepo(MayTinhContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddChucVu(ChucVuModel model)
        {
            var newSanPham = _mapper.Map<ChucVu>(model);
            _context.ChucVus!.Add(newSanPham);
            await _context.SaveChangesAsync();
            return newSanPham.MaChucVu;
        }

        public async Task DeleteChucVu(string id)
        {
            var delete = _context.ChucVus!.SingleOrDefault(sp => sp.MaChucVu == id);
            if (delete != null)
            {
                _context.ChucVus!.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ChucVuModel>> GetAllChucVu()
        {
            var sanphams = await _context.ChucVus!.ToListAsync();
            return _mapper.Map<List<ChucVuModel>>(sanphams);
        }

        public async Task<ChucVuModel> GetChucVu(string id)
        {
            var sanpham = await _context.ChucVus!.FindAsync(id);
            return _mapper.Map<ChucVuModel>(sanpham);
        }

        public async Task UpdateChucVu(string id, ChucVuModel model)
        {
            if (id == model.MaChucVu)
            {
                var update = _mapper.Map<ChucVu>(model);
                _context.ChucVus!.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}
