namespace Thunders.CRUD.Domain.Clients.Events
{
    public class DeletedClientEvent(Guid aggregateId) : Event(aggregateId)
    {
    }
}
