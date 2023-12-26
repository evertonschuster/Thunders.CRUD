namespace Thunders.CRUD.Application.Todos.CreateTodo
{
    public class CreateTodoResult
    {
        public CreateTodoResult(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
