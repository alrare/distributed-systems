using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Api.Read.Application;
using Products.Api.Read.Core.Entities;

namespace Products.Api.Read.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMongoRepository<ProductEntity> _productGenericoRepository;

        public ProductController(IMongoRepository<ProductEntity> productGenericoRepository)
        {
            _productGenericoRepository = productGenericoRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductEntity>>> Get()
        {
            return Ok(await _productGenericoRepository.GetAll());
        }


        //[HttpPost]
        //public async Task Post(ProductEntity product)
        //{
        //    await _productGenericoRepository.InsertDocument(product);
        //}

    }
}