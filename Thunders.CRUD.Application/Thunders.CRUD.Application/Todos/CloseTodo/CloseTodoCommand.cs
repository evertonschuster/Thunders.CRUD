﻿namespace Thunders.CRUD.Application.Todos.CloseTodo
{
    public class CloseTodoCommand : IRequest
    {
        public CloseTodoCommand()
        {
        }

        public CloseTodoCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}