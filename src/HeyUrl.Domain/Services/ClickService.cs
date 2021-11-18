using HeyUrl.Domain.Entities;
using HeyUrl.Domain.Services.Interfaces;
using System.Threading.Tasks;

namespace HeyUrl.Domain.Services
{

    public class ClickService : IClickService
    {

        private readonly IClickRepository _repository;
        private readonly IDbHelper _dbHelper;

        public ClickService(IClickRepository repo, IDbHelper dbHelper)
        {
            _repository = repo;
            _dbHelper = dbHelper;
        }

        public async Task<Url> GetByShortUrl(string shortUrl)
        {
            return await _repository.GetByShortUrl(shortUrl);
        }

        public async Task Create(Click entity)
        {
            await _repository.Create(entity);
        }
    }
}
