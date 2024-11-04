using Microsoft.AspNetCore.Mvc;
using MishnatYosef.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MishnatYosef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellController : ControllerBase
    {
        static Services.SellService _Sell = new Services.SellService();
        // GET: api/<SellController>
        [HttpGet]
        public ActionResult<List<Entities.Sell>> Get()
        {
            List<Entities.Sell> sells = _Sell.GetService();
            if (sells == null)
            {
                return NotFound();
            }
            return Ok(sells);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<Entities.Sell> Get(int id)
        {
            Entities.Sell sell = _Sell.GetByIdService(id);
            if (sell == null) { return NotFound(); }
            return Ok(sell);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult<int> Post([FromBody] Entities.Sell value)
        {
            if (_Sell.PostService(value))
                return Ok(true);
            return Ok(false);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ActionResult<int> Put(int id, [FromBody] Entities.Sell s)
        {
            if (_Sell.PutService(id, s))
                return Ok(true);
            return Ok(false);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            if (_Sell.DeleteByIdService(id))
                return Ok(true);
            return NotFound();
        }
    }
}
