using SoftAuth.Data.ValueObjects;

namespace SoftAuth.Repository.IRepository
{
    public interface IUserProfileRepository
    {
        Task<bool> Create(UserProfileVO model);
        Task<bool> Delete(UserProfileVO model);
    }
}
