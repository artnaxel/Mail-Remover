using MailRemoverAPI.Entities;
using MailRemoverAPI.Models.User;

using AutoMapper;
using MailRemoverAPI.Models.Gmail;

namespace MailRemoverAPI.Configurations
{
    public class MapperConfig : AutoMapper.Profile
    {
        public MapperConfig()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();

            CreateMap<Gmail, GmailDto>().ReverseMap();
        }
    }
}
