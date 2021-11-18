using AutoMapper;
using HeyUrl.Application.Dtos;
using HeyUrl.Application.Interfaces;
using HeyUrl.Domain.Entities;
using HeyUrl.Domain.Services.Interfaces;
using System.Threading.Tasks;

namespace HeyUrl.Application
{
    public class ClickApplication : IClickApplication
    {
        private readonly IClickService _service;
        private readonly IMapper _mapper;

        public ClickApplication(IClickService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<UrlResponseDto> Create(ClickRequestDto dto)
        {
            var entity = _mapper.Map<ClickRequestDto, Click>(dto);

            await _service.Create(entity);
            var urlEntity = await _service.GetByShortUrl(dto.ShortUrl);

            var result = _mapper.Map<Url, UrlResponseDto>(urlEntity);

            return result;
        }
    }
}
