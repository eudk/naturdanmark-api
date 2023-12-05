using Microsoft.AspNetCore.Mvc;
using naturdanmark_api.Models;
using naturdanmark_api.Repositories;

namespace naturdanmark_api.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class CoordinatesController:ControllerBase
    {
        private CoordinateRepo coordinateRepo = new();

        public CoordinatesController(CoordinateRepo repo)
        {
            coordinateRepo = repo;
                
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Coordinates> GetByID(int id)
        {
            Coordinates? cor = coordinateRepo.GetById(id);
            if (cor == null)
                return NotFound();
            return Ok(cor);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Coordinates> Post([FromBody] Coordinates cor)
        {
            try
            {
                return Ok(coordinateRepo.Add(cor));
            }
            catch(ArgumentOutOfRangeException)
            {
                return BadRequest();
            }

        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Coordinates> Put([FromBody] Coordinates cor,int id)
        {
            try
            {
                return Ok(coordinateRepo.Update(id,cor));
            }
            catch(ArgumentOutOfRangeException ex) 
            {
                return BadRequest();
            }
        }
    }
}
