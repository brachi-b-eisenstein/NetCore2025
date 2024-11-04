using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MishnatYosef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributionStationController : Controller
    {
        static Services.DistributionStationService _Stations = new Services.DistributionStationService();
        // GET: api/<DistributionStationController>
        [HttpGet]
        public ActionResult<List<Entities.DistibutionStation>> Get()
        {
            List<Entities.DistibutionStation> stations = _Stations.GetService();
            if (stations == null)
            {
                return NotFound();
            }
            return Ok(stations);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<Entities.DistibutionStation> Get(int id)
        {
            Entities.DistibutionStation station = _Stations.GetByIdService(id);
            if (station == null) { return NotFound(); }
            return Ok(station);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult<int> Post([FromBody] Entities.DistibutionStation value)
        {
            if (_Stations.PostService(value))
                return Ok(true);
            return Ok(false);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ActionResult<int> Put(int id, [FromBody] Entities.DistibutionStation s)
        {
            if (_Stations.PutService(id, s))
                return Ok(true);
            return Ok(false);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            if (_Stations.DeleteByIdService(id))
                return Ok(true);
            return NotFound();
        }
    }
}
