using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QL_MuaBanMayTinh.Data;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Repositories
{
    public class DonNhapHangRepo : IDonNhapHang
    {
        private readonly MayTinhContext _context;
        private readonly IMapper _mapper;
        public DonNhapHangRepo(MayTinhContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddDonNhapHang(DonNhapModel model)
        {
            var newSanPham = _mapper.Map<DonNhapHang>(model);
            _context.DonNhapHangs!.Add(newSanPham);
            await _context.SaveChangesAsync();
            return newSanPham.MaDNH;
        }

        public async Task DeleteDonNhapHang(string id)
        {
            var delete = _context.DonNhapHangs!.SingleOrDefault(sp => sp.MaDNH == id);
            if (delete != null)
            {
                _context.DonNhapHangs!.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DonNhapModel>> GetAllDonNhapHang()
        {
            var sanphams = await _context.DonNhapHangs!.ToListAsync();
            return _mapper.Map<List<DonNhapModel>>(sanphams);
        }

        public async Task<DonNhapModel> GetDonNhapHang(string id)
        {
            var sanpham = await _context.DonNhapHangs!.FindAsync(id);
            return _mapper.Map<DonNhapModel>(sanpham);
        }

        public async Task UpdateDonNhapHang(string id, DonNhapModel model)
        {
            if (id == model.MaDNH)
            {
                var update = _mapper.Map<DonNhapHang>(model);
                _context.DonNhapHangs!.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}
