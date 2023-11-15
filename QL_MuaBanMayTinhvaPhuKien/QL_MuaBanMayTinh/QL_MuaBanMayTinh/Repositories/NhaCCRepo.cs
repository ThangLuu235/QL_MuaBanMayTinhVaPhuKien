using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QL_MuaBanMayTinh.Data;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Repositories
{
    public class NhaCCRepo : INhaCC
    {
        private readonly MayTinhContext _context;
        private readonly IMapper _mapper;
        public NhaCCRepo(MayTinhContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddNhaCC(NhaCCModel model)
        {
            var newSanPham = _mapper.Map<NhaCungCap>(model);
            _context.NhaCungCaps!.Add(newSanPham);
            await _context.SaveChangesAsync();
            return newSanPham.MaNCC;
        }

        public async Task DeleteNhaCC(string id)
        {
            var delete = _context.NhaCungCaps!.SingleOrDefault(sp => sp.MaNCC == id);
            if (delete != null)
            {
                _context.NhaCungCaps!.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<NhaCCModel>> GetAllNhaCC()
        {
            var sanphams = await _context.NhaCungCaps!.ToListAsync();
            return _mapper.Map<List<NhaCCModel>>(sanphams);
        }

        public async Task<NhaCCModel> GetNhaCC(string id)
        {
            var sanpham = await _context.NhaCungCaps!.FindAsync(id);
            return _mapper.Map<NhaCCModel>(sanpham);
        }

        public async Task UpdateNhaCC(string id, NhaCCModel model)
        {
            if (id == model.MaNCC)
            {
                var update = _mapper.Map<NhaCungCap>(model);
                _context.NhaCungCaps!.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}
