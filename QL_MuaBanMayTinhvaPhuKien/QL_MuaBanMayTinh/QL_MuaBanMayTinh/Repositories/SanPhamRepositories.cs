using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using QL_MuaBanMayTinh.Data;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;
using System.Formats.Asn1;
using System.Text.RegularExpressions;

namespace QL_MuaBanMayTinh.Repositories
{
    public class SanPhamRepositories : ISanPhamRepositories
    {
        private readonly MayTinhContext _context;
        private readonly IMapper _mapper;

        public SanPhamRepositories(MayTinhContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddSanPham(SanPhamModel model)
        {
           var newSanPham = _mapper.Map<SanPham>(model);
            _context.SanPhams!.Add(newSanPham);
            await _context.SaveChangesAsync();
            return newSanPham.MaSP;
        }

        public async Task DeleteSanPham(string id)
        {
            var delete = _context.SanPhams!.SingleOrDefault(sp => sp.MaSP == id);
            if(delete != null)
            {
                _context.SanPhams!.Remove(delete);
                await _context.SaveChangesAsync();  
            }
        }

        public async Task<List<SanPhamModel>> GetAllSanPham()
        {
            var sanphams = await _context.SanPhams!.ToListAsync();
            return _mapper.Map<List<SanPhamModel>>(sanphams);
        }

        public async Task<SanPhamModel> GetSanPham(string id)
        {
            var sanpham = await _context.SanPhams!.FindAsync(id);
            return _mapper.Map<SanPhamModel>(sanpham);
        }

        public async Task UpdateSanPham(string id, SanPhamModel model)
        {
            if(id == model.MaSP)
            {
                var update = _mapper.Map<SanPham>(model);
                _context.SanPhams!.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}
