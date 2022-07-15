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
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;        
        private readonly AppSettings _appSettings;

        public ApplicationUserRepository(MySQLContext context, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;         
            _appSettings = appSettings.Value;
        }
        public async Task<bool> Create(Model.RequestResponse.Profiles.CreateAppUserRequest model)
        {
            try
            {
                UserProfileVO vo;

                int application_id;
                if (int.TryParse(model.application, out application_id))
                {
                    vo = new UserProfileVO()
                    {
                        application_id = application_id,
                        user_id = model.user_id
                    };
                }
                else
                {
                    vo = new UserProfileVO()
                    {
                        application_id = _context.Application.FirstOrDefault(t => t.hash == model.application)?.id ?? 0,
                        user_id = model.user_id
                    };
                }

                if (vo == null || vo.application_id == 0 || vo.user_id == 0)
                    throw new Exception("Dados invalidos!");
                
                if (_context.ApplicationUser.FirstOrDefault(t => t.application_id == vo.application_id && t.user_id == model.user_id) != null)
                    throw new Exception("Dados ja existentes!");
                
                ApplicationUser profile_user = _mapper.Map<ApplicationUser>(vo);
                _context.ApplicationUser.Add(profile_user);
                var res = await _context.SaveChangesAsync();

                return res > 0 ? true : false;                
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> Delete(Model.RequestResponse.Profiles.CreateAppUserRequest model)
        {
            try
            {
                UserProfileVO vo;

                int application_id;
                if (int.TryParse(model.application, out application_id))
                {
                    vo = new UserProfileVO()
                    {
                        application_id = application_id,
                        user_id = model.user_id
                    };
                }
                else
                {
                    vo = new UserProfileVO()
                    {
                        application_id = _context.Application.FirstOrDefaultAsync(t => t.hash == model.application)?.Result.id ?? 0,
                        user_id = model.user_id
                    };
                }

                if (vo == null || vo.application_id == 0 || vo.user_id == 0)
                    throw new Exception("Dados invalidos!");

                ApplicationUser profile_user = _mapper.Map<ApplicationUser>(vo);
                _context.ApplicationUser.Remove(profile_user);
                var res = await _context.SaveChangesAsync();

                return res > 0 ? true : false;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
    }
}
