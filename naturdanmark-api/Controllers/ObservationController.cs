using Microsoft.AspNetCore.Mvc;
using naturdanmark_api.Models;
using naturdanmark_api.Repositories;
using naturdanmark_api.Context;

namespace naturdanmark_api.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class ObservationController : ControllerBase //Anders
    {
        private ObservationsRepoDB _observationrepo;

        public ObservationController(ObservationsRepoDB repo)
        {
            _observationrepo = repo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<Observation>> GetObservations()
        {
            return _observationrepo.GetAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Observation> GetObservationById(int id)
        {
            Observation? obs = _observationrepo.Getbyid(id);
            if (obs == null)
            {
                return NotFound();
            }
            return Ok(obs);


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obs"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Observation> Post([FromBody] Observation obs)
        {
            return Created($"/+{obs.ID}", _observationrepo.Add(obs));
        }
    }
}
