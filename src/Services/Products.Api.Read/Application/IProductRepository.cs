
using Products.Api.Read.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Api.Read.Application
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetProducts();

    }
}
