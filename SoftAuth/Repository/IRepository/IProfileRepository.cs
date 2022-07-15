using SoftAuth.Data.ValueObjects;
using SoftAuth.Model.RequestResponse.Profiles;

namespace SoftAuth.Repository.IRepository
{
    public interface IProfileRepository
    {
        Task<IEnumerable<ProfileVO>> FindAll();
        Task<ProfileVO> FindById(int id);        
        Task<ProfileVO> Create(CreateRequest model);
        Task<ProfileVO> Update(ProfileVO vo);
        Task<bool> Delete(int id);        
    }
}
