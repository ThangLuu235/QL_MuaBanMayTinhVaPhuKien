using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.IRepositories
{
    public interface IDonNhapHang
    {
        public Task<List<DonNhapModel>> GetAllDonNhapHang();
        public Task<DonNhapModel> GetDonNhapHang(string id);
        public Task<string> AddDonNhapHang(DonNhapModel model);
        public Task UpdateDonNhapHang(string id, DonNhapModel model);
        public Task DeleteDonNhapHang(string id);
    }
}
