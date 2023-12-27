﻿using Thunders.CRUD.Domain.Commoms;

namespace Thunders.CRUD.Domain.Todos.Events
{
    public sealed class IncompletedTodoEvent : Event
    {
        public IncompletedTodoEvent(Guid aggregateId) : base(aggregateId)
        {
        }
    }
}
