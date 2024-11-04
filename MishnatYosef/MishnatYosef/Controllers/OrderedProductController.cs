using Microsoft.AspNetCore.Mvc;
using MishnatYosef.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MishnatYosef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderedProductController : ControllerBase
    {
        static Services.OrderedProductService _OrderProducts = new Services.OrderedProductService();
        // GET: api/<OrderedProductController>
        [HttpGet]
        public ActionResult<List<Entities.OrderedProduct>> Get()
        {
            List<Entities.OrderedProduct> orderedProducts = _OrderProducts.GetService();
            if (orderedProducts == null)
            {
                return NotFound();
            }
            return Ok(orderedProducts);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<Entities.OrderedProduct> Get(int id)
        {
            Entities.OrderedProduct orderedProduct = _OrderProducts.GetByIdService(id);
            if (orderedProduct == null) { return NotFound(); }
            return Ok(orderedProduct);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult<int> Post([FromBody] Entities.OrderedProduct value)
        {
            if (_OrderProducts.PostService(value))
                return Ok(true);
            return Ok(false);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ActionResult<int> Put(int id, [FromBody] Entities.OrderedProduct o)
        {
            if (_OrderProducts.PutService(id, o))
                return Ok(true);
            return Ok(false);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            if (_OrderProducts.DeleteByIdService(id))
                return Ok(true);
            return NotFound();
        }

    }
}
