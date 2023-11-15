using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.IRepositories
{
    public interface IHoaDon
    {
        public Task<List<HoaDonModel>> GetAllHoaDon();
        public Task<HoaDonModel> GetHoaDon(string id);
        public Task<string> AddHoaDon(HoaDonModel model);
        public Task UpdateHoaDon(string id, HoaDonModel model);
        public Task DeleteHoaDon(string id);
    }
}
