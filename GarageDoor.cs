using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAP_3_command_c_sharp_
{
    class GarageDoor
    {
        public void Up()
        {
            Console.WriteLine("Garage door is opened.");
        }
        public void Down()
        {
            Console.WriteLine("Garage door is closed.");
        }
    }

    class GarageDoorUp: Command
    {
        GarageDoor garageDoor;
        public GarageDoorUp(GarageDoor g) => garageDoor = g;
        public void execute() 
        {
            garageDoor.Up();
        }
        public void undo()
        {
            garageDoor.Down();
        }
    }
    class GarageDoorDown : Command
    {
        GarageDoor garageDoor;
        public GarageDoorDown(GarageDoor g) => garageDoor = g;
        public void execute()
        {
            garageDoor.Down();
        }
        public void undo()
        {
            garageDoor.Up();
        }
    }
}
