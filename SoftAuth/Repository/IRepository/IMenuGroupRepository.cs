using SoftAuth.Data.ValueObjects;

namespace SoftAuth.Repository.IRepository
{
    public interface IMenuGroupRepository
    {
        Task<IEnumerable<MenuGroupVO>> FindAll();
        Task<MenuGroupVO> FindById(int id);
        Task<IEnumerable<MenuGroupVO>> FindByApplicationHash(string hash);
        Task<MenuGroupVO> Create(MenuGroupVO vo);
        Task<MenuGroupVO> Update(MenuGroupVO vo);
        Task<bool> Delete(int id);
    }
}
