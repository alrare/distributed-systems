using MongoDB.Driver;
using Products.Api.Read.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Api.Read.Core.Context
{
    public interface IProductContext
    {
        IMongoCollection<ProductEntity> Product { get; }

    }
}
