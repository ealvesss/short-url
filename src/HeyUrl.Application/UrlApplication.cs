using AutoMapper;
using HeyUrl.Domain.Entities;
using HeyUrl.Domain.Services.Interfaces;
using HeyUrl_Challenge.Application.Dtos;
using HeyUrl_Challenge.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyUrl_Challenge.Application
{
    public class UrlApplication : IUrlApplication
    {
        private readonly IUrlService _service;
        private readonly IMapper _mapper;

        public UrlApplication(IUrlService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task Create(UrlRequestDto dto)
        {
            var entity = _mapper.Map<UrlRequestDto, Url>(dto);

            entity.Click = new Click();
            await _service.Create(entity);
        }

        public async Task<IEnumerable<UrlResponseDto>> GetAll(string urlbase)
        {
            var entity = await _service.GetAll();
            var result = _mapper.Map<IEnumerable<Url>, IEnumerable<UrlResponseDto>>(entity, opt => opt.Items["baseUrl"] = urlbase);

            return result ;
        }
    }
}
