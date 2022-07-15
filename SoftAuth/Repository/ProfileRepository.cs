using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SoftAuth.Data.ValueObjects;
using SoftAuth.Helpers;
using SoftAuth.Model;
using SoftAuth.Model.Context;
using SoftAuth.Model.RequestResponse.Profiles;
using SoftAuth.Repository.IRepository;
using SoftAuth.Utils;

namespace SoftAuth.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public ProfileRepository(MySQLContext context, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public async Task<ProfileVO> Create(CreateRequest model)
        {
            try
            {
                var vo = new ProfileVO()
                {
                    name = model.name,
                    type = model.type,
                    dashboard = model.dashboard
                };
                Model.Profile profile = _mapper.Map<Model.Profile>(vo);
                _context.Profile.Add(profile);
                await _context.SaveChangesAsync();

                return _mapper.Map<ProfileVO>(profile);
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
                Model.Profile profile = await _context.Profile.Where(t => t.id == id).FirstOrDefaultAsync();
                if (profile == null) return false;
                _context.Profile.Remove(profile);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                return false;
            }
        }

        public async Task<IEnumerable<ProfileVO>> FindAll()
        {

            try
            {
                List<Model.Profile> profiles = await _context.Profile.ToListAsync();
                return _mapper.Map<List<ProfileVO>>(profiles);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProfileVO> FindById(int id)
        {

            try
            {
                Model.Profile profile = await _context.Profile.Where(t => t.id == id).FirstOrDefaultAsync();
                return _mapper.Map<ProfileVO>(profile);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProfileVO> Update(ProfileVO vo)
        {
            try
            {
                Model.Profile profile = _mapper.Map<Model.Profile>(vo);
                _context.Profile.Update(profile);
                await _context.SaveChangesAsync();

                return _mapper.Map<ProfileVO>(profile);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }      
    }
}
