using Thunders.CRUD.Domain.Commoms;

namespace Thunders.CRUD.Domain.Todos.Events
{
    public class CloseTodoEvent : Event
    {
        public CloseTodoEvent(Guid aggregateId) : base(aggregateId)
        {
        }
    }
}
