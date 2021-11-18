using AutoMapper;
using HeyUrl.Application.Dtos;
using HeyUrl.Application.Interfaces;
using HeyUrl.Domain.Entities;
using HeyUrl.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyUrl.Application
{
    public class UrlApplication : IUrlApplication
    {
        private readonly IUrlService _service;
        private readonly IMapper _mapper;
        private readonly IUrlShortHelper _urlHelper;
        public UrlApplication(IUrlService service,
            IMapper mapper, IUrlShortHelper urlHelper)
        {
            _service = service;
            _mapper = mapper;
            _urlHelper = urlHelper;
        }

        public async Task<string> Create(UrlRequestDto dto)
        {
            if (string.IsNullOrEmpty(dto.OriginalUrl))
                return "Url should be informed!";

            if (!_urlHelper.IsValidUrl(dto.OriginalUrl))
                return "Invalid Url!";
            
            var entity = _mapper.Map<UrlRequestDto, Url>(dto);

            await _service.Create(entity);

            return "";
        }

        public async Task<IEnumerable<UrlResponseDto>> GetAll(string urlbase)
        {
            var entity = await _service.GetAll();
            var result = _mapper.Map<IEnumerable<Url>, IEnumerable<UrlResponseDto>>(entity, opt => opt.Items["baseUrl"] = urlbase);

            return result;
        }

        public async Task<UrlResponseDto> GetById(Guid urlId)
        {
            var result = await _service.GetById(urlId);

            var dto = _mapper.Map<Url, UrlResponseDto>(result);

            dto.DailyClicks = await AgroupDailyClicks(result);
            dto.BrowserClicks = await AgroupBrowserClicks(result);
            dto.PlatformClicks = await AgroupPlatformClicks(result);

            return dto;
        }

        private async Task<List<UrlDailyClicksDto>> AgroupDailyClicks(Url entity)
        {
            return await Task.FromResult(entity.Click
                                                .GroupBy(dc => dc.ClickedAt.ToString("MMM d, yyy"), (key, values) => new UrlDailyClicksDto()
                                                {
                                                    Stat = (string)key,
                                                    Clicks = (int)values.Count()
                                                }).ToList());
        }

        private async Task<List<UrlBrowserClicksDto>> AgroupBrowserClicks(Url entity)
        {
            return await Task.FromResult(entity.Click
                                               .GroupBy(dc => dc.Platform.Browser.Description, (key, values) => new UrlBrowserClicksDto()
                                               {
                                                   Stat = (string)key,
                                                   Clicks = (int)values.Count()
                                               }).ToList());
        }

        private async Task<List<UrlPlatformClicksDto>> AgroupPlatformClicks(Url entity)
        {
            return await Task.FromResult(entity.Click
                                                .GroupBy(dc => dc.Platform.Description, (key, values) => new UrlPlatformClicksDto()
                                                {
                                                    Stat = (string)key,
                                                    Clicks = (int)values.Count()
                                                }).ToList());
        }
    }
}
