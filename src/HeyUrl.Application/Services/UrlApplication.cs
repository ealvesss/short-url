using AutoMapper;
using HeyUrl.Domain.Entities;
using HeyUrl.Domain.Services.Interfaces;
using HeyUrl_Challenge.Application.Dtos;
using HeyUrl_Challenge.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeyUrl_Challenge.Application.Services
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

        public async Task Create(UrlDto dto)
        {
            var entity = _mapper.Map<UrlDto, UrlEntity>(dto);
            await _service.Create(entity);
        }

        public async Task<IEnumerable<UrlDto>> GetAll(string urlbase)
        {
            var entity = await _service.GetAll();
            var result = _mapper.Map<IEnumerable<UrlEntity>, IEnumerable<UrlDto>>(entity, opt => opt.Items["baseUrl"] = urlbase);
            return result ;
        }
    }
}
