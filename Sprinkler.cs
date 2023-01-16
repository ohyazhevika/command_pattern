using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAP_3_command_c_sharp_
{
    class Sprinkler
    {
        public void SprayingOn()
        {
            Console.WriteLine("Start splashing water.");
        }
        public void SprayingOff()
        {
            Console.WriteLine("Stop splashing water.");
        }
    }

    class SprinklerOn: Command
    {
        Sprinkler sprinkler;
        public SprinklerOn(Sprinkler s) => sprinkler = s;
        public void execute()
        {
            sprinkler.SprayingOn();
        }
        public void undo()
        {
            sprinkler.SprayingOff();
        }
    }
    class SprinklerOff : Command
    {
        Sprinkler sprinkler;
        public SprinklerOff(Sprinkler s) => sprinkler = s;
        public void execute()
        {
            sprinkler.SprayingOff();
        }
        public void undo()
        {
            sprinkler.SprayingOn();
        }
    }
}
