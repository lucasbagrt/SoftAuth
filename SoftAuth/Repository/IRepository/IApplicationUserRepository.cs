namespace SoftAuth.Repository.IRepository
{
    public interface IApplicationUserRepository
    {
        Task<bool> Create(Model.RequestResponse.Profiles.CreateAppUserRequest model);
        Task<bool> Delete(Model.RequestResponse.Profiles.CreateAppUserRequest model);
    }
}