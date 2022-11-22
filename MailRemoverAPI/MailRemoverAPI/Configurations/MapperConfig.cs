using MailRemoverAPI.Entities;
using MailRemoverAPI.Models.User;
using MailRemoverAPI.Models.Email;

using AutoMapper;
using MailRemoverAPI.Models.Gmail;

namespace MailRemoverAPI.Configurations
{
    public class MapperConfig : AutoMapper.Profile
    {
        public MapperConfig()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, GetUserDto>().ReverseMap();
            CreateMap<User, UserDetailsDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<Email, EmailDto>().ReverseMap();
            CreateMap<Gmail, GmailDto>().ReverseMap();
        }
    }
}
