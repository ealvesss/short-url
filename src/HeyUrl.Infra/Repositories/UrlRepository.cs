﻿using HeyUrl.Domain.Entities;
using HeyUrl.Domain.Services.Interfaces;
using HeyUrl.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyUrl.Infra.Repositories
{
    public class UrlRepository : IUrlRepository
    {
        private readonly ApplicationContext _ctx;

        public UrlRepository(ApplicationContext context)
        {
            _ctx = context;
        }

        public async Task<bool> Create(Url entity)
        {
            _ctx.Add(entity);
            var result = await _ctx.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<Url>> GetAll()
        {
            var result = await _ctx.Url
                                   .Include(u => u.Click)
                                   .ThenInclude(c => c.Platform)
                                   .ThenInclude(p => p.Browser).ToListAsync();

            return result.Take(10).ToList();
        }

        public async Task<Url> GetById(System.Guid urlId)
        {
            return await _ctx.Url.Include(u => u.Click)
                             .ThenInclude(c => c.Platform)
                             .ThenInclude(p => p.Browser)
                             .Where(u => u.Id == urlId).FirstOrDefaultAsync();
        }

        public async Task<Url> GetByShortUrl(string ShortUrl)
        {
            return await _ctx.Url.AsNoTracking()
                                 .Include(u => u.Click)
                                 .ThenInclude(c => c.Platform)
                                 .ThenInclude(p => p.Browser)
                                 .Where(u => u.ShortUrl == ShortUrl).FirstOrDefaultAsync();
        }
    }
}

