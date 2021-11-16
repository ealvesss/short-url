using HeyUrl.Domain.Entities;
using HeyUrl_Challenge.Application.Dtos;
using System.Threading.Tasks;

namespace HeyUrl_Challenge.Application.Interfaces
{
    public interface IClickApplication
    {
        Task<ClickRequestDto> InsertClick(string shortUrl);
        Task Update(Click entitie);

    }
}
