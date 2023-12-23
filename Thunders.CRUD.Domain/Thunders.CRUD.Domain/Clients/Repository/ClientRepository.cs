using Thunders.CRUD.Domain.Clients.Models;

namespace Thunders.CRUD.Domain.Clients.Repository
{
    public interface IClientRepository : IRepository
    {
        /// <summary>
        /// Get Client by Id in the repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Client GetById(Guid id);

        /// <summary>
        /// Add or create Client in the repository
        /// </summary>
        /// <param name="model"></param>
        void Add(Client model);

        /// <summary>
        /// Update all properties of Client in the repository
        /// </summary>
        /// <param name="model"></param>
        void Update(Client model);


        /// <summary>
        /// Delete Client in the repository
        /// </summary>
        /// <param name="model"></param>
        void Delete(Client model);
    }
}
