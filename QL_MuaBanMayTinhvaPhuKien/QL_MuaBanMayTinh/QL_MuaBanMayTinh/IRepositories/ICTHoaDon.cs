using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.IRepositories
{
    public interface ICTHoaDon
    {
        public Task<List<CTHoaDonModel>> GetAllCTHoaDon();
        public Task<CTHoaDonModel> GetCTHoaDon(string masp, string mahd);
        public Task<List<CTHoaDonModel>> GetCTHoaDontheoSP(string masp);
        public Task<List<CTHoaDonModel>> GetCTHoaDontheoHD(string mahd);
        public Task<string> AddCTHoaDon(CTHoaDonModel model);
        public Task UpdateCTHoaDon(string masp, string mahd, CTHoaDonModel model);
        public Task DeleteCTHoaDon(string masp, string mahd);
    }
}
