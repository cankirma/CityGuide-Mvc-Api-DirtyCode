using System.Linq;
using api.Controllers;
using api.Dtos;
using api.Models;
using AutoMapper;

namespace api.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City, CityForListDto>().ForMember(destinationMember => destinationMember.PhotoUrl,
                memberOptions =>
                {
                    memberOptions.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                });
            CreateMap<City, CityForDetailDto>();

            CreateMap<Photo, PhotoForCreationDto>();
            CreateMap<PhotoForReturnDto, Photo>();
        }
    }
}