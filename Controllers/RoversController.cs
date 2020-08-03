using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rover.Models;
using System.Text.Json;
using System.Web.Http.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace rover.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RoversController : ControllerBase
    {

        public RoversController(IRoverRepository rovers)
        {
            Rovers = rovers;
        }

        public IRoverRepository Rovers { get; set; }


        public IEnumerable<RoverMachine> GetAll()
        {
            return Rovers.GetAll();
        }

        // GET api/rovers/{id}
        [HttpGet("{id}", Name = "GetRovers")]
        public IActionResult GetById(int id)
        {
            var rover = Rovers.Find(id);
            if (rover == null)
            {
                return NotFound();
            }
            return new ObjectResult(rover);
        }

        // POST api/rovers
        [HttpPost]
        public IActionResult Create([FromBody] RoverMachine rover)
        {
            if (rover == null)
            {
                return BadRequest();
            }
            int newId = Rovers.Add(rover);
            return CreatedAtRoute("Getrovers", new { id = newId }, rover);
        }

        // PATCH api/rovers/{id}
        [HttpPatch("{id}/move")]
        public IActionResult Update(int id, [FromBody] RoverMovements movement)
        {
            //string json = System.Text.Json.JsonSerializer.Serialize(move).ToString(); ;
            Rovers.Move(id, movement.move);

            return new NoContentResult();
        }

        // DELETE api/rovers/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Rovers.Remove(id);
        }
    }
}
