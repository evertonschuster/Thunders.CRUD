using Thunders.CRUD.Domain.Commoms;
using Thunders.CRUD.Domain.Todos.Exceptions;
using Thunders.CRUD.Domain.Todos.Repositories;

namespace Thunders.CRUD.Application.Todos.IncompleteTodo
{
    public class IncompleteTodoHandler(ITodoRepository todoRepository, IUnitOfWork unitOfWork) : IRequestHandler<IncompleteTodoCommand>
    {
        private readonly ITodoRepository todoRepository = todoRepository;
        private readonly IUnitOfWork unitOfWork = unitOfWork;

        public Task Handle(IncompleteTodoCommand request, CancellationToken cancellationToken)
        {
            var model = todoRepository.GetById(request.Id) ?? throw new TodoNotFoundException();
            model.Incomplete();

            todoRepository.Update(model);
            cancellationToken.ThrowIfCancellationRequested();
            unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
