using QL_MuaBanMayTinh.Data;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.IRepositories
{
    public interface ISanPhamRepositories
    {
        public Task<List<SanPhamModel>> GetAllSanPham();
        public Task<SanPhamModel> GetSanPham(string id);
        public Task<string> AddSanPham(SanPhamModel model);
        public Task UpdateSanPham(string id, SanPhamModel model);
        public Task DeleteSanPham(string id);
        public Task<List<CTSanPham>> GetAllCTSanPham();
        public Task<List<CTSanPham>> GetCTSanPham(string search);
        public Task<List<CTSanPham>> GetCTSanPhamID(string search);
        public Task<List<CTSanPham>> SortSanPhams(string sort);
        public Task<List<CTSanPham>> GetAllCTSanPhamTheoGia(decimal? from, decimal? to);
    }
}
