using AutoMapper;
using HeyUrl.Domain.Entities;
using HeyUrl_Challenge.Application.Dtos;

namespace HeyUrl_Challenge.Application.AutoMapper.Profiles
{
    public class UrlProfile : Profile
    {
        
        public UrlProfile()
        {
            CreateMap<Url, UrlRequestDto>()
                .ForMember(dest => dest.ShortUrl, opt => opt.MapFrom((src, dest, destMember, context) => context.Items["baseUrl"] + src.ShortUrl))
                .ReverseMap();

            CreateMap<Url, UrlResponseDto>()
                .ReverseMap();

        }
    }
}
