using HeyUrl.Domain.Entities;
using System.Threading.Tasks;

namespace HeyUrl_Challenge.Infra.Repositories.Interfaces
{
    public interface IClickRepository
    {
        Task<Click> GetByShortUrl(string ShortUrl);
        Task Update(Click entity);
    }
}
