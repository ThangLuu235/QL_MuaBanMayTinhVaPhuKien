using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.IRepositories
{
    public interface IDanhMucSPRepo
    {
        public Task<List<DanhMucSPModel>> GetAllDanhMucSP();
        public Task<DanhMucSPModel> GetDanhMucSP(string id);
        public Task<string> AddDanhMucSP(DanhMucSPModel model);
        public Task UpdateDanhMucSP(string id, DanhMucSPModel model);
        public Task DeleteDanhMucSP(string id);
    }
}
