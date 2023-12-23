using Thunders.CRUD.infrastructure;
using Thunders.CRUD.infrastructure.Extensions;

namespace Thunders.CRUD.Api.Extensions
{
     public static class MigrateDataBaseExtension
    {
        public static void MigrateApplicationDataBase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<ThunderContext>();
            context?.MigrateApplicationContext();
        }
    }
}
