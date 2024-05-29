using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Products.Api.Write.Core.Entities;


namespace Mssql
{
    //public class MssqlDbDependencyInjection : DbContext
    //{
    //    public MssqlDbDependencyInjection(DbContextOptions<MssqlDbDependencyInjection> options) : base(options)
    //    {

    //    }

    //    public DbSet<Product> Products { get; set; }
    //}

    public static class MssqlDbDependencyInjection
    {
        public static IServiceCollection AddMssqlDbContext<T>(this IServiceCollection serviceCollection, Func<IServiceProvider, Task<string>> connectionString)
       where T : DbContext
        {
            return serviceCollection.AddDbContext<T>((serviceProvider, builder) =>
            {
                builder.UseSqlServer(connectionString.Invoke(serviceProvider).Result);
            });
        }
    }


}
