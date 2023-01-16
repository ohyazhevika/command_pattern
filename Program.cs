using System;

namespace OOAP_3_command_c_sharp_
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoteControl RC = new RemoteControl(4);

            Light kitchenLight = new Light("Kitchen");
            GarageDoor garageDoor = new GarageDoor();
            Sprinkler sprinkler = new Sprinkler();

            LightOnCommand kitchenLightOnCommand = new LightOnCommand(kitchenLight);
            LightOffCommand kitchenLightOffCommand = new LightOffCommand(kitchenLight);
            GarageDoorDown garageDoorDownCommand = new GarageDoorDown(garageDoor);
            GarageDoorUp garageDoorUpCommand = new GarageDoorUp(garageDoor);
            SprinklerOn sprinklerOnCommand = new SprinklerOn(sprinkler);
            SprinklerOff sprinklerOffCommand = new SprinklerOff(sprinkler);

            RC.SetCommand(0, kitchenLightOnCommand, kitchenLightOffCommand);
            RC.SetCommand(1, garageDoorUpCommand, garageDoorDownCommand);
            RC.SetCommand(2, sprinklerOnCommand, sprinklerOffCommand);

            Console.WriteLine(RC);

            RC.OnButtonWasPushed(0);
            RC.OnButtonWasPushed(1);
            RC.OnButtonWasPushed(2);

            RC.UndoButtonWasPushed();

            RC.RedoButtonWasPushed();
            RC.OffButtonWasPushed(1);
            RC.UndoButtonWasPushed();
            RC.UndoButtonWasPushed();
        }
    }
}
