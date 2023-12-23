using System.ComponentModel.DataAnnotations;

namespace Thunders.CRUD.Domain
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }

        private readonly List<Event> _events;

        protected Entity()
        {
            Id = Guid.NewGuid();
            _events = [];
        }

        public IReadOnlyCollection<Event> Notificacoes => _events.AsReadOnly();

        public void AddEvent(Event @event)
        {
            _events.Add(@event);
        }
    }
}
