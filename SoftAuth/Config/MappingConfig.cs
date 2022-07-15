using AutoMapper;
using SoftAuth.Data.ValueObjects;
using SoftAuth.Model;

namespace SoftAuth.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => 
            {
                config.CreateMap<UserVO, User>().ReverseMap();
                config.CreateMap<UserLogVO, UserLog>().ReverseMap();
                config.CreateMap<ApplicationVO, Application>().ReverseMap();
                config.CreateMap<MenuVO, Menu>().ReverseMap();
                config.CreateMap<MenuGroupVO, MenuGroup>().ReverseMap();
                config.CreateMap<ApplicationUserVO, ApplicationUser>().ReverseMap();
                config.CreateMap<UserProfileVO, UserProfile>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
