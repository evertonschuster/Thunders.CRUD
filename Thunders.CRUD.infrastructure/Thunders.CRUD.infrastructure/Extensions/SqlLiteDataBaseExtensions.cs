using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Thunders.CRUD.Domain.Commoms;
using Thunders.CRUD.infrastructure.UnitOfWork;

namespace Thunders.CRUD.infrastructure.Extensions
{
    public static class SqlLiteDataBaseExtensions
    {
        public static void MigrateApplicationContext(this DbContext context)
        {
            context.Database.Migrate();
        }

        public static void AddLocalApplicationContext(this IServiceCollection services)
        {
            var folder = Environment.SpecialFolder.ApplicationData;
            var path = Environment.GetFolderPath(folder);
            var dbPath = Path.Join(path, "Thunders.db");
            var connectionString = $"Data Source={dbPath}";

            services.AddDbContextPool<ThunderContext>(options =>
                options.UseSqlite(connectionString)
            );

            services.AddScoped<IUnitOfWork, UnitOfWorkEfCore>();
        }
    }
}
