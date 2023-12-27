using Thunders.CRUD.Domain.Commoms;
using Thunders.CRUD.Domain.Todos.Exceptions;
using Thunders.CRUD.Domain.Todos.Repositories;

namespace Thunders.CRUD.Application.Todos.CompleteTodo
{
    public class CompleteTodoHandler(ITodoRepository todoRepository, IUnitOfWork unitOfWork) : IRequestHandler<CompleteTodoCommand>
    {
        private readonly ITodoRepository todoRepository = todoRepository;
        private readonly IUnitOfWork unitOfWork = unitOfWork;

        public Task Handle(CompleteTodoCommand request, CancellationToken cancellationToken)
        {
            var model = todoRepository.GetById(request.Id) ?? throw new TodoNotFoundException();
            model.Complete();

            todoRepository.Update(model);
            cancellationToken.ThrowIfCancellationRequested();
            unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
