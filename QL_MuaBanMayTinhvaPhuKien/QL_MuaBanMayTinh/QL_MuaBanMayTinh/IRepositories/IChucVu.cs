using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.IRepositories
{
    public interface IChucVu
    {
        public Task<List<ChucVuModel>> GetAllChucVu();
        public Task<ChucVuModel> GetChucVu(string id);
        public Task<string> AddChucVu(ChucVuModel model);
        public Task UpdateChucVu(string id, ChucVuModel model);
        public Task DeleteChucVu(string id);
    }
}
