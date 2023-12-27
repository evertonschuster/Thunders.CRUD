using Thunders.CRUD.Application.Todos.CompleteTodo;
using Thunders.CRUD.Application.Todos.DeleteTodo;
using Thunders.CRUD.Domain.Commoms;
using Thunders.CRUD.Domain.Todos.Exceptions;
using Thunders.CRUD.Domain.Todos.Models;
using Thunders.CRUD.Domain.Todos.Repositories;

namespace Thunders.CRUD.Application.Test.Todos
{
    public class DeleteTodoHandlerTest
    {
        [Fact]
        public async Task Handle_Should_Delete_Todo_When_Todo_Exists()
        {
            var todo = new Todo(Guid.NewGuid(), "Title", "Description", null, null, null);

            var todoRepository = Substitute.For<ITodoRepository>();
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var handler = new DeleteTodoHandler(todoRepository, unitOfWork);
            var command = new DeleteTodoCommand(todo.Id);
            todoRepository.GetById(Arg.Any<Guid>()).Returns(todo);


            await handler.Handle(command, CancellationToken.None);


            todoRepository.Received(1).Update(Arg.Any<Todo>());
            unitOfWork.Received(1).SaveChanges();
        }

        [Fact]
        public async Task Handle_Should_Throw_TodoNotFoundException_When_Todo_Does_Not_Exist()
        {
            var todoRepository = Substitute.For<ITodoRepository>();
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var handler = new DeleteTodoHandler(todoRepository, unitOfWork);
            var command = new DeleteTodoCommand(Guid.NewGuid());


            var act = async () => await handler.Handle(command, CancellationToken.None);


            await Assert.ThrowsAsync<TodoNotFoundException>(act);
            unitOfWork.DidNotReceive().SaveChanges();
            await unitOfWork.DidNotReceive().SaveChangesAsync();
        }

        [Fact]
        public async Task Handle_Should_ThrowOperationCanceled_When_CancellationTokenIsCancelled()
        {
            var todoRepository = Substitute.For<ITodoRepository>();
            var unitOfWork = Substitute.For<IUnitOfWork>();
            todoRepository.GetById(Arg.Any<Guid>()).Returns(Todo.Create("Test Todo", "Test Description", Guid.NewGuid()));

            var handler = new CompleteTodoHandler(todoRepository, unitOfWork);
            var command = new CompleteTodoCommand(Guid.NewGuid());
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();


            Func<Task> act = async () => await handler.Handle(command, cancellationTokenSource.Token);


            await act.Should().ThrowAsync<OperationCanceledException>();
            unitOfWork.DidNotReceive().SaveChanges();
            await unitOfWork.DidNotReceive().SaveChangesAsync();
        }
    }
}
