using Microsoft.AspNetCore.Mvc;
using naturdanmark_api.Models;
using naturdanmark_api.Repositories;

namespace naturdanmark_api.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class ObservationController:ControllerBase
    {
        private ObservationsRepo _observationrepo = new();

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<Observation>> GetObservations()
        {
            return _observationrepo.GetAll();
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Observation> GetObservationById(int id) 
        {
            Observation? obs = _observationrepo.Getbyid(id);
            if(obs==null)
            {
                return BadRequest();
            }
            return Ok(obs);
        
        
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Observation> Post([FromBody] Observation obs)
        {
            return Created($"/+{obs.ID}", _observationrepo.Add(obs));
        }
    }
}
