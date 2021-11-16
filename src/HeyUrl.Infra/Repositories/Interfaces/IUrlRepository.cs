using HeyUrl.Domain.Entities;

namespace HeyUrl_Challenge.Infra.Repositories.Interfaces
{
    public interface IUrlRepository
    {
        public void Create(Url entity);
    }
}
