using HeyUrl.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeyUrl.Application.Interfaces
{
    public interface IUrlApplication
    {
        Task Create(UrlRequestDto dto);
        Task<IEnumerable<UrlResponseDto>> GetAll(string urlBase);
    }
}
