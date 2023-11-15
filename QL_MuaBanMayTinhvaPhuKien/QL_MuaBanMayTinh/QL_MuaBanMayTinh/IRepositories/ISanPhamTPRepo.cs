using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.IRepositories
{
    public interface ISanPhamTPRepo
    {
        public Task<List<SanPhamThanhPhamModel>> GetAllSPTP();
        public Task<SanPhamThanhPhamModel> GetSPTP(string masp, string matp);
        public Task<string> AddSPTP(SanPhamThanhPhamModel model);
        public Task UpdateSPTP(string masp, string matp, SanPhamThanhPhamModel model);
        public Task DeleteSPTP(string masp, string matp);
    }
}
