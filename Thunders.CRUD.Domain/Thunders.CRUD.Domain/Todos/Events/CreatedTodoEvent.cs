using Thunders.CRUD.Domain.Commoms;

namespace Thunders.CRUD.Domain.Todos.Events
{
    public sealed class CreatedTodoEvent : Event
    {
        public CreatedTodoEvent(Guid aggregateId, string title, string description, Guid? clientId) : base(aggregateId)
        {
            Title = title;
            Description = description;
            ClientId = clientId;
        }

        public string Title { get; }

        public string Description { get; }

        public Guid? ClientId { get; }
    }
}
