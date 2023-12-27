namespace Thunders.CRUD.Application.Todos.IncompleteTodo
{
    public class IncompleteTodoCommand : IRequest
    {
        public IncompleteTodoCommand()
        {
        }

        public IncompleteTodoCommand(Guid id)
        {
        }

        public Guid Id { get; set; }
    }
}
