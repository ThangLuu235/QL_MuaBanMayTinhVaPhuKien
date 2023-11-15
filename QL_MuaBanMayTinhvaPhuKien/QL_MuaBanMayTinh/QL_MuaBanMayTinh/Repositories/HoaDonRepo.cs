using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QL_MuaBanMayTinh.Data;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Repositories
{
    public class HoaDonRepo : IHoaDon
    {
        private readonly MayTinhContext _context;
        private readonly IMapper _mapper;
        public HoaDonRepo(MayTinhContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddHoaDon(HoaDonModel model)
        {
            var newSanPham = _mapper.Map<HoaDon>(model);
            _context.HoaDons!.Add(newSanPham);
            await _context.SaveChangesAsync();
            return newSanPham.MaHD;
        }

        public async Task DeleteHoaDon(string id)
        {
            var delete = _context.HoaDons!.SingleOrDefault(sp => sp.MaHD == id);
            if (delete != null)
            {
                _context.HoaDons!.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<HoaDonModel>> GetAllHoaDon()
        {
            var sanphams = await _context.HoaDons!.ToListAsync();
            return _mapper.Map<List<HoaDonModel>>(sanphams);
        }

        public async Task<HoaDonModel> GetHoaDon(string id)
        {
            var sanpham = await _context.HoaDons!.FindAsync(id);
            return _mapper.Map<HoaDonModel>(sanpham);
        }

        public async Task UpdateHoaDon(string id, HoaDonModel model)
        {
            if (id == model.MaHD)
            {
                var update = _mapper.Map<HoaDon>(model);
                _context.HoaDons!.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}
