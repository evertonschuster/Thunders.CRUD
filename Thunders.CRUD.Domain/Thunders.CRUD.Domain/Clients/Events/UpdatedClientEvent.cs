using Thunders.CRUD.Domain.Commoms;

namespace Thunders.CRUD.Domain.Clients.Events
{
    public sealed class UpdatedClientEvent : Event
    {

        protected UpdatedClientEvent()
        {
            Email = default!;
            Profession = default!;
        }

        public UpdatedClientEvent(Guid aggregateId, string email, string profession) : base(aggregateId)
        {
            Email = email;
            Profession = profession;
        }

        public string Email { get; }

        public string Profession { get; }
    }
}
