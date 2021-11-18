using HeyUrl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeyUrl.Domain.Services.Interfaces
{
    public interface IUrlService
    {
        Task<bool> Create(Url entity);
        Task<List<Url>> GetAll();
        Task<Url> GetByShortUrl(string shortUrl);
        Task<Url> GetById(Guid urlId);
    }
}
