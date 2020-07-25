﻿using System.Collections.Generic;

namespace rover.Models
{
    public interface IRoverRepository
    {
        int Add(RoverMachine rover);
        IEnumerable<RoverMachine> GetAll();
        RoverMachine Find(int roverId);
        RoverMachine Remove(int roverId);
        RoverMachine Move(int roverId, string movements);
    }
}