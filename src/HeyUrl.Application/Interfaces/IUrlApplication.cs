using HeyUrl_Challenge.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeyUrl_Challenge.Application.Interfaces
{
    public interface IUrlApplication
    {
        Task Create(UrlDto dto);
        Task<IEnumerable<UrlDto>> GetAll(string urlBase);
    }
}
