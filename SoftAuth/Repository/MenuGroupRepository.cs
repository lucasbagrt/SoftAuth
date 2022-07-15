using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SoftAuth.Data.ValueObjects;
using SoftAuth.Helpers;
using SoftAuth.Model;
using SoftAuth.Model.Context;
using SoftAuth.Repository.IRepository;
using SoftAuth.Utils;

namespace SoftAuth.Repository
{
    public class MenuGroupRepository : IMenuGroupRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public MenuGroupRepository(MySQLContext context, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public async Task<MenuGroupVO> Create(MenuGroupVO vo)
        {
            try
            {             
                MenuGroup menu_group = _mapper.Map<MenuGroup>(vo);
                _context.MenuGroup.Add(menu_group);
                await _context.SaveChangesAsync();

                return _mapper.Map<MenuGroupVO>(menu_group);
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
                MenuGroup menu_group = await _context.MenuGroup.Where(t => t.id == id).FirstOrDefaultAsync();
                if (menu_group == null) return false;
                _context.MenuGroup.Remove(menu_group);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                return false;
            }
        }

        public async Task<IEnumerable<MenuGroupVO>> FindAll()
        {
            try
            {
                List<MenuGroup> menus_group = await _context.MenuGroup.ToListAsync();
                return _mapper.Map<List<MenuGroupVO>>(menus_group);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<MenuGroupVO>> FindByApplicationHash(string hash)
        {
            try
            {
                List<MenuGroup> menus_group = await _context.MenuGroup                    
                    .Include(x => x.Application)
                    .Where(t => t.Application.hash == hash).ToListAsync();

                return _mapper.Map<List<MenuGroupVO>>(menus_group);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<MenuGroupVO> FindById(int id)
        {
            try
            {
                MenuGroup menu_group = await _context.MenuGroup.Where(t => t.id == id).FirstOrDefaultAsync();
                return _mapper.Map<MenuGroupVO>(menu_group);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<MenuGroupVO> Update(MenuGroupVO vo)
        {
            try
            {
                MenuGroup menu_group = _mapper.Map<MenuGroup>(vo);
                _context.MenuGroup.Update(menu_group);
                await _context.SaveChangesAsync();

                return _mapper.Map<MenuGroupVO>(menu_group);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
    }
}
