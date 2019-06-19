using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        class Receiver
        {
            public void Action()
            {
                Console.WriteLine("called Receiver.Action()");
            }
        }

        class Invoker
        {
            private Command _cmd;
            public void SetCommand(Command cmd)
            {
                this._cmd = cmd;
            }

            public void ExecuteCommand()
            {
                _cmd.Execute();
            }
        }
        abstract class Command
        {
            protected Receiver rcvr;
            public Command(Receiver receiver)
            {
                this.rcvr = receiver;
            }

            public abstract void Execute();
        }

        class ConcreteCommand : Command
        {      
            public ConcreteCommand(Receiver rcvr) : base(rcvr)
            {
            }
            
            public override void Execute()
            {
                rcvr.Action();            
            }

        }

        static void Main(string[] args)
        {
            Receiver rcvr = new Receiver();
            Command cmd = new ConcreteCommand(rcvr);
            Invoker invkr = new Invoker();

            invkr.SetCommand(cmd);
            invkr.ExecuteCommand();

            Console.ReadKey();
        }
    }
}
