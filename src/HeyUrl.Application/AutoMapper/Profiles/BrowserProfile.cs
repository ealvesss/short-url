using AutoMapper;
using HeyUrl.Application.Dtos;
using HeyUrl.Domain.Entities;

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
