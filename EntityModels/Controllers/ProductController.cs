using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EntityModels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public ProductController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<List<Product>> GetAllProducts()
        {
            return appDbContext.Products.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = appDbContext.Products.ToList().Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            product.Id = appDbContext.Products.ToList().Count == 0 ? 1 : appDbContext.Products.ToList().Max(a => a.Id) + 1;
            appDbContext.Products.ToList().Add(product);
            appDbContext.SaveChanges();
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            var existingProduct = appDbContext.Products.ToList().Find(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.Name = product.Name;
            existingProduct.ItemPrice = product.ItemPrice;
            existingProduct.Description = product.Description;
            appDbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = appDbContext.Products.ToList().Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            appDbContext.Products.ToList().Remove(product);
            appDbContext.SaveChanges();
            return NoContent();
        }
    }
}