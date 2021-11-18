using System;
using System.Threading.Tasks;

namespace HeyUrl.Domain.Services.Interfaces
{
    public interface IDbHelper
    {
        Task<Int64> IncrementSequence(string Sequence);
    }
}
