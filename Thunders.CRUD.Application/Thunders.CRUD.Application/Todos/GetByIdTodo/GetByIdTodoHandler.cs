using Thunders.CRUD.Domain.Todos.Exceptions;
using Thunders.CRUD.Domain.Todos.Repositories;

namespace Thunders.CRUD.Application.Todos.GetByIdTodo
{
    public class GetByIdTodoHandler(ITodoRepository todoRepository) : IRequestHandler<GetByIdTodoQuery, GetByIdTodoResult>
    {
        private readonly ITodoRepository todoRepository = todoRepository;

        public Task<GetByIdTodoResult> Handle(GetByIdTodoQuery request, CancellationToken cancellationToken)
        {
            var model = todoRepository.GetById(request.Id) ?? throw new TodoNotFoundException();
            var result = new GetByIdTodoResult(model);

            return Task.FromResult(result);
        }
    }
}
