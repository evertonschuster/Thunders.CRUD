using Thunders.CRUD.Domain.Commoms;

namespace Thunders.CRUD.Domain.Todos.Exceptions
{
    public class TodoNotFoundException : BusinessExeption
    {
        public TodoNotFoundException() : base("Todo not found.", string.Empty)
        {
        }
    }
}
