using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QL_MuaBanMayTinh.Data;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;
using System;

namespace QL_MuaBanMayTinh.Repositories
{
    public class SanPhamTPRepo : ISanPhamTPRepo
    {
        private readonly MayTinhContext _context;
        private readonly IMapper _mapper;

        public SanPhamTPRepo(MayTinhContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddSPTP(SanPhamThanhPhamModel model)
        {
            var newSanPham = _mapper.Map<SanPhamThanhPhan>(model);
            _context.SanPhamThanhPhans!.Add(newSanPham);
            await _context.SaveChangesAsync();
            return newSanPham.MaSP + newSanPham.MaTP;
        }

        public async Task DeleteSPTP(string masp, string matp)
        {
            var delete = _context.SanPhamThanhPhans!.SingleOrDefault(sp => sp.MaSP == masp && sp.MaTP==matp);
            if (delete != null)
            {
                _context.SanPhamThanhPhans!.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<SanPhamThanhPhamModel>> GetAllSPTP()
        {
            var sanphams = await _context.SanPhamThanhPhans!.ToListAsync();
            return _mapper.Map<List<SanPhamThanhPhamModel>>(sanphams);
        }

        public async Task<SanPhamThanhPhamModel> GetSPTP(string masp, string matp)
        {
            var sanpham = await _context.SanPhamThanhPhans!
            .Where(sp => sp.MaSP == masp && sp.MaTP == matp)
            .FirstOrDefaultAsync();
            return _mapper.Map<SanPhamThanhPhamModel>(sanpham);
        }

        public async Task<SanPhamThanhPhamModel> GetSPTPtheoSP(string masp)
        {
            var sanpham = await _context.SanPhamThanhPhans!
           .Where(sp => sp.MaSP == masp)
           .FirstOrDefaultAsync();
            return _mapper.Map<SanPhamThanhPhamModel>(sanpham);
        }

        public async Task UpdateSPTP(string masp, string matp, SanPhamThanhPhamModel model)
        {
            if (masp == model.MaSP && matp==model.MaTP)
            {
                var update = _mapper.Map<SanPhamThanhPhan>(model);
                _context.SanPhamThanhPhans!.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}
