using HeyUrl.Domain.Entities;
using System.Threading.Tasks;

namespace HeyUrl_Challenge.Domain.Services.Interfaces
{
    public interface IClickService
    {
        Task<Click> InsertClick(string ShortUrl);
        Task Update(Click entity);
    }
}
