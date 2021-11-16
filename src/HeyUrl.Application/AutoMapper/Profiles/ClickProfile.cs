using AutoMapper;
using HeyUrl.Domain.Entities;
using HeyUrl_Challenge.Application.Dtos;

namespace HeyUrl_Challenge.Application.AutoMapper.Profiles
{
    public class ClickProfile : Profile
    {
        public ClickProfile()
        {
            CreateMap<ClickRequestDto, Click>().ReverseMap();
            CreateMap<ClickReponseDto, Click>().ReverseMap();
        }
    }
}
