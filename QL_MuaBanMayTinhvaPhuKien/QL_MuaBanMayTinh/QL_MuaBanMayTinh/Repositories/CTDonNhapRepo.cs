using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QL_MuaBanMayTinh.Data;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;
using System;

namespace QL_MuaBanMayTinh.Repositories
{
    public class CTDonNhapRepo:ICTDonNhap
    {
        private readonly MayTinhContext _context;
        private readonly IMapper _mapper;

        public CTDonNhapRepo(MayTinhContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddCTDonNhap(CTDonNhapHangModel model)
        {
            var newSanPham = _mapper.Map<ChiTietDonNhapHang>(model);
            _context.ChiTietDonNhapHangs!.Add(newSanPham);
            await _context.SaveChangesAsync();
            return newSanPham.MaSP + newSanPham.MaDDH;
        }

        public async Task DeleteCTDonNhap(string masp, string madn)
        {
            var delete = _context.ChiTietDonNhapHangs!.SingleOrDefault(sp => sp.MaSP == masp && sp.MaDDH == madn);
            if (delete != null)
            {
                _context.ChiTietDonNhapHangs!.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CTDonNhapHangModel>> GetAllCTDonNhap()
        {
            var sanphams = await _context.ChiTietDonNhapHangs!.ToListAsync();
            return _mapper.Map<List<CTDonNhapHangModel>>(sanphams);
        }

        public async Task<CTDonNhapHangModel> GetCTDonNhap(string masp, string madn)
        {
            var sanpham = await _context.ChiTietDonNhapHangs!
            .Where(sp => sp.MaSP == masp && sp.MaDDH == madn)
            .FirstOrDefaultAsync();
            return _mapper.Map<CTDonNhapHangModel>(sanpham);
        }

        public async Task<List<CTDonNhapHangModel>> GetCTDonNhaptheoDN(string madn)
        {
            var sanpham = await _context.ChiTietDonNhapHangs!
           .Where(sp => sp.MaDDH == madn)
           .ToListAsync();
            return _mapper.Map<List<CTDonNhapHangModel>>(sanpham);
        }

        public async Task<List<CTDonNhapHangModel>> GetCTDonNhaptheoSP(string masp)
        {
            var sanpham = await _context.ChiTietDonNhapHangs!
           .Where(sp => sp.MaSP == masp)
           .ToListAsync();
            return _mapper.Map<List<CTDonNhapHangModel>>(sanpham);
        }

        public async Task UpdateCTDonNhap(string masp, string madn, CTDonNhapHangModel model)
        {
            if (masp == model.MaSP && madn == model.MaDDH)
            {
                var update = _mapper.Map<ChiTietDonNhapHang>(model);
                _context.ChiTietDonNhapHangs!.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}
