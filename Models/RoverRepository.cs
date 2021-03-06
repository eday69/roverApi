﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace rover.Models
{
    public class RoverRepository : IRoverRepository
    {
        private static List<RoverMachine> _rovers = new List<RoverMachine>();
        private static Grid _grid = new Grid();

        public RoverRepository()
        {
            //Add(new RoverMachine { XPos = 1, YPos = 1, Heading = 'N' });
        }

        public IEnumerable<RoverMachine> GetAll()
        {
            return _rovers;
        }

        public Grid GetGrid()
        {
            return _grid;
        }

        public Grid SetGrid(Grid grid)
        {
            _grid = grid;
            return _grid;
        }

        public int Add(RoverMachine rover)
        {
            rover.Id = _rovers.Count;
            _rovers.Add(rover);

            return _rovers.Count - 1;
        }

        public RoverMachine Find(int roverId)
        {
            return _rovers.ElementAtOrDefault(roverId);
        }

        public RoverMachine Move(int roverId, string movements)
        {
            RoverMachine rover;
            rover = Find(roverId);
            foreach(char command in movements)
            {
                switch (command)
                {
                    case 'L':
                        rover = rotateLeft(rover);
                        break;

                    case 'R':
                        rover = rotateRight(rover);
                        break;

                    case 'M':
                        rover = advance(rover);
                        break;

                    default:
                        break;
                }
            }
            return rover;
        }

        private RoverMachine advance(RoverMachine rover)
        {
            if (rover.Heading == 'S') rover.YPos -= 1;
            if (rover.Heading == 'N') rover.YPos += 1;
            if (rover.Heading == 'W') rover.XPos -= 1;
            if (rover.Heading == 'E') rover.XPos += 1;

            return rover;
        }

        private RoverMachine rotateLeft(RoverMachine rover)
        {
            if (rover.Heading == 'N')
            {
                rover.Heading = 'W';
            }
            else if (rover.Heading == 'W')
            {
                rover.Heading = 'S';
            }
            else if (rover.Heading == 'S')
            {
                rover.Heading = 'E';
            }
            else if (rover.Heading == 'E')
            {
                rover.Heading = 'N';
            }

            return rover;
        }

        private RoverMachine rotateRight(RoverMachine rover)
        {
            if (rover.Heading == 'N')
            {
                rover.Heading = 'E';
            }
            else if (rover.Heading == 'W')
            {
                rover.Heading = 'N';
            }
            else if (rover.Heading == 'S')
            {
                rover.Heading = 'W';
            }
            else if (rover.Heading == 'E')
            {
                rover.Heading = 'S';
            }

            return rover;
        }
    }
}
