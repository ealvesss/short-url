using HeyUrl.Domain.Entities;
using HeyUrl.Domain.Helper.Interface;
using HeyUrl.Infra.Context;
using HeyUrl_Challenge.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyUrl_Challenge.Infra.Repositories
{
    public class UrlRepository : IUrlRepository
    {
        private readonly ApplicationContext _repository;
        private readonly IUrlShortHelper _urlHelper;
        public UrlRepository(ApplicationContext context, IUrlShortHelper urlHelper)
        {
            _repository = context;
            _urlHelper = urlHelper;
        }

        public async Task<bool> PersistShortUrl(UrlEntity entity)
        {
            _repository.Add(entity);
            entity.ShortUrl = _urlHelper.ShortUrl(entity.Id);
            return await _repository.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<UrlEntity>> GetAll()
        {
            var result = await _repository.Url.ToListAsync();
            return result.Take(10);
        }
    }
}
