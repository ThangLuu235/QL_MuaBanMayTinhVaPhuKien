using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.IRepositories
{
    public interface ITSSanPham
    {
        public Task<List<TSSanPhamModel>> GetAllTSSanPham();
        public Task<TSSanPhamModel> GetTSSanPham(string matp, string mats);
        public Task<List<TSSanPhamModel>> GetTSSanPhamByIdSP(string masp);
        public Task<List<TSSanPhamModel>> GetTSSanPhamByIdThongSo(string mats);
        public Task<string> AddTSSanPham(TSSanPhamModel model);
        public Task UpdateTSSanPham(string matp, string mats, TSSanPhamModel model);
        public Task DeleteTSSanPham(string matp, string mats);
    }
}
