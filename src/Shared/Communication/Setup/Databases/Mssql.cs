using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

namespace Setup.Databases
{
    public static class Mssql
    {
        public static IServiceCollection AddMssqlDbContext<T>(this IServiceCollection serviceCollection, string databaseName)
        where T : DbContext
        {
            return serviceCollection.AddDbContext<T>(serviceProvider => GetConnectionString(databaseName));
        }

        private static async Task<string> GetConnectionString(string databaseName)
        {
            //ISecretManager secretManager = serviceProvider.GetRequiredService<ISecretManager>();
            //IServiceDiscovery serviceDiscovery = serviceProvider.GetRequiredService<IServiceDiscovery>();

            //DiscoveryData mysqlData = await serviceDiscovery.GetDiscoveryData(DiscoveryServices.MySql);
            //MySqlCredentials credentials =await secretManager.Get<MySqlCredentials>("mysql");

            //return $"Server={mysqlData.Server};Port={mysqlData.Port};Database={databaseName};Uid={credentials.username};password={credentials.password};";

            return "Server=DESKTOP-54NHJ4E\\SQLEXPRESS;Database=Distribt;Trusted_Connection=True;TrustServerCertificate=True";

        }


        private record MySqlCredentials
        {
            public string username { get; init; } = null!;
            public string password { get; init; } = null!;
        }

    }
}
