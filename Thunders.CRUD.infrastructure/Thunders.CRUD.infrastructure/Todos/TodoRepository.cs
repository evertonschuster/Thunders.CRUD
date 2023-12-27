using Thunders.CRUD.Domain.Todos.Models;
using Thunders.CRUD.Domain.Todos.Repositories;

namespace Thunders.CRUD.infrastructure.Todos
{
    internal sealed class TodoRepository(ThunderContext context) : Repository<Todo>(context), ITodoRepository
    {
    }
}
