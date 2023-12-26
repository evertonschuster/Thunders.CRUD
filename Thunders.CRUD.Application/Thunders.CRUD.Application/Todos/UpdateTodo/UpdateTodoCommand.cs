namespace Thunders.CRUD.Application.Todos.UpdateTodo
{
    public class UpdateTodoCommand : IRequest<UpdateTodoResult>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Guid? ClientId { get; set; }
    }
}
