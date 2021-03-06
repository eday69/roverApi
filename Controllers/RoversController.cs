﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rover.Models;
using System.Text.Json;

namespace rover.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
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
        [HttpOptions, HttpPatch("{id}/move")]
        public IActionResult Update(int id, [FromBody] RoverMovements movement)
        {
            Rovers.Move(id, movement.move);
            return new NoContentResult();
        }
    }
}
