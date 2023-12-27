﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Thunders.CRUD.Application.Todos.CompleteTodo;
using Thunders.CRUD.Application.Todos.IncompleteTodo;
using Thunders.CRUD.Domain.Commoms;
using Thunders.CRUD.Domain.Todos.Exceptions;
using Thunders.CRUD.Domain.Todos.Models;
using Thunders.CRUD.Domain.Todos.Repositories;

namespace Thunders.CRUD.Application.Test.Todos
{
    public class IncompleteTodoHandlerTest
    {
        [Fact]
        public async Task Handle_Should_Mark_Todo_As_Incomplete_When_Todo_Exists()
        {
            var todoRepository = Substitute.For<ITodoRepository>();
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var handler = new IncompleteTodoHandler(todoRepository, unitOfWork);
            var todo = Todo.Create("Test Todo", "Test Description", Guid.NewGuid());
            todoRepository.GetById(Arg.Any<Guid>()).Returns(todo);
            var command = new IncompleteTodoCommand(todo.Id);


            await handler.Handle(command, CancellationToken.None);


            todoRepository.Received(1).Update(Arg.Is<Todo>(t => !t.IsCompleted));
            unitOfWork.Received(1).SaveChanges();
        }

        [Fact]
        public async Task Handle_Should_Throw_TodoNotFoundException_When_Todo_Does_Not_Exist()
        {
            var todoRepository = Substitute.For<ITodoRepository>();
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var handler = new IncompleteTodoHandler(todoRepository, unitOfWork);
            var command = new IncompleteTodoCommand(Guid.NewGuid());


            var act = async () => await handler.Handle(command, CancellationToken.None);


            await Assert.ThrowsAsync<TodoNotFoundException>(act);
        }

        [Fact]
        public async Task Handle_Should_ThrowOperationCanceled_When_CancellationTokenIsCancelled()
        {
            var todoRepository = Substitute.For<ITodoRepository>();
            var unitOfWork = Substitute.For<IUnitOfWork>();
            todoRepository.GetById(Arg.Any<Guid>()).Returns(Todo.Create("Test Todo", "Test Description", Guid.NewGuid()));

            var handler = new IncompleteTodoHandler(todoRepository, unitOfWork);
            var command = new IncompleteTodoCommand(Guid.NewGuid());
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();


            Func<Task> act = async () => await handler.Handle(command, cancellationTokenSource.Token);


            await act.Should().ThrowAsync<OperationCanceledException>();
            unitOfWork.DidNotReceive().SaveChanges();
            await unitOfWork.DidNotReceive().SaveChangesAsync();
        }
    }
}
