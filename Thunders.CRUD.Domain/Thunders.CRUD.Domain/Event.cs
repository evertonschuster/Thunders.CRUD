namespace Thunders.CRUD.Domain
{
    public class Event
    {
        public Guid Id { get; }

        public DateTimeOffset Timestamp { get; }

        public Guid AggregateId { get; }

        protected Event(Guid aggregateId)
        {
            this.Id = Guid.NewGuid();
            Timestamp = DateTimeOffset.Now;
            AggregateId = aggregateId;
        }
    }
}
