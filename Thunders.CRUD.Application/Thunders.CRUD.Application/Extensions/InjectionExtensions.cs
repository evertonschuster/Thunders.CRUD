using Microsoft.Extensions.DependencyInjection;
using Thunders.CRUD.Application.Clients.CreateClient;
using Thunders.CRUD.Application.Clients.DeleteClient;
using Thunders.CRUD.Application.Clients.GetByIdClient;
using Thunders.CRUD.Application.Clients.UpdateClient;
using Thunders.CRUD.Application.Todos.CloseTodo;
using Thunders.CRUD.Application.Todos.CompleteTodo;
using Thunders.CRUD.Application.Todos.CreateTodo;
using Thunders.CRUD.Application.Todos.DeleteTodo;
using Thunders.CRUD.Application.Todos.GetByIdTodo;
using Thunders.CRUD.Application.Todos.IncompleteTodo;
using Thunders.CRUD.Application.Todos.ListAllTodo;
using Thunders.CRUD.Application.Todos.UpdateTodo;

namespace Thunders.CRUD.Application.Extensions
{
    public static class InjectionExtensions
    {
        public static void AddApplicationInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreateClientCommand, CreateClientResult>, CreateClientHandler>();
            services.AddScoped<IRequestHandler<DeleteClientCommand>, DeleteClientHandler>();
            services.AddScoped<IRequestHandler<GetByIdClientQuery, GetByIdClientResult>, GetByIdClientHandler>();
            services.AddScoped<IRequestHandler<UpdateClientCommand, UpdateClientResult>, UpdateClientHandler>();
            services.AddScoped<IValidator<CreateClientCommand>, CreateClientValidator>();
            services.AddScoped<IValidator<UpdateClientCommand>, UpdateClientValidator>();

            services.AddScoped<IRequestHandler<CloseTodoCommand>, CloseTodoHandler>();
            services.AddScoped<IRequestHandler<CompleteTodoCommand>, CompleteTodoHandler>();
            services.AddScoped<IRequestHandler<CreateTodoCommand, CreateTodoResult>, CreateTodoHandler>();
            services.AddScoped<IRequestHandler<DeleteTodoCommand>, DeleteTodoHandler>();
            services.AddScoped<IRequestHandler<GetByIdTodoQuery, GetByIdTodoResult>, GetByIdTodoHandler>();
            services.AddScoped<IRequestHandler<ListAllTodoQuery, List<ListAllTodoResult>>, ListAllTodoHandler>();
            services.AddScoped<IRequestHandler<UpdateTodoCommand, UpdateTodoResult>, UpdateTodoHandler>();
            services.AddScoped<IRequestHandler<IncompleteTodoCommand>, IncompleteTodoHandler>();
            services.AddScoped<IValidator<CreateTodoCommand>, CreateTodoValidator>();
            services.AddScoped<IValidator<UpdateTodoCommand>, UpdateTodoValidator>();
        }
    }
}
