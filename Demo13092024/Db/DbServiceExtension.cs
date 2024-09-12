using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Demo13092024.Db
{
    public static class DbServiceExtension
    {
        public static void AddDatabaseService(this IServiceCollection services, string connectionString)
            => services.AddDbContext<CodeFirstDemoContext>(options => options.UseSqlServer(connectionString));
    }
}
