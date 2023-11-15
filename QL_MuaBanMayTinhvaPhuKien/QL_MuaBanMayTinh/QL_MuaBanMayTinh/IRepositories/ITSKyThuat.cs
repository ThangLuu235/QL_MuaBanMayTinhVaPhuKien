using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.IRepositories
{
    public interface ITSKyThuat
    {
        public Task<List<TSKyThuatModel>> GetAllTKKyThuat();
        public Task<TSKyThuatModel> GetTKKyThuat(string id);
        public Task<string> AddTKKyThuat(TSKyThuatModel model);
        public Task UpdateTKKyThuat(string id, TSKyThuatModel model);
        public Task DeleteTKKyThuat(string id);
    }
}
