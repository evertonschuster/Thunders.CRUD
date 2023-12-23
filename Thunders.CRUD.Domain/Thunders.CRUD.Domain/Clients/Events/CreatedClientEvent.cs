namespace Thunders.CRUD.Domain.Clients.Events
{
    public class CreatedClientEvent(Guid aggregateId, string name, string email, string profession) : Event(aggregateId)
    {
        public string Name { get; } = name;

        public string Email { get; } = email;

        public string Profession { get; } = profession;
    }
}
