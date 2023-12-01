using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.IRepositories
{
    public interface ICTDonNhap
    {
        public Task<List<CTDonNhapHangModel>> GetAllCTDonNhap();
        public Task<CTDonNhapHangModel> GetCTDonNhap(string masp, string madn);
        public Task<List<CTDonNhapHangModel>> GetCTDonNhaptheoSP(string masp);
        public Task<List<CTDonNhapHangModel>> GetCTDonNhaptheoDN(string madn);
        public Task<string> AddCTDonNhap(CTDonNhapHangModel model);
        public Task UpdateCTDonNhap(string masp, string madn, CTDonNhapHangModel model);
        public Task DeleteCTDonNhap(string masp, string madn);
    }
}
