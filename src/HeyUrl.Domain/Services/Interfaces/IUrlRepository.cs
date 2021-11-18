using HeyUrl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeyUrl.Domain.Services.Interfaces
{
    public interface IUrlRepository
    {
        Task<bool> Create(Url entity);
        Task<List<Url>> GetAll();
        Task<Url> GetByShortUrl(string ShortUrl);
        Task<Url> GetById(Guid urlId);
    }
}
