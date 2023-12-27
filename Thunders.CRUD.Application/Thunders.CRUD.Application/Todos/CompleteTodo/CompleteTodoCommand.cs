namespace Thunders.CRUD.Application.Todos.CompleteTodo
{
    public class CompleteTodoCommand : IRequest
    {
        public CompleteTodoCommand()
        {
        }

        public CompleteTodoCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
