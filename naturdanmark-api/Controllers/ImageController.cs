using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using naturdanmark_api.Models;
using naturdanmark_api.Repositories;

namespace naturdanmark_api.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class ImageController : ControllerBase
    {
        private ImageRepo _repo;

        public ImageController(ImageRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Observation> Post([FromBody] byte[] raw)
        {
            Image img = new(raw);
            try
            {
                img = _repo.Add(img);
                return Created($"{img.ObservationID}", img);
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Get(int id)
        {
            Image? img = _repo.GetById(id);

            if (img == null)
            {
                return NotFound();
            }

            return Ok(img);
        }
    }
}
