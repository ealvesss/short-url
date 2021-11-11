using HeyUrl.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeyUrl_Challenge.Domain.Services.Interfaces
{
    public interface IUrlRepository
    {

        Task<bool> PersistShortUrl(UrlEntity entity);
        Task<IEnumerable<UrlEntity>> GetAll();
    }
}
