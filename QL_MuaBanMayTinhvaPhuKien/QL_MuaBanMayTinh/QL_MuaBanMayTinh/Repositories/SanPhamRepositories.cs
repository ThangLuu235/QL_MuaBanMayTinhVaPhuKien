using AutoMapper;
using Microsoft.AspNetCore.Mvc.Formatters;
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

        public async Task<List<CTSanPham>> GetAllCTSanPham()
        {
            var query = from sp in _context.SanPhams.AsQueryable()
                        join sptp in _context.SanPhamThanhPhans on sp.MaSP equals sptp.MaSP
                        join tp in _context.ThanhPhans on sptp.MaTP equals tp.MaTP
                        //where string.IsNullOrEmpty(search) || sp.TenSanPham.Contains(search)
                        select new CTSanPham
                        {
                            MaSP = sp.MaSP,
                            TenSanPham = sp.TenSanPham,
                            MoTa = sp.MoTa,
                            Gia = sp.Gia,
                            HinhAnh = sp.HinhAnh,
                            ThanhPhanCT = new List<ThanhPhanCT>
                            {
                                new ThanhPhanCT
                                {
                                    MaTP = tp.MaTP,
                                    TenTP = tp.TenTP,
                                    SoSeri = tp.SoSeri,
                                    GiaTP = tp.GiaTP
                                }
                            },
                            SPTPCT = new List<SPTPCT>
                            {
                                new SPTPCT
                                {
                                    MaSP = sp.MaSP,
                                    MaTP = tp.MaTP,
                                    SoLuong = sptp.SoLuong
                                }
                            }
                        };

            var groupedResults = query.GroupBy(q => new { q.MaSP, q.TenSanPham, q.MoTa, q.Gia, q.HinhAnh })
                             .Select(group => new CTSanPham
                             {
                                 MaSP = group.Key.MaSP,
                                 TenSanPham = group.Key.TenSanPham,
                                 MoTa = group.Key.MoTa,
                                 Gia = group.Key.Gia,
                                 HinhAnh = group.Key.HinhAnh,
                                 ThanhPhanCT = group.Select(g => g.ThanhPhanCT[0]).ToList(),
                                 SPTPCT = group.Select(g => g.SPTPCT[0]).ToList()
                             });

            return await groupedResults.ToListAsync();

            //return await query.ToListAsync();
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
