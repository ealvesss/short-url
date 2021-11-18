using AutoMapper;
using HeyUrl.Application.Dtos;
using HeyUrl.Application.Interfaces;
using HeyUrl.Domain.Entities;
using HeyUrl.Domain.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeyUrl.Application
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

        public object InsertClick => throw new System.NotImplementedException();

        public async Task Create(UrlRequestDto dto)
        {
            var entity = _mapper.Map<UrlRequestDto, Url>(dto);

            await _service.Create(entity);
        }

        public async Task<IEnumerable<UrlResponseDto>> GetAll(string urlbase)
        {
            var entity = await _service.GetAll();
            var result = _mapper.Map<IEnumerable<Url>, IEnumerable<UrlResponseDto>>(entity, opt => opt.Items["baseUrl"] = urlbase);

            return result;
        }

    }
}
