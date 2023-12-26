using Microsoft.Extensions.DependencyInjection;
using Thunders.CRUD.Application.Clients.CreateClient;
using Thunders.CRUD.Application.Clients.DeleteClient;
using Thunders.CRUD.Application.Clients.GetByIdClient;
using Thunders.CRUD.Application.Clients.UpdateClient;

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
        }
    }
}
