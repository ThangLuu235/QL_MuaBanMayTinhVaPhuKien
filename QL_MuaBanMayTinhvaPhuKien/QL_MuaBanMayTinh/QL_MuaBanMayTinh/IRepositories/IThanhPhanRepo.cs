using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.IRepositories
{
    public interface IThanhPhanRepo
    {
        public Task<List<ThanhPhanModel>> GetAllThanhPhan();
        public Task<ThanhPhanModel> GetThanhPhan(string id);
        public Task<string> AddThanhPhan(ThanhPhanModel model);
        public Task UpdateThanhPhan(string id, ThanhPhanModel model);
        public Task DeleteThanhPhan(string id);
    }
}
