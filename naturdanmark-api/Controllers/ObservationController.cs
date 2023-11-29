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
        /// Bruger ObservationsRepoDB til at hente en liste af observationer
        /// </summary>
        /// <returns>Returnere statuskode 200 hvis der er data og 204 hvis der ikke er data</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<Observation>> GetObservations()
        {
            return _observationrepo.GetAll();
        }

        /// <summary>
        /// Returnerer en Observation hvis den findes i ObservationsTabellen
        /// </summary>
        /// <param name="id">Id bruges til at finde Observation i Observationstabellen</param>
        /// <returns> Returnere 200 hvis Observationen findes og 404 hvis Observationen ikke findes</returns>
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
        /// Gemmer en Observation i ObservationsTabellen
        /// </summary>
        /// <param name="obs">indeholder den observation som skal gemmes</param>
        /// <returns>Returner fejlkode 201 hvis en observation gemmes og sender fejlkode 400 hvis der er noge</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Observation> Post([FromBody] Observation obs)
        {
            try
            {
                Observation Createdobs = _observationrepo.Add(obs);
                return Created($"{obs.ID}", obs);
            }
            catch(ArgumentNullException)
            {
                return BadRequest();
            }
            catch(ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
        }
    }
}
