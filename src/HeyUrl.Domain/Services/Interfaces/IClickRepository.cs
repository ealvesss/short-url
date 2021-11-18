using HeyUrl.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace HeyUrl.Domain.Services.Interfaces
{
    public interface IClickRepository
    {
        Task<Click> GetByUrlId(Guid UrlId);
        Task<Url> GetByShortUrl(string shortUrl);
        Task<bool> Create(Click entity);
    }
}
