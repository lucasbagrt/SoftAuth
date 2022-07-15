using AutoMapper;
using SoftAuth.Authorization;
using SoftAuth.Data.ValueObjects;
using SoftAuth.Helpers;
using SoftAuth.Model;
using SoftAuth.Model.Context;
using SoftAuth.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SoftAuth.Model.RequestResponse.Users;
using SoftAuth.Utils;

namespace SoftAuth.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public UserRepository(MySQLContext context, IMapper mapper, IJwtUtils jwtUtils, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }
        public async Task<IEnumerable<UserVO>> FindAll()
        {
            try
            {
                List<User> users = await _context.Users.ToListAsync();
                return _mapper.Map<List<UserVO>>(users);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
        public async Task<UserVO> FindById(int id)
        {
            try
            {
                User user = await _context.Users.Where(t => t.id == id).FirstOrDefaultAsync();
                return _mapper.Map<UserVO>(user);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
        public async Task<UserVO> Create(CreateRequest model)
        {
            try
            {
                var vo = new UserVO()
                {
                    first_name = model.first_name,
                    last_name = model.last_name,
                    username = model.username,
                    email = model.email,
                    password = Module.Encrypt(model.password),
                    Role = model.Role
                };
                User user = _mapper.Map<User>(vo);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                //LOG
                var log = await SaveLog(new LogRequest() { log = string.Format("Usuario: {0}, criado com sucesso", user.username), user_id = user.id });

                return _mapper.Map<UserVO>(user);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
        public async Task<UserVO> Update(UserVO vo)
        {
            try
            {
                User user = _mapper.Map<User>(vo);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                //LOG
                var log = await SaveLog(new LogRequest() { log = string.Format("Usuario: {0}, atualizado com sucesso", user.username), user_id = user.id });

                return _mapper.Map<UserVO>(user);
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
                User user = await _context.Users.Where(t => t.id == id).FirstOrDefaultAsync();
                if (user == null) return false;
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                //LOG
                var log = await SaveLog(new LogRequest() { log = string.Format("Usuario: {0}, excluido com sucesso", user.username), user_id = user.id });

                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                return false;
            }
        }
        public async Task<UserLogVO> SaveLog(LogRequest model)
        {
            try
            {
                var vo = new UserLogVO()
                {
                    log = model.log,
                    user_id = model.user_id,
                    included = DateTime.Now
                };
                UserLog user_log = _mapper.Map<UserLog>(vo);
                _context.UsersLogs.Add(user_log);
                await _context.SaveChangesAsync();
                return _mapper.Map<UserLogVO>(user_log);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
        public async Task<UserVO> Authenticate(AuthenticateRequest model)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.username == model.username);

                if (user == null || !Module.CompareEncryptedString(model.password, user.password))
                    throw new AppException("Usuario ou senha invalidos");

                var jwtToken = _jwtUtils.GenerateJwtToken(user);

                //LOG
                var log = await SaveLog(new LogRequest() { log = string.Format("Usuario: {0}, efetou login", user.username), user_id = user.id });

                return new UserVO(user, jwtToken);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }    
    }
}
