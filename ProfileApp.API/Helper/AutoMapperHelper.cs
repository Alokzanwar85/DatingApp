using AutoMapper;
using ProfileApp.API.Dtos;
using ProfileApp.API.Models;

namespace ProfileApp.API.Helper
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<User,UserDetailsDto>();
            CreateMap<UserDetailsDto,User>();
            CreateMap<PhotoDetailsDto,Photo>();
                     
        }
    }
}