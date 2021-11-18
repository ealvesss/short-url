using HeyUrl.Domain.Entities;

namespace HeyUrl.Infra.Repositories.Interfaces
{
    public interface IUrlRepository
    {
        public void Create(Url entity);
    }
}
