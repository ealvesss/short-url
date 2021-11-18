using HeyUrl.Domain.Services.Interfaces;
using HeyUrl.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace HeyUrl.Infra.Helper
{
    public class DbHelper : IDbHelper
    {
        public readonly ApplicationContext _repository;

        public DbHelper(ApplicationContext repo)
        {
            _repository = repo;
        }


        public async Task<Int64> IncrementSequence(string Sequence)
        {
            var query = $"SELECT nextval( 'public.\"{Sequence}\"')";

            var result = new NpgsqlParameter("result", NpgsqlTypes.NpgsqlDbType.Integer)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            await _repository.Database.ExecuteSqlRawAsync(query, result);

            return (Int64)result.Value;
        }
    }
}
