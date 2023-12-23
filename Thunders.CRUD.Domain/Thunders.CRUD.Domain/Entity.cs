using System.ComponentModel.DataAnnotations;

namespace Thunders.CRUD.Domain
{
    public class Entity
    {
        [Key]
        public Guid Id { get; protected set; }

        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset? UpdatedAt { get; protected set; }
        public DateTimeOffset? DeletedAt { get; protected set; }

        private readonly List<Event> _events;

        public IReadOnlyCollection<Event> Events => _events.AsReadOnly();

        protected Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTimeOffset.UtcNow;
            _events = [];
        }

        protected Entity(Guid? id = null, DateTimeOffset? createdAt = null, DateTimeOffset? updatedAt = null, List<Event>? events = null)
        {
            Id = id ?? Guid.NewGuid();
            CreatedAt = createdAt ?? DateTimeOffset.UtcNow;
            UpdatedAt = updatedAt;
            _events = events ?? [];
        }

        public IReadOnlyCollection<Event> Notificacoes => _events.AsReadOnly();

        protected void AddEvent(Event @event)
        {
            _events.Add(@event);
        }
    }
}
