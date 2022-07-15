using SoftAuth.Data.ValueObjects;
using SoftAuth.Model.RequestResponse.Systems;

namespace SoftAuth.Repository.IRepository
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<ApplicationVO>> FindAll();
        Task<ApplicationVO> FindById(int id);
        Task<ApplicationVO> FindByHash(string hash);
        Task<ApplicationVO> Create(CreateRequest model);
        Task<ApplicationVO> Update(ApplicationVO vo);
        Task<bool> Delete(int id);                
    }
}
