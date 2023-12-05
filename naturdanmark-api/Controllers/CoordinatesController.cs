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
        public Coordinates GetByID(int id)
        {
            return coordinateRepo.GetById(id);
        }

        [HttpPost]
        public Coordinates Post(Coordinates cor)
        {
            return coordinateRepo.Add(cor);
        }

        [HttpPut]
        public Coordinates Put(Coordinates cor,int id)
        {
            return coordinateRepo.Update(id, cor);
        }
    }
}
