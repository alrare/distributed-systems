using Shared.Databases.MongoDb;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Shared.Setup.Services;
using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using Products.Api.Read.Core.Entities;
using Products.Api.Read.Infraestructure;

namespace Shared.Setup.Databases;

public static class MongoDb
{
    public static IServiceCollection AddDistribtMongoDbConnectionProvider(this IServiceCollection serviceCollection)
    {
        var conventionPack = new ConventionPack { new IgnoreExtraElementsConvention(true) };
        ConventionRegistry.Register("IgnoreExtraElements", conventionPack, type => true);

        return serviceCollection.AddScoped<IMongoDbConnectionProvider, MongoDbConnectionProvider>();
    }

}

//TODO: #20
public class MongoDbConnectionProvider : IMongoDbConnectionProvider
{
    public IMongoCollection<ProductEntity> Product => throw new NotImplementedException();


    //private readonly ISecretManager _secretManager;
    //private readonly IServiceDiscovery _serviceDiscovery;

    //private MongoUrl? MongoUrl { get; set; }

    //public MongoDbConnectionProvider(ISecretManager secretManager, IServiceDiscovery serviceDiscovery)
    //{
    //    _secretManager = secretManager;
    //    _serviceDiscovery = serviceDiscovery;
    //}


    //public MongoUrl GetMongoUrl()
    //{
    //    if (MongoUrl is not null)
    //        return MongoUrl;

    //    string mongoConnection = RetrieveMongoUrl().Result;
    //    MongoUrl = new MongoUrl(mongoConnection);

    //    return MongoUrl;
    //}

    //private async Task<string> RetrieveMongoUrl()
    //{
    //DiscoveryData mongoData = await _serviceDiscovery.GetDiscoveryData(DiscoveryServices.MongoDb);
    //MongoDbCredentials credentials =await _secretManager.Get<MongoDbCredentials>("mongodb");

    //return $"mongodb://{credentials.username}:{credentials.password}@{mongoData.Server}:{mongoData.Port}";
    //}


    //private record MongoDbCredentials
    //{
    //    public string username { get; init; } = null!;
    //    public string password { get; init; } = null!;
    //}

    
    public class ProductContext : IMongoDbConnectionProvider
    {
        private readonly IMongoDatabase _db;

        public ProductContext(IOptions<MongoSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<ProductEntity> Product => _db.GetCollection<ProductEntity>("Products");
    }
}