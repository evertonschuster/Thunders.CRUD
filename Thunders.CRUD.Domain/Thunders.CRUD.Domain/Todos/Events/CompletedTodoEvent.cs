using Thunders.CRUD.Domain.Commoms;

namespace Thunders.CRUD.Domain.Todos.Events
{
    public class CompletedTodoEvent : Event
    {
        public CompletedTodoEvent(Guid aggregateId) : base(aggregateId)
        {
        }
    }
}
