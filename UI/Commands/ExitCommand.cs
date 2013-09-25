using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitTrainingApp.UI.Commands
{
    class ExitCommand:CommandBase
    {
        public override string GetHelp
        {
            get
            {
                return "exit - exit the application.";
            }
        }

        public ExitCommand() : base("exit") { }


        public override void Execute()
        {
            base.Execute();
            Console.WriteLine("Exiting App...");
        }

        public override bool ShouldTerminateApp()
        {
            return true;
        }
    }
}
