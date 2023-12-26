using Thunders.CRUD.Domain.Clients.Models;
using Thunders.CRUD.Domain.Clients.Repositories;

namespace Thunders.CRUD.infrastructure.Clients
{
    internal class ClientRepository(ThunderContext context) : Repository<Client>(context), IClientRepository
    {
    }
}
