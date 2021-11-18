using HeyUrl.Domain.Entities;
using HeyUrl.Infra.Context;
using HeyUrl.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace HeyUrl.Infra.Repositories
{
    public class ClickRepository : IClickRepository
    {
        private readonly ApplicationContext _ctx;

        public ClickRepository(ApplicationContext repo)
        {
            _ctx = repo;
        }

        public async Task<Click> GetByUrlId(Guid UrlId)
        {
            return await _ctx.Click.AsNoTracking()
                .Include(p => p.Platform)
                .ThenInclude(b => b.Browser).FirstOrDefaultAsync(x => x.UrlId == UrlId);
        }

        public async Task<Url> GetByShortUrl(string ShortUrl)
        {
            return await _ctx.Url.AsNoTracking()
                                 .Include(u => u.Click)
                                 .ThenInclude(c => c.Platform)
                                 .ThenInclude(p => p.Browser)
                                 .SingleOrDefaultAsync(u => u.ShortUrl == ShortUrl);
        }

        public async Task<bool> Create(Click entity)
        {
            _ctx.Add(entity);
            return await _ctx.SaveChangesAsync() > 0;
        }
    }
}
