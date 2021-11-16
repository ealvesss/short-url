using System;
using System.Threading.Tasks;

namespace HeyUrl_Challenge.Domain.Services.Interfaces
{
    public interface IDbHelper
    {
        Task<Int64> IncrementSequence(string Sequence);
    }
}
