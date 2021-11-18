using HeyUrl.Domain.Entities;
using HeyUrl.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeyUrl.Domain
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRepository _repository;
        private readonly IDbHelper _dbHelper;
        private readonly IUrlShortHelper _shortUrl;
        const string SEQUENCE = "sequence-Url";

        public UrlService(IUrlRepository repo, IDbHelper dbHelper, IUrlShortHelper shortUrl)
        {
            _repository = repo;
            _dbHelper = dbHelper;
            _shortUrl = shortUrl;
        }

        public async Task<bool> Create(Url entity)
        {
            var seq = await _dbHelper.IncrementSequence(SEQUENCE);
            entity.ShortUrl = _shortUrl.ShortUrl(seq);

            return await _repository.Create(entity);
        }

        public async Task<List<Url>> GetAll()
        {
            return await _repository.GetAll();
        }


        public async Task<Url> GetByShortUrl(string shortUrl)
        {
            return await _repository.GetByShortUrl(shortUrl);
        }

        public async Task<Url> GetById(Guid urlId)
        {
            var result = await _repository.GetById(urlId);



            return result;
        }
    }
}
