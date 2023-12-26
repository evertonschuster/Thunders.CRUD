using Thunders.CRUD.Domain.Commoms;

namespace Thunders.CRUD.Domain.Todos.Events
{
    public class DeletedTodoEvent : Event
    {
        public DeletedTodoEvent(Guid aggregateId) : base(aggregateId)
        {
        }
    }
}
