namespace Thunders.CRUD.Domain.Clients.Events
{
    public class UpdatedClientEvent(Guid aggregateId, string email, string profession) : Event(aggregateId)
    {
        public string Email { get; } = email;

        public string Profession { get; } = profession;
    }
}
