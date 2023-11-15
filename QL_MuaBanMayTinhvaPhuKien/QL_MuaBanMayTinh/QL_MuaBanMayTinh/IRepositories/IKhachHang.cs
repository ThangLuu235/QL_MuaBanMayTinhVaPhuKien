using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.IRepositories
{
    public interface IKhachHang
    {
        public Task<List<KhachHangModel>> GetAllKhachHang();
        public Task<KhachHangModel> GetKhachHang(string id);
        public Task<string> AddKhachHang(KhachHangModel model);
        public Task UpdateKhachHang(string id, KhachHangModel model);
        public Task DeleteKhachHang(string id);
    }
}
