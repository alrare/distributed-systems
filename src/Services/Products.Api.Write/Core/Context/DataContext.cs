using Microsoft.EntityFrameworkCore;
using Products.Api.Write.Core.Entities;

namespace Products.Api.Write.Core.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                
        }

        public DbSet<Product> Products { get; set; }
    }
}
