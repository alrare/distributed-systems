using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Api.Write.Core.Context;
using Products.Api.Write.Core.Entities;

namespace Products.Api.Write.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<Product>>> GetAll()
        //{
        //    var products = new List<Product> {
        //        new Product
        //        {
        //            Id = 1,
        //            Name = "Product1",
        //            Description = "Description",
        //            Stock=  10,
        //            Price = 10
        //        }
        //    };
        //    return Ok(products);
        //}

        //[HttpGet]
        //public async Task<ActionResult<List<Product>>> GetAll()
        //{
        //    var products = await _context.Products.ToListAsync();
            
        //    return Ok(products);
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Product>> GetById(int id)
        //{
        //    var product = await _context.Products.FindAsync(id);
        //    if(product is null)
        //        return NotFound("Producto no encontrado");
            
        //    return Ok(product);
        //}

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToArrayAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Product>>> UpdateProduct(int id, Product updateProduct)
        {
            var dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct is null)
                return NotFound("Producto no encontrado");

            dbProduct.Name = updateProduct.Name;
            dbProduct.Description = updateProduct.Description;
            dbProduct.Stock = updateProduct.Stock;
            dbProduct.Price = updateProduct.Price;
                    
            return Ok(await _context.Products.ToArrayAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct is null)
                return NotFound("Producto no encontrado");

            _context.Products.Remove(dbProduct);
            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToArrayAsync());
        }

    }
}
