using MailRemoverAPI.Entities;
using MailRemoverAPI.Models.User;
using MailRemoverAPI.Models.Email;

using AutoMapper;

namespace MailRemoverAPI.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, GetUserDto>().ReverseMap();
            CreateMap<User, UserDetailsDto>().ReverseMap();
            CreateMap<Email, EmailDto>().ReverseMap();
        }
    }
}
