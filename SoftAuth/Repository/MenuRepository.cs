using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SoftAuth.Data.ValueObjects;
using SoftAuth.Helpers;
using SoftAuth.Model;
using SoftAuth.Model.Context;
using SoftAuth.Model.RequestResponse.Menus;
using SoftAuth.Repository.IRepository;
using SoftAuth.Utils;

namespace SoftAuth.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;        
        private readonly AppSettings _appSettings;

        public MenuRepository(MySQLContext context, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;         
            _appSettings = appSettings.Value;
        }
        public async Task<MenuVO> Create(CreateRequest model)
        {
            try
            {
                var vo = new MenuVO()
                {
                    name = model.name,
                    order = model.order,                    
                    controller_name = model.controller_name,
                    icon = model.icon,
                    menu_group_id = model.menu_group_id                    
                };
                Menu menu = _mapper.Map<Menu>(vo);
                _context.Menu.Add(menu);
                await _context.SaveChangesAsync();
                
                return _mapper.Map<MenuVO>(menu);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Menu menu = await _context.Menu.Where(t => t.id == id).FirstOrDefaultAsync();
                if (menu == null) return false;
                _context.Menu.Remove(menu);
                await _context.SaveChangesAsync();                

                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                return false;
            }
        }

        public async Task<IEnumerable<MenuVO>> FindAll()
        {
            try
            {
                List<Menu> menus = await _context.Menu.ToListAsync();
                return _mapper.Map<List<MenuVO>>(menus);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<MenuVO>> FindByApplicationHash(string hash)
        {
            try
            {
                List<Menu> menus = await _context.Menu
                    .Include(x => x.MenuGroup)
                    .Include(x => x.MenuGroup.Application)
                    .Where(t => t.MenuGroup.Application.hash == hash).ToListAsync();

                return _mapper.Map<List<MenuVO>>(menus);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
        public async Task<MenuVO> FindById(int id)
        {
            try
            {
                Menu menu = await _context.Menu.Where(t => t.id == id).FirstOrDefaultAsync();
                return _mapper.Map<MenuVO>(menu);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<MenuVO> Update(MenuVO vo)
        {
            try
            {
                Menu menu = _mapper.Map<Menu>(vo);
                _context.Menu.Update(menu);
                await _context.SaveChangesAsync();                

                return _mapper.Map<MenuVO>(menu);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }       
    }
}
