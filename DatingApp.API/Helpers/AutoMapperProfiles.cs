using AutoMapper;
using DatingApp.API.Models;
using DatingApp.API.DTO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDTO>()
                .ForMember(dest => dest.PhotoUrl, opt => 
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.Age, opt =>
                opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
                    
            CreateMap<User, UserForDetailDTO>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                 opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                 .ForMember(dest => dest.Age, opt =>
                opt.MapFrom(src => src.DateOfBirth.CalculateAge()));

            CreateMap<Photo, PhotosForDetailDTO>();
        }
    }
}