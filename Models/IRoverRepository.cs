using System.Collections.Generic;

namespace rover.Models
{
    public interface IRoverRepository
    {
        int Add(RoverMachine rover);
        IEnumerable<RoverMachine> GetAll();
        Grid GetGrid();
        Grid SetGrid(Grid grid);
        RoverMachine Find(int roverId);
        RoverMachine Move(int roverId, string movements);
    }
}
