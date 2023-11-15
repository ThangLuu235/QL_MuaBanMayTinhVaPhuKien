using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QL_MuaBanMayTinh.Data;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Repositories
{
    public class DanhMucSPRepo : IDanhMucSPRepo
    {
        private readonly MayTinhContext _context;
        private readonly IMapper _mapper;
        public DanhMucSPRepo(MayTinhContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddDanhMucSP(DanhMucSPModel model)
        {
            var newSanPham = _mapper.Map<DanhMucSanPham>(model);
            _context.DanhMucSanPhams!.Add(newSanPham);
            await _context.SaveChangesAsync();
            return newSanPham.MaDM;
        }

        public async Task DeleteDanhMucSP(string id)
        {
            var delete = _context.DanhMucSanPhams!.SingleOrDefault(sp => sp.MaDM == id);
            if (delete != null)
            {
                _context.DanhMucSanPhams!.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DanhMucSPModel>> GetAllDanhMucSP()
        {
            var sanphams = await _context.DanhMucSanPhams!.ToListAsync();
            return _mapper.Map<List<DanhMucSPModel>>(sanphams);
        }

        public async Task<DanhMucSPModel> GetDanhMucSP(string id)
        {
            var sanpham = await _context.DanhMucSanPhams!.FindAsync(id);
            return _mapper.Map<DanhMucSPModel>(sanpham);
        }

        public async Task UpdateDanhMucSP(string id, DanhMucSPModel model)
        {
            if (id == model.MaDM)
            {
                var update = _mapper.Map<DanhMucSanPham>(model);
                _context.DanhMucSanPhams!.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}
