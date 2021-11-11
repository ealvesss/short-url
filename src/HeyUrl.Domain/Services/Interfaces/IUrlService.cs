using HeyUrl.Domain.Entities;
using HeyUrl_Challenge.Domain.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeyUrl.Domain.Services.Interfaces
{
    public interface IUrlService
    {
        Task<bool> Create(UrlEntity entity);
        Task<IEnumerable<UrlEntity>> GetAll();
    }
}
