using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MishnatYosef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        static Services.OrderService _Orders = new Services.OrderService();
        // GET: api/<OrderController>
        [HttpGet]
        public ActionResult<List<Entities.Order>> Get()
        {
            List<Entities.Order> orders = _Orders.GetService();
            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<Entities.Order> Get(int id)
        {
            Entities.Order order = _Orders.GetByIdService(id);
            if (order == null) { return NotFound(); }
            return Ok(order);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult<int> Post([FromBody] Entities.Order value)
        {
            if (_Orders.PostService(value))
                return Ok(true);
            return Ok(false);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ActionResult<int> Put(int id, [FromBody] Entities.Order o)
        {
            if (_Orders.PutService(id, o))
                return Ok(true);
            return Ok(false);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            if (_Orders.DeleteByIdService(id))
                return Ok(true);
            return NotFound();
        }
    }
}
