using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.IRepositories
{
    public interface INhaCC
    {
        public Task<List<NhaCCModel>> GetAllNhaCC();
        public Task<NhaCCModel> GetNhaCC(string id);
        public Task<string> AddNhaCC(NhaCCModel model);
        public Task UpdateNhaCC(string id, NhaCCModel model);
        public Task DeleteNhaCC(string id);
    }
}
