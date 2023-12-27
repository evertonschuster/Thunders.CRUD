using Thunders.CRUD.Domain.Commoms;
using Thunders.CRUD.Domain.Todos.Exceptions;
using Thunders.CRUD.Domain.Todos.Repositories;

namespace Thunders.CRUD.Application.Todos.CloseTodo
{
    public class CloseTodoHandler(ITodoRepository todoRepository, IUnitOfWork unitOfWork) : IRequestHandler<CloseTodoCommand>
    {
        private readonly ITodoRepository todoRepository = todoRepository;
        private readonly IUnitOfWork unitOfWork = unitOfWork;

        public Task Handle(CloseTodoCommand request, CancellationToken cancellationToken)
        {
            var model = todoRepository.GetById(request.Id) ?? throw new TodoNotFoundException();
            model.Close();

            todoRepository.Update(model);
            cancellationToken.ThrowIfCancellationRequested();
            unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
