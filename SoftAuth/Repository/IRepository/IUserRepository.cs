using SoftAuth.Data.ValueObjects;
using SoftAuth.Model.RequestResponse.Users;

namespace SoftAuth.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserVO>> FindAll();
        Task<UserVO> FindById(int id);
        Task<UserVO> Create(CreateRequest model);
        Task<UserVO> Update(UserVO vo);        
        Task<bool> Delete(int id);
        Task<UserLogVO> SaveLog(LogRequest model);
        Task<UserVO> Authenticate(AuthenticateRequest model);              
    }
}
