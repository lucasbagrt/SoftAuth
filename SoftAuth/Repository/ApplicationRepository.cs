using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SoftAuth.Data.ValueObjects;
using SoftAuth.Helpers;
using SoftAuth.Model;
using SoftAuth.Model.Context;
using SoftAuth.Model.RequestResponse.Systems;
using SoftAuth.Repository.IRepository;
using SoftAuth.Utils;

namespace SoftAuth.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;        
        private readonly AppSettings _appSettings;

        public ApplicationRepository(MySQLContext context, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;            
            _appSettings = appSettings.Value;
        }
        public async Task<ApplicationVO> Create(CreateRequest model)
        {
            try
            {
                var vo = new ApplicationVO()
                {
                    name = model.name,
                    self_accreditation = model.self_accreditation != null && model.self_accreditation == true ? true : false,
                    hash = Module.Encrypt(model.name)
                };
                Application ap = _mapper.Map<Application>(vo);
                _context.Application.Add(ap);
                await _context.SaveChangesAsync();                
                return _mapper.Map<ApplicationVO>(ap);
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
                Application ap = await _context.Application.Where(t => t.id == id).FirstOrDefaultAsync();
                if (ap == null) return false;
                _context.Application.Remove(ap);
                await _context.SaveChangesAsync();             
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                return false;
            }
        }

        public async Task<IEnumerable<ApplicationVO>> FindAll()
        {
            try
            {
                List<Application> applications = await _context.Application.ToListAsync();
                return _mapper.Map<List<ApplicationVO>>(applications);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApplicationVO> FindByHash(string hash)
        {
            try
            {
                Application ap = await _context.Application.Where(t => t.hash == hash).FirstOrDefaultAsync();
                return _mapper.Map<ApplicationVO>(ap);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApplicationVO> FindById(int id)
        {
            try
            {
                Application ap = await _context.Application.Where(t => t.id == id).FirstOrDefaultAsync();
                return _mapper.Map<ApplicationVO>(ap);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApplicationVO> Update(ApplicationVO vo)
        {
            try
            {
                Application ap = _mapper.Map<Application>(vo);
                _context.Application.Update(ap);
                await _context.SaveChangesAsync();                
                return _mapper.Map<ApplicationVO>(ap);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
    }
}
