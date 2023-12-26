using Thunders.CRUD.Domain.Commoms;

namespace Thunders.CRUD.Domain.Todos.Exceptions
{
    public class NeedHaveClientTodoException : BusinessExeption
    {
        public NeedHaveClientTodoException(string? property) : base("Must informate client for close Todo.", property)
        {
        }
    }
}
