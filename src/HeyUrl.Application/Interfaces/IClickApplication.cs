using HeyUrl.Application.Dtos;
using HeyUrl.Domain.Entities;
using System.Threading.Tasks;

namespace HeyUrl.Application.Interfaces
{
    public interface IClickApplication
    {
        Task<UrlResponseDto> Create(ClickRequestDto dto);

    }
}
