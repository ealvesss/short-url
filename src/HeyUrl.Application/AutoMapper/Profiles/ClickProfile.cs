using AutoMapper;
using HeyUrl.Application.Dtos;
using HeyUrl.Domain.Entities;

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
