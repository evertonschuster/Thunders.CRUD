using Thunders.CRUD.Domain.Commoms;
using Thunders.CRUD.Domain.Todos.Models;

namespace Thunders.CRUD.Domain.Todos.Repositories
{
    public interface ITodoRepository : IRepository
    {
        /// <summary>
        /// Get Todo by Id in the repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Todo? GetById(Guid id);

        /// <summary>
        /// Add or create Todo in the repository
        /// </summary>
        /// <param name="model"></param>
        void Add(Todo model);

        /// <summary>
        /// Update all properties of Todo in the repository
        /// </summary>
        /// <param name="model"></param>
        void Update(Todo model);


        /// <summary>
        /// Delete Todo in the repository
        /// </summary>
        /// <param name="model"></param>
        void Delete(Todo model);
    }
}