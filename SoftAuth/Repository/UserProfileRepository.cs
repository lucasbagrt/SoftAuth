using AutoMapper;
using Microsoft.Extensions.Options;
using SoftAuth.Data.ValueObjects;
using SoftAuth.Helpers;
using SoftAuth.Model;
using SoftAuth.Model.Context;
using SoftAuth.Repository.IRepository;
using SoftAuth.Utils;

namespace SoftAuth.Repository
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserProfileRepository(MySQLContext context, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public async Task<bool> Create(UserProfileVO vo)
        {
            try
            {
                UserProfile user_profile = _mapper.Map<UserProfile>(vo);

                if (_context.UserProfile.FirstOrDefault(t => t.profile_id == vo.profile_id && t.user_id == vo.user_id && t.application_id == vo.application_id) != null)
                    throw new Exception("Dados ja existentes!");

                _context.UserProfile.Add(user_profile);
                var res = await _context.SaveChangesAsync();

                return res > 0 ? true : false;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(UserProfileVO vo)
        {
            UserProfile user_profile = _mapper.Map<UserProfile>(vo);
            _context.UserProfile.Remove(user_profile);
            var res = await _context.SaveChangesAsync();
            return res > 0 ? true : false;
        }
    }
}
