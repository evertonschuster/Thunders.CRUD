using Microsoft.Extensions.DependencyInjection;

namespace Thunders.CRUD.Application.Extensions
{
    public static class MediatorExtensions
    {
        public static IServiceCollection AddApplicationMediator<T>(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<T>());
            return services;
        }
    }
}
