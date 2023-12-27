namespace Thunders.CRUD.Application.Todos.ListAllTodo
{
    internal class ListAllTodoResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        public Guid Id { get; }

        /// <summary>
        /// Todo title
        /// </summary>
        /// <example>Todo title</example>
        public string Title { get; }

        /// <summary>
        /// Todo description
        /// </summary>
        /// <example>Todo description</example>
        public string Description { get; }

        /// <summary>
        /// Todo client id
        /// </summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        public Guid ClientId { get; }
    }
}
