using Thunders.CRUD.Domain.Clients.Events;

namespace Thunders.CRUD.Domain.Clients.Models
{
    public class Client : Entity, IAggregateRoot
    {
        public Client(Guid id, Name name, Email email, string profession) : base(id)
        {
            Name = name;
            Email = email;
            Profession = profession;
        }

        public Client(Name name, Email email, string profession)
        {
            Name = name;
            Email = email;
            Profession = profession;
        }

        public Name Name { get; private set; }

        public Email Email { get; private set; }

        public string Profession { get; private set; }


        public void Update(Email email, string profession)
        {
            Email = email;
            Profession = profession;
            UpdatedAt = DateTime.UtcNow;

            var @event = new UpdatedClientEvent(Id, email, profession);
            AddEvent(@event);
        }

        public void Delete()
        {
            DeletedAt = DateTime.UtcNow;

            var @event = new DeletedClientEvent(Id);
            AddEvent(@event);
        }

        public static Client Create(Name name, Email email, string profession)
        {
            var model = new Client(name, email, profession);
            var @event = new CreatedClientEvent(model.Id, name, email, profession);
            model.AddEvent(@event);

            return model;
        }
    }
}
