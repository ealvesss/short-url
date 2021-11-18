using HeyUrl.Application.Dtos;
using System.Threading.Tasks;

namespace HeyUrl.Application.Interfaces
{
    public interface IClickApplication
    {
        Task<UrlResponseDto> Create(ClickRequestDto dto);

    }
}
