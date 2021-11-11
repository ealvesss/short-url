using HeyUrl.Domain.Entities;
using HeyUrl.Domain.Helper.Interface;
using HeyUrl.Domain.Services.Interfaces;
using HeyUrl_Challenge.Domain.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeyUrl.Domain
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRepository _repository;
        private readonly IUrlShortHelper _urlHelper;

        public UrlService(IUrlRepository repo, IUrlShortHelper helper)
        {
            _repository = repo;
            _urlHelper = helper;
        }

        public async Task<bool> Create(UrlEntity entity)
        { 
            return await _repository.PersistShortUrl(entity);
        }

        public async Task<IEnumerable<UrlEntity>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
