using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Products.Api.Read.Core.Entities;

namespace Shared.Databases.MongoDb;

public static class MongoDbDependencyInjection
{
    //public static IServiceCollection AddMongoDbConnectionProvider<T>(this IServiceCollection serviceCollection, T mongoDbConnectionProvider)
    //where T : IMongoDbConnectionProvider
    //{
    //    throw new NotImplementedException("#20");
    //}
}

    //public interface IMongoDbConnectionProvider
    //{
    //    MongoUrl GetMongoUrl();
    //}


public interface IMongoDbConnectionProvider
{
    IMongoCollection<ProductEntity> Product { get; }

}