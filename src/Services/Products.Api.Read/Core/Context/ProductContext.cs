using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Products.Api.Read.Core.Entities;
using Products.Api.Read.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Api.Read.Core.Context
{
    public class ProductContext : IProductContext
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
