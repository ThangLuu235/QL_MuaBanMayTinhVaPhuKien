using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QL_MuaBanMayTinh.Data;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Repositories
{
    public class ThanhPhanRepo : IThanhPhanRepo
    {
        private readonly MayTinhContext _context;
        private readonly IMapper _mapper;

        public ThanhPhanRepo(MayTinhContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddThanhPhan(ThanhPhanModel model)
        {
            var newSanPham = _mapper.Map<ThanhPhan>(model);
            _context.ThanhPhans!.Add(newSanPham);
            await _context.SaveChangesAsync();
            return newSanPham.MaTP;
        }

        public async Task DeleteThanhPhan(string id)
        {
            var delete = _context.ThanhPhans!.SingleOrDefault(sp => sp.MaTP == id);
            if (delete != null)
            {
                _context.ThanhPhans!.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ThanhPhanModel>> GetAllThanhPhan()
        {
            var sanphams = await _context.ThanhPhans!.ToListAsync();
            return _mapper.Map<List<ThanhPhanModel>>(sanphams);
        }

        public async Task<ThanhPhanModel> GetThanhPhan(string id)
        {
            var sanpham = await _context.ThanhPhans!.FindAsync(id);
            return _mapper.Map<ThanhPhanModel>(sanpham);
        }

        public async Task UpdateThanhPhan(string id, ThanhPhanModel model)
        {
            if (id == model.MaTP)
            {
                var update = _mapper.Map<ThanhPhan>(model);
                _context.ThanhPhans!.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}
