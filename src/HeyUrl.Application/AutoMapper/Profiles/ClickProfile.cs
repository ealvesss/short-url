using AutoMapper;
using HeyUrl.Domain.Entities;
using HeyUrl.Application.Dtos;

namespace HeyUrl.Application.AutoMapper.Profiles
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
