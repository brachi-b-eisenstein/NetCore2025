using Microsoft.AspNetCore.Mvc;
using MishnatYosef.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MishnatYosef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOnSellController : ControllerBase
    {
        static Services.ProductOnSellService _ProductsOnSell = new Services.ProductOnSellService();
        // GET: api/<ProductOnSellController>
        [HttpGet]
        public ActionResult<List<Entities.ProductOnSell>> Get()
        {
            List<Entities.ProductOnSell> products = _ProductsOnSell.GetService();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<Entities.ProductOnSell> Get(int id)
        {
            Entities.ProductOnSell product = _ProductsOnSell.GetByIdService(id);
            if (product == null) { return NotFound(); }
            return Ok(product);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult<int> Post([FromBody] Entities.ProductOnSell value)
        {
            if (_ProductsOnSell.PostService(value))
                return Ok(true);
            return Ok(false);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ActionResult<int> Put(int id, [FromBody] Entities.ProductOnSell p)
        {
            if (_ProductsOnSell.PutService(id, p))
                return Ok(true);
            return Ok(false);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            if (_ProductsOnSell.DeleteByIdService(id))
                return Ok(true);
            return NotFound();
        }
    }
}
