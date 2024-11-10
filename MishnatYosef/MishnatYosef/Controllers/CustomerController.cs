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
        public ActionResult Get()
        {
            var customers = _CustomerService.GetService();
            return Ok(customers);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (id < 0) return BadRequest();
            var customer= _CustomerService.GetByIdService(id);
            if(customer == null) { return NotFound(); }
            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult Post([FromBody] Entities.Customer value)
        {
            Validity<Entities.Customer> valid = new Validity<Entities.Customer>();
            if (value.Identity!=null&&!valid.IsValidIsraeliIdentityNumber(value.Identity) || value.Email!=null&&!valid.IsValidEmail(value.Email))
                return BadRequest();
            if (_CustomerService.AddCustomer(value))
                return Ok(true);
            return Ok(false);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Entities.Customer c)
        {
            if(_CustomerService.UpdateCustomer(id,c))
                return Ok(true);
            return Ok(false);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if(_CustomerService.DeleteByIdService(id))
                return Ok(true);
            return NotFound();
        }
    }
}
