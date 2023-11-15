using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QL_MuaBanMayTinh.Data;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Repositories
{
    public class TSKyThuatRepo : ITSKyThuat
    {
        private readonly MayTinhContext _context;
        private readonly IMapper _mapper;
        public TSKyThuatRepo(MayTinhContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddTKKyThuat(TSKyThuatModel model)
        {
            var newSanPham = _mapper.Map<ThongSoKyThuat>(model);
            _context.ThongSoKyThuats!.Add(newSanPham);
            await _context.SaveChangesAsync();
            return newSanPham.MaThongSo;
        }

        public async Task DeleteTKKyThuat(string id)
        {
            var delete = _context.ThongSoKyThuats!.SingleOrDefault(sp => sp.MaThongSo == id);
            if (delete != null)
            {
                _context.ThongSoKyThuats!.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TSKyThuatModel>> GetAllTKKyThuat()
        {
            var sanphams = await _context.ThongSoKyThuats!.ToListAsync();
            return _mapper.Map<List<TSKyThuatModel>>(sanphams);
        }

        public async Task<TSKyThuatModel> GetTKKyThuat(string id)
        {
            var sanpham = await _context.ThongSoKyThuats!.FindAsync(id);
            return _mapper.Map<TSKyThuatModel>(sanpham);
        }

        public async Task UpdateTKKyThuat(string id, TSKyThuatModel model)
        {
            if (id == model.MaThongSo)
            {
                var update = _mapper.Map<ThongSoKyThuat>(model);
                _context.ThongSoKyThuats!.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}
