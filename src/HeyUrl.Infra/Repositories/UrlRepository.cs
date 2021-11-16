using HeyUrl.Domain.Entities;
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

        public UrlRepository(ApplicationContext context)
        {
            _repository = context;
        }

        public async Task<bool> Create(Url entity)
        {
            _repository.Add(entity);
            return _repository.SaveChanges() > 0;
        }

        public async Task<IEnumerable<Url>> GetAll()
        {
            
            var result = await _repository.Url.Include(c => c.Click).ToListAsync();

            return result.Take(10);
        }
    }
}

