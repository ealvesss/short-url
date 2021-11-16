using AutoMapper;
using HeyUrl.Domain.Entities;
using HeyUrl_Challenge.Application.Dtos;
using HeyUrl_Challenge.Application.Interfaces;
using HeyUrl_Challenge.Domain.Services.Interfaces;
using System.Threading.Tasks;

namespace HeyUrl_Challenge.Application
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

        public async Task<ClickRequestDto> InsertClick(string shortUrl)
        {
            var result =  await _service.InsertClick(shortUrl);
            var dto = _mapper.Map<Click,ClickRequestDto>(result);

            return dto;

        }

        public Task Update(Click entitie)
        {
            throw new System.NotImplementedException();
        }
    }
}
