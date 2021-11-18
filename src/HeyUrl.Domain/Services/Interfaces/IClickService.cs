using HeyUrl.Domain.Entities;
using System.Threading.Tasks;

namespace HeyUrl.Domain.Services.Interfaces
{
    public interface IClickService
    {
        Task<Url> GetByShortUrl(string shortUrl);
        Task Create(Click entity);
    }
}
