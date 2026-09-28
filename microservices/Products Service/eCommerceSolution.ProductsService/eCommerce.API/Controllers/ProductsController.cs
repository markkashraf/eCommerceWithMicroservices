using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCommecre.Infrastructre.Repository_Interfaces;
using eCommerce.Core.Entities;
using eCommerce.API.DTOs;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _productsRepository.GetProducts();
            return Ok(products);
        }

        // GET: api/Products/{id}
        [HttpGet("{id}")]
        public ActionResult<Product> Get(Guid id)
        {
            var product = _productsRepository.GetProductByCondition(p => p.ProductID == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public ActionResult<Product> Post([FromBody] ProductAddRequest request)
        {
            if (request == null) return BadRequest();

            var product = new Product
            {
                ProductID = Guid.NewGuid(),
                ProductName = request.ProductName,
                Category = request.Category,
                UnitPrice = request.UnitPrice,
                UnitsInStock = request.UnitsInStock
            };

            _productsRepository.AddProduct(product);

            return CreatedAtAction(nameof(Get), new { id = product.ProductID }, product);
        }

        // PUT: api/Products/{id}
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProductUpdateRequest request)
        {
            if (request == null || id != request.ProductID) return BadRequest();

            var existing = _productsRepository.GetProductByCondition(p => p.ProductID == id);
            if (existing == null) return NotFound();

            existing.ProductName = request.ProductName;
            existing.Category = request.Category;
            existing.UnitPrice = request.UnitPrice;
            existing.UnitsInStock = request.UnitsInStock;

            _productsRepository.UpdateProduct(existing);
            return NoContent();
        }

        // DELETE: api/Products/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var existing = _productsRepository.GetProductByCondition(p => p.ProductID == id);
            if (existing == null) return NotFound();

            _productsRepository.DeleteProduct(id);
            return NoContent();
        }
    }
}
