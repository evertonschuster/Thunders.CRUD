namespace Thunders.CRUD.Domain
{
    public class Event
    {
        public Guid Id { get; set; }

        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
