using AutoMapper;
using HeyUrl.Application.Dtos;
using HeyUrl.Domain.Entities;

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
