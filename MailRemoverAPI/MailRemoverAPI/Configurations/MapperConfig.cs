using MailRemoverAPI.Entities;
using MailRemoverAPI.Models.User;

using AutoMapper;

namespace MailRemoverAPI.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
        }
    }
}
