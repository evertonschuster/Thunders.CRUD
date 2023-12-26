namespace Thunders.CRUD.Application.Todos.ListAllTodo
{
    public class ListAllTodoHandler : IRequestHandler<ListAllTodoQuery, List<ListAllTodoResult>>
    {
        Task<List<ListAllTodoResult>> IRequestHandler<ListAllTodoQuery, List<ListAllTodoResult>>.Handle(ListAllTodoQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
