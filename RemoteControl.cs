using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAP_3_command_c_sharp_
{
    class RemoteControl
    {
        public int NumberOfDevices { get; set; }
        Command[] onCommands;
        Command[] offCommands;
        Stack<Command> undoCommands = new Stack<Command>();
        Stack<Command> redoCommands = new Stack<Command>();

        public RemoteControl(int numberOfDevices)
        {
            NumberOfDevices = numberOfDevices;
            onCommands = new Command[numberOfDevices];
            offCommands = new Command[numberOfDevices];

            Command noCommand = new NoCommand();
            for (int i = 0; i < numberOfDevices; i++)
            {
                onCommands[i] = offCommands[i] = noCommand;
            }
            undoCommands.Push(noCommand);
            redoCommands.Push(noCommand);
        }
        public void SetCommand(int slot, Command onCommand, Command offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;
        }
        public void OnButtonWasPushed(int slot)
        {
            onCommands[slot].execute();
            undoCommands.Push(onCommands[slot]);
            redoCommands.Clear();
        }
        public void OffButtonWasPushed(int slot)
        {
            offCommands[slot].execute();
            undoCommands.Push(offCommands[slot]);
            redoCommands.Clear();
        }
        public void UndoButtonWasPushed()
        {
            if (undoCommands.Count != 0)
            {
                Command undoed = undoCommands.Pop();
                redoCommands.Push(undoed);
                undoed.undo();
            }
        }
        public void RedoButtonWasPushed()
        {
            if (redoCommands.Count != 0)
            {
                Command redoed = redoCommands.Pop();
                undoCommands.Push(redoed);
                redoed.execute();
            }
        }


        public override string ToString()
        {
            StringBuilder s = new StringBuilder("\n------------------ Remote Control ------------------\n");
            for (int i = 0; i < NumberOfDevices; i++)
            {
                s.Append("slot [" + i + "] " + onCommands[i].GetType().Name + "   " + offCommands[i].GetType().Name + "\n");
            }
           
            return s.ToString();
        }

    }
}
