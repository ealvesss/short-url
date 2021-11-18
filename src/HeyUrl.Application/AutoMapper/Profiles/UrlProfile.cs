using AutoMapper;
using HeyUrl.Domain.Entities;
using HeyUrl.Application.Dtos;
using HeyUrl.Application.AutoMapper.Profiles.Resolvers;

namespace HeyUrl.Application.AutoMapper.Profiles
{
    public class UrlProfile : Profile
    {
        
        public UrlProfile()
        {
            CreateMap<Url, UrlResponseDto>()
                .ForMember(dest => dest.CompleteUrl, opt => opt.MapFrom((src, dest, destMember, context) => new UrlCustomResolver().ConstructFullUrl(src,dest,null,context)));

            CreateMap<UrlRequestDto, Url>();
        }
    }
}
