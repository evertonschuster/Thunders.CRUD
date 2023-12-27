﻿using Thunders.CRUD.Domain.Commoms;

namespace Thunders.CRUD.Domain.Clients.Events
{
    public sealed class DeletedClientEvent : Event
    {
        protected DeletedClientEvent()
        {
        }

        public DeletedClientEvent(Guid aggregateId) : base(aggregateId)
        {
        }
    }
}
