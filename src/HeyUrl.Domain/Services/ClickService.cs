using HeyUrl.Domain.Entities;
using HeyUrl_Challenge.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeyUrl_Challenge.Domain.Services
{

    public class ClickService : IClickService
    {

        private readonly IClickRepository _repository;
        private readonly IDbHelper _dbHelper;

        const string SEQUENCE = "sequence-Click";


        public ClickService(IClickRepository repo, IDbHelper dbHelper)
        {
            _repository = repo;
            _dbHelper = dbHelper;
        }

        public async Task<Click> InsertClick(string ShortUrl)
        {
            var entity = await _repository.GetByShortUrl(ShortUrl);
            entity.Clicks = entity.Clicks + 1;
            await Update(entity);

            return entity;
        }

        public async Task Update(Click entity)
        {
            await _repository.Update(entity);
        }

    }
}
