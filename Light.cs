using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAP_3_command_c_sharp_
{
    class Light
    {
        string location;
        public Light(string loc) => location = loc;
        public void On()
        {
            Console.WriteLine($"{location} light is on.");
        }
        public void Off()
        {
            Console.WriteLine($"{location} light is off.");
        }
    }

    class LightOnCommand : Command
    {
        Light light;
        public LightOnCommand(Light l) => light = l;
        public void execute()
        {
            light.On();
        }
        public void undo()
        {
            light.Off();
        }
    }
    class LightOffCommand : Command
    {
        Light light;
        public LightOffCommand(Light l) => light = l;
        public void execute()
        {
            light.Off();
        }
        public void undo()
        {
            light.On();
        }
    }
}
