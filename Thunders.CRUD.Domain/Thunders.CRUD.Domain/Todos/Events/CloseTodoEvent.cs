using Thunders.CRUD.Domain.Commoms;

namespace Thunders.CRUD.Domain.Todos.Events
{
    public sealed class CloseTodoEvent : Event
    {
        public CloseTodoEvent(Guid aggregateId) : base(aggregateId)
        {
        }
    }
}
