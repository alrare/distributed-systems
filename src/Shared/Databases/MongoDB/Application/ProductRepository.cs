using MongoDB.Driver;
using Products.Api.Read.Core.Context;
using Products.Api.Read.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Api.Read.Application
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductContext _productContext;
        public ProductRepository(IProductContext autorContext) {
            _productContext = autorContext;
        }

        public async  Task<IEnumerable<ProductEntity>> GetProducts()
        {
            return await _productContext.Product.Find(p => true).ToListAsync();
        }
    }
}
