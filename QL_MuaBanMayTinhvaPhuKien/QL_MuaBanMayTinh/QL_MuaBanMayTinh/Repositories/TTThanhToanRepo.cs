using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QL_MuaBanMayTinh.Data;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Repositories
{
    public class TTThanhToanRepo : ITTThanhToan
    {
        private readonly MayTinhContext _context;
        private readonly IMapper _mapper;
        public TTThanhToanRepo(MayTinhContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddTTThanhToan(TTThanhToanModel model)
        {
            var newSanPham = _mapper.Map<TinhTrangThanhToan>(model);
            _context.TinhTrangThanhToans!.Add(newSanPham);
            await _context.SaveChangesAsync();
            return newSanPham.MaTTTT;
        }

        public async Task DeleteTTThanhToan(string id)
        {
            var delete = _context.TinhTrangThanhToans!.SingleOrDefault(sp => sp.MaTTTT == id);
            if (delete != null)
            {
                _context.TinhTrangThanhToans!.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TTThanhToanModel>> GetAllTTThanhToan()
        {
            var sanphams = await _context.TinhTrangThanhToans!.ToListAsync();
            return _mapper.Map<List<TTThanhToanModel>>(sanphams);
        }

        public async Task<TTThanhToanModel> GetTTThanhToan(string id)
        {
            var sanpham = await _context.TinhTrangThanhToans!.FindAsync(id);
            return _mapper.Map<TTThanhToanModel>(sanpham);
        }

        public async Task UpdateTTThanhToan(string id, TTThanhToanModel model)
        {
            if (id == model.MaTTTT)
            {
                var update = _mapper.Map<TinhTrangThanhToan>(model);
                _context.TinhTrangThanhToans!.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}
