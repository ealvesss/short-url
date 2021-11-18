using AutoMapper;
using HeyUrl.Domain.Entities;
using HeyUrl.Application.Dtos;

namespace HeyUrl.Application.AutoMapper.Profiles
{
    public class BrowserProfile : Profile
    {
        public BrowserProfile()
        {
            CreateMap<BrowserDto, Browser>()
                .ReverseMap();
        }
    }
}
