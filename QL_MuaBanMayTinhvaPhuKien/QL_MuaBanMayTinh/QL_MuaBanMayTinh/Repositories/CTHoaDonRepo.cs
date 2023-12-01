using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QL_MuaBanMayTinh.Data;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;
using System;

namespace QL_MuaBanMayTinh.Repositories
{
    public class CTHoaDonRepo:ICTHoaDon
    {
        private readonly MayTinhContext _context;
        private readonly IMapper _mapper;
        public CTHoaDonRepo(MayTinhContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddCTHoaDon(CTHoaDonModel model)
        {
            var newSanPham = _mapper.Map<ChiTietHoaDon>(model);
            _context.ChiTietHoaDons!.Add(newSanPham);
            await _context.SaveChangesAsync();
            return newSanPham.MaHD + newSanPham.MaSP;
        }

        public async Task DeleteCTHoaDon(string masp, string mahd)
        {
            var delete = _context.ChiTietHoaDons!.SingleOrDefault(sp => sp.MaSP == masp && sp.MaHD == mahd);
            if (delete != null)
            {
                _context.ChiTietHoaDons!.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CTHoaDonModel>> GetAllCTHoaDon()
        {
            var sanphams = await _context.ChiTietHoaDons!.ToListAsync();
            return _mapper.Map<List<CTHoaDonModel>>(sanphams);
        }

        public async Task<CTHoaDonModel> GetCTHoaDon(string masp, string mahd)
        {
            var sanpham = await _context.ChiTietHoaDons!
            .Where(sp => sp.MaSP == masp && sp.MaHD == mahd)
            .FirstOrDefaultAsync();
            return _mapper.Map<CTHoaDonModel>(sanpham);
        }

        public async Task<List<CTHoaDonModel>> GetCTHoaDontheoHD(string mahd)
        {
            var sanpham = await _context.ChiTietHoaDons!
           .Where(sp => sp.MaHD == mahd)
           .ToListAsync();
            return _mapper.Map<List<CTHoaDonModel>>(sanpham);
        }

        public async Task<List<CTHoaDonModel>> GetCTHoaDontheoSP(string masp)
        {
            var sanpham = await _context.ChiTietHoaDons!
          .Where(sp => sp.MaSP == masp)
          .ToListAsync();
            return _mapper.Map<List<CTHoaDonModel>>(sanpham);
        }

        public async Task UpdateCTHoaDon(string masp, string mahd, CTHoaDonModel model)
        {
            if (masp == model.MaSP && mahd == model.MaHD)
            {
                var update = _mapper.Map<ChiTietHoaDon>(model);
                _context.ChiTietHoaDons!.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}
