using Thunders.CRUD.Domain.Clients.Events;

namespace Thunders.CRUD.Domain.Clients.Models
{
    public class Client(Name name, Email email, string profession) : Entity(), IAggregateRoot
    {
        public Name Name { get; private set; } = name;

        public Email Email { get; private set; } = email;

        public string Profession { get; private set; } = profession;


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
