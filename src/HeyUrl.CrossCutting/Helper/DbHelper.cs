using HeyUrl_Challenge.CrossCutting.Helper.Interface;
using Npgsql;
using System;

namespace HeyUrl_Challenge.CrossCutting.Helper
{
    public class DbHelper : IDbHelper
    {

        public DbHelper()
        {

        }


        //public Int64 IncrementSequence(string Sequence)
        //{
        //    var query = $"SELECT nextval( 'public.\"{Sequence}\"')";

        //    var result = new NpgsqlParameter("result", NpgsqlTypes.NpgsqlDbType.Integer)
        //    {
        //        Direction = System.Data.ParameterDirection.Output
        //    };

        //    _repository.Database.ExecuteSqlRaw(query, result);

        //    return (Int64)result.Value;
        //}
    }
}
