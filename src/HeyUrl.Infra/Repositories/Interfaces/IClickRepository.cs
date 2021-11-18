using HeyUrl.Domain.Entities;
using System.Threading.Tasks;

namespace HeyUrl.Infra.Repositories.Interfaces
{
    public interface IClickRepository
    {
        Task<Click> GetByShortUrl(string ShortUrl);
        Task Update(Click entity);
    }
}
