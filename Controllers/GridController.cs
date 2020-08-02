using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rover.Models;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace grid.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GridController : ControllerBase
    {

        public GridController(IRoverRepository grid)
        {
            Grid = grid;
        }

        public IRoverRepository Grid { get; set; }


        // GET api/grid
        [HttpGet]
        public IActionResult Get()
        {
            var grid = Grid.GetGrid();
            return new ObjectResult(grid.MaxSize);
        }

        // PUT api/grid
        [HttpPut]
        public IActionResult PutGrid([FromBody] Grid grid)
        {
            if (grid == null)
            {
                return BadRequest();
            }
            Grid.SetGrid(grid);
            return NoContent();
        }
    }

}
