using HeyUrl.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeyUrl.Application.Interfaces
{
    public interface IUrlApplication
    {
        Task<string> Create(UrlRequestDto dto);
        Task<IEnumerable<UrlResponseDto>> GetAll(string urlBase);
        Task<UrlResponseDto> GetById(Guid urlId);
    }
}
