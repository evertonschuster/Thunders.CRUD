using Microsoft.Extensions.DependencyInjection;
using Thunders.CRUD.Domain.Clients.Repositories;
using Thunders.CRUD.Domain.Commoms;
using Thunders.CRUD.Domain.Todos.Repositories;
using Thunders.CRUD.infrastructure.Clients;
using Thunders.CRUD.infrastructure.Todos;
using Thunders.CRUD.infrastructure.UnitOfWork;

namespace Thunders.CRUD.infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static void AddInfraInjection(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWorkEfCore>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ITodoRepository, TodoRepository>();
        }
    }
}
