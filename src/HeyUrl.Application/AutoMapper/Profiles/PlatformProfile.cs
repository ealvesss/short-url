using AutoMapper;
using HeyUrl.Domain.Entities;
using HeyUrl.Application.Dtos;

namespace HeyUrl.Application.AutoMapper.Profiles
{
    public class PlatformProfile : Profile
    {

        public PlatformProfile()
        {
            CreateMap<PlatformDto, Platform>()
                .ReverseMap();
        }
    }
}
