using AutoMapper;
using ProfileApp.API.Dtos;
using ProfileApp.API.Models;
using System.Linq;



namespace ProfileApp.API.Helper
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<User,UserDetailsDto>().ForMember(f=>f.PhotoUrl,opt => {
                opt.MapFrom(src=>src.Photos.FirstOrDefault(p=>p.isMain).url);
            });
            CreateMap<UserDetailsDto,User>();
            CreateMap<PhotoDetailsDto,Photo>();

                     
        }
    }
}