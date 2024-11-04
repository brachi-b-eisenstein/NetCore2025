using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MishnatYosef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        static Services.CustomerService _CustomerService = new Services.CustomerService();
        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult<List<Entities.Customer>> Get()
        {
            List<Entities.Customer> customers = _CustomerService.GetService();
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<Entities.Customer> Get(int id)
        {
            Entities.Customer customer= _CustomerService.GetByIdService(id);
            if(customer == null) { return NotFound(); }
            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult<int> Post([FromBody] Entities.Customer value)
        {
            if (_CustomerService.PostService(value))
                return Ok(true);
            return Ok(false);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ActionResult<int> Put(int id, [FromBody] Entities.Customer c)
        {
            if(_CustomerService.PutService(id,c))
                return Ok(true);
            return Ok(false);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            if(_CustomerService.DeleteByIdService(id))
                return Ok(true);
            return NotFound();
        }
    }
}
