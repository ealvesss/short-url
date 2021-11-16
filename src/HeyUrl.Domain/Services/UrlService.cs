using HeyUrl.Domain.Entities;
using HeyUrl.Domain.Services.Interfaces;
using HeyUrl_Challenge.Domain.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeyUrl.Domain
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRepository _repository;
        private readonly IDbHelper _dbHelper;
        private readonly IUrlShortHelper _shortUrl;

        public UrlService(IUrlRepository repo, IDbHelper dbHelper, IUrlShortHelper shortUrl)
        {
            _repository = repo;
            _dbHelper = dbHelper;   
            _shortUrl = shortUrl;
        }

        public async Task<bool> Create(Url entity)
        {
            var seq = await _dbHelper.IncrementSequence("sequence-Url");
            entity.ShortUrl = _shortUrl.ShortUrl(seq);

            return await _repository.Create(entity);
        }

        public async Task<IEnumerable<Url>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
