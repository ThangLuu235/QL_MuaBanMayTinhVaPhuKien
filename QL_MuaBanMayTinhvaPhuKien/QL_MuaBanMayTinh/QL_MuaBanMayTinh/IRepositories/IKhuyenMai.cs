using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.IRepositories
{
    public interface IKhuyenMai
    {
        public Task<List<KhuyenMaiModel>> GetAllKhuyenMai();
        public Task<KhuyenMaiModel> GetKhuyenMai(string id);
        public Task<string> AddKhuyenMai(KhuyenMaiModel model);
        public Task UpdateKhuyenMai(string id, KhuyenMaiModel model);
        public Task DeleteKhuyenMai(string id);
    }
}
