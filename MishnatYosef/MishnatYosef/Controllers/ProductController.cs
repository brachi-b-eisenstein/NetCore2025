using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MishnatYosef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        static Services.ProductService _Products = new Services.ProductService();

        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<List<Entities.Product>> Get()
        {
            List<Entities.Product> products = _Products.GetService();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<Entities.Product> Get(int id)
        {
            Entities.Product product = _Products.GetByIdService(id);
            if (product == null) { return NotFound(); }
            return Ok(product);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult<int> Post([FromBody] Entities.Product value)
        {
            if (_Products.PostService(value))
                return Ok(true);
            return Ok(false);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ActionResult<int> Put(int id, [FromBody] Entities.Product p)
        {
            if (_Products.PutService(id, p))
                return Ok(true);
            return Ok(false);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            if (_Products.DeleteByIdService(id))
                return Ok(true);
            return NotFound();
        }
    }
}
