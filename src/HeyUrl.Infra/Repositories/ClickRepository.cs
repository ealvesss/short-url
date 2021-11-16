using HeyUrl.Domain.Entities;
using HeyUrl.Infra.Context;
using HeyUrl_Challenge.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HeyUrl_Challenge.Infra.Repositories
{
    public class ClickRepository : IClickRepository
    {
        private readonly ApplicationContext _ctx;

        public ClickRepository(ApplicationContext repo)
        {
            _ctx = repo;
        }

        public async Task Update(Click entity)
        {
            _ctx.Update(entity);
            await _ctx.SaveChangesAsync();
        }

        public async Task<Click> GetByShortUrl(string ShortUrl)
        {
            return await _ctx.Click.Include(u => u.Url).FirstOrDefaultAsync(x => x.Url.ShortUrl == ShortUrl);
        }
    }
}
