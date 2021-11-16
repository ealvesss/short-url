using HeyUrl.Infra.Context;
using HeyUrl_Challenge.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace HeyUrl_Challenge.Infra.Helper
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

            _repository.Database.ExecuteSqlRaw(query, result);

            return (Int64)result.Value;
        }
    }
}
