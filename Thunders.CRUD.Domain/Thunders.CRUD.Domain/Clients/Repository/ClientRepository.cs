using Thunders.CRUD.Domain.Clients.Models;

namespace Thunders.CRUD.Domain.Clients.Repository
{
    public interface IClientRepository : IRepository
    {
        void Add(Client model);
    }
}
