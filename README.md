
*Rover API 

Launch & Land remote driven rovers on Europa, a moon off Jupiter that has a potential to be colonized.
First project done in C#
by Eric Day

Assumptions.
- Rovers move within a pre-defined square grid, where 0,0 is the bottom left corner and max, max is the upper right corner.
- Rovers move one grid position at a time.
- Rovers may overlap same grid position (grid square is big enough to fit several rovers at a time)
- Its a one way trip, once rover is launched, it will always arrive and land to its correct grid pre-selected position in the pre-selected heading.



To run, clone project & on terminal run
<code>dotnet run</code>

Api listens on port 5000.


Available routes

GET /api/rovers/:id     - Get current rover :id position & heading
Returns an object {
    XPos: current x grid position of rover,
    YPos: current y grid position or rover,
    Heading: current grid heading of rover
}

GET  /api/rovers        - Get all deployed rovers
Returns array of current position of all launched and landed rovers on grid.

POST /api/rovers
{  XPos: x, YPos: y, Heading: 'X'}
                        - Launch & land a rover on Europa
    - XPos: x grid landing position for rover
    - YPos: y grid landing position for rover
    - Heading: when rover lands, which way will it be facing on the grid


PATCH /api/rovers/:id/move
{ "move": "LRM" }
                        - Send a series of movement instructions for rover :id to execute
 These instructions are available:
    - "L": rotate rover 90 degrees counter-clockwise, on same grid position
    - "R": rotate rover 90 degrees clockwise, on same grid position
    - "M": move rover one grid position forward on current heading