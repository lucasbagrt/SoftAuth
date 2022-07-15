using SoftAuth.Data.ValueObjects;
using SoftAuth.Model.RequestResponse.Menus;

namespace SoftAuth.Repository.IRepository
{
    public interface IMenuRepository
    {
        Task<IEnumerable<MenuVO>> FindAll();
        Task<MenuVO> FindById(int id);
        Task<IEnumerable<MenuVO>> FindByApplicationHash(string hash);
        Task<MenuVO> Create(CreateRequest model);
        Task<MenuVO> Update(MenuVO vo);
        Task<bool> Delete(int id);
    }
}
