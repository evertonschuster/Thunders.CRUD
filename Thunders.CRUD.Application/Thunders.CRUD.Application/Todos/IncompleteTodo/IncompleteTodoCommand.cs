namespace Thunders.CRUD.Application.Todos.IncompleteTodo
{
    public class IncompleteTodoCommand : IRequest
    {
        public IncompleteTodoCommand()
        {
        }

        public IncompleteTodoCommand(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; set; }
    }
}
