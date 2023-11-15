using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.IRepositories
{
    public interface INhanVien
    {
        public Task<List<NhanVienModel>> GetAllNhanVien();
        public Task<NhanVienModel> GetNhanVien(string id);
        public Task<string> AddNhanVien(NhanVienModel model);
        public Task UpdateNhanVien(string id, NhanVienModel model);
        public Task DeleteNhanVien(string id);
    }
}
