using AutoMapper;
using HeyUrl.Application.AutoMapper.Profiles.Resolvers;
using HeyUrl.Application.Dtos;
using HeyUrl.Domain.Entities;

namespace HeyUrl.Application.AutoMapper.Profiles
{
    public class UrlProfile : Profile
    {

        public UrlProfile()
        {
            CreateMap<Url, UrlResponseDto>()
                .ForMember(dest => dest.CompleteUrl, opt => opt.MapFrom((src, dest, destMember, context) => new UrlCustomResolver().ConstructFullUrl(src, dest, null, context)))
                .ReverseMap();

            CreateMap<UrlRequestDto, Url>();
        }
    }
}
